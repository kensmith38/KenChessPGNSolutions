using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenChessPGNCoreObjects
{
    public static class UtilitiesParseMovetextIntoChessMoveNodes
    {
        /// <summary>
        /// Creates a list of chess move blobs from a list of Movetext tokens.
        /// </summary>
        public static List<ChessMoveBlob> CreateListChessMoveBlobs(List<PGNToken> listMovetextTokens)
        {
            List<ChessMoveBlob> listChessMoveBlobs = new List<ChessMoveBlob>();
            PGNToken prevToken = new PGNToken(PGNTokenType.UNKNOWN, null);

            ChessMoveBlob currentChessMoveBlob = new ChessMoveBlob();
            foreach (PGNToken pgnToken in listMovetextTokens)
            {
                if (pgnToken.tokenType == PGNTokenType.GameTerminationToken)
                {
                    if (currentChessMoveBlob.SANmove != null)
                    {
                        listChessMoveBlobs.Add(currentChessMoveBlob);
                        currentChessMoveBlob = new ChessMoveBlob();
                    }
                    currentChessMoveBlob.SANmove = null;
                    currentChessMoveBlob.TextAfterMove = pgnToken.tokenContent;
                    listChessMoveBlobs.Add(currentChessMoveBlob);
                }
                else if (pgnToken.tokenType == PGNTokenType.CommentToEOLToken)
                {
                    string comment = pgnToken.tokenContent.Substring(1, pgnToken.tokenContent.Length - 2);
                    comment = comment.Replace("\r\n", " ");
                    comment = comment.Replace("\r", " ");
                    comment = comment.Replace("\n", " ");
                    if (currentChessMoveBlob.SANmove == null)
                    {
                        currentChessMoveBlob.TextBeforeMove += " " + comment;
                    }
                    else
                    {
                        currentChessMoveBlob.TextAfterMove += " " + comment;
                    }
                }
                else if (pgnToken.tokenType == PGNTokenType.CommentBetweenBracesToken)
                {
                    string comment = pgnToken.tokenContent.Substring(1, pgnToken.tokenContent.Length - 2);
                    comment = comment.Replace("\r\n", " ");
                    comment = comment.Replace("\r", " ");
                    comment = comment.Replace("\n", " ");
                    if (currentChessMoveBlob.SANmove == null)
                    {
                        currentChessMoveBlob.TextBeforeMove += " " + comment;
                    }
                    else
                    {
                        currentChessMoveBlob.TextAfterMove += " " + comment;
                    }
                }
                else if (pgnToken.tokenType == PGNTokenType.StringToken)
                {
                    throw new Exception("Error! String tokens should never exist in Movetext section!");
                }
                // This is token for actual move
                else if (pgnToken.tokenType == PGNTokenType.SymbolToken)
                {
                    if (currentChessMoveBlob.SANmove == null)
                    {
                        currentChessMoveBlob.SANmove = pgnToken.tokenContent;
                    }
                    else
                    {
                        listChessMoveBlobs.Add(currentChessMoveBlob);
                        currentChessMoveBlob = new ChessMoveBlob();
                        currentChessMoveBlob.SANmove = pgnToken.tokenContent;
                    }
                }
                else if (pgnToken.tokenType == PGNTokenType.IntegerToken)
                {
                    if (currentChessMoveBlob.SANmove == null)
                    {
                        currentChessMoveBlob.FriendlyMoveNumber += pgnToken.tokenContent;
                    }
                    else
                    {
                        listChessMoveBlobs.Add(currentChessMoveBlob);
                        currentChessMoveBlob = new ChessMoveBlob();
                        currentChessMoveBlob.FriendlyMoveNumber += pgnToken.tokenContent;
                    }
                }
                else if (pgnToken.tokenType == PGNTokenType.PeriodToken)
                {
                    if (currentChessMoveBlob.SANmove == null)
                    {
                        currentChessMoveBlob.FriendlyMoveNumber += pgnToken.tokenContent;
                    }
                    else
                    {
                        listChessMoveBlobs.Add(currentChessMoveBlob);
                        currentChessMoveBlob = new ChessMoveBlob();
                        currentChessMoveBlob.FriendlyMoveNumber += pgnToken.tokenContent;
                    }
                }
                // Tricky! We set TextBeforeMove = "(" because we want RichText (created later) to include parentheses.
                //          When we parse this list of blobs into chess nodes we need a way to keep track of parentheses for the RichText.
                //          The simplest way to keep track of those parentheses is to treat them like TextBeforeMove.
                else if (pgnToken.tokenType == PGNTokenType.LeftParenthesisToken)
                {
                    if (currentChessMoveBlob.SANmove != null)
                    {
                        listChessMoveBlobs.Add(currentChessMoveBlob);
                    }
                    currentChessMoveBlob = ChessMoveBlob.createLeftParenthesisChessMoveBlob();
                    listChessMoveBlobs.Add(currentChessMoveBlob);
                    currentChessMoveBlob = new ChessMoveBlob();
                    currentChessMoveBlob.TextBeforeMove = "(";
                }
                else if (pgnToken.tokenType == PGNTokenType.RightParenthesisToken)
                {
                    if (currentChessMoveBlob.SANmove != null)
                    {
                        currentChessMoveBlob.TextAfterMove += ")";
                        listChessMoveBlobs.Add(currentChessMoveBlob);
                    }
                    else
                    {
                        // Tricky! We set TextAfterMove = ")" because we want RichText (created later) to include parentheses.
                        //          When we parse this list of blobs into chess nodes we need a way to keep track of parentheses for the RichText.
                        //          The simplest way to keep track of those parentheses is to treat them like TextAfterMove (for most recent move).
                        // get most recent non-parenthesis blob and add ")" to the TextAfterMove
                        for (int iii = listChessMoveBlobs.Count - 1; iii >= 0; iii--)
                        {
                            ChessMoveBlob candidateBlob = listChessMoveBlobs.ElementAt(iii);
                            if (!candidateBlob.isRightParenthesisMove())
                            {
                                candidateBlob.TextAfterMove += ")";
                                break;
                            }
                        }
                    }
                    currentChessMoveBlob = ChessMoveBlob.createRightParenthesisChessMoveBlob();
                    listChessMoveBlobs.Add(currentChessMoveBlob);
                    currentChessMoveBlob = new ChessMoveBlob();
                }
                else if (pgnToken.tokenType == PGNTokenType.NAGToken)
                {
                    // need value of Numeric Annotation Glyph (NAG)
                    // First char of content is "$" and remaining content is integer
                    int nagValue = int.Parse(pgnToken.tokenContent.Substring(1));
                    string nagText = null;
                    if ((nagValue >= 1) && (nagValue <= NAGconstants.nagTable.Length - 1))
                    {
                        nagText = NAGconstants.nagTable[nagValue];
                    }
                    if (nagText != null)
                    {
                        // For values whose text meaning is only 1 or 2 characters, that text is appended to SANmove; otherwise the text is comment after move.
                        // ex: value=3 changes SANmove from Qxd1 to Qxd1!!
                        if ((nagText.Length == 1) || (nagText.Length == 2))
                        {
                            if ((currentChessMoveBlob.SANmove != null) && (currentChessMoveBlob.SANmove.EndsWith(nagText) == false))
                            {
                                currentChessMoveBlob.SANmove += nagText;
                            }
                        }
                        else
                        {
                            currentChessMoveBlob.TextAfterMove = nagText;
                        }
                    }
                }
                prevToken = pgnToken;
            }
            return listChessMoveBlobs;
        }
        /// <summary>
        /// Constructs a List<ChessMoveNode> from List<ChessMoveBlob>
        /// Tricky! We will place new ChessMoveNodes in both a List and a Stack!
        ///         The Stack is simply a useful tool to help us determine parent nodes as we get deeper into move variation depth.
        /// </summary>
        public static List<ChessMoveNode> ConstructListChessMoveNodes(List<ChessMoveBlob> listChessMoveBlobs)
        {
            List<ChessMoveNode> listChessMoveNodes = new List<ChessMoveNode>();
            Stack<ChessMoveNode> stackChessMoveNodes = new Stack<ChessMoveNode>();
            int moveVariationDepth = 0;
            foreach (var blob in listChessMoveBlobs)
            {
                if (blob.isRightParenthesisMove())
                {
                    moveVariationDepth--;
                    while (!stackChessMoveNodes.Peek().isLeftParenthesisMove())
                    {
                        stackChessMoveNodes.Pop();
                    }
                    stackChessMoveNodes.Pop();
                }
                else if (blob.isLeftParenthesisMove())
                {
                    moveVariationDepth++;
                    ChessMoveNode chessMoveNode = CreateNodeFromBlob(blob);
                    stackChessMoveNodes.Push(chessMoveNode);
                }
                else
                {
                    ChessMoveNode chessMoveNode = CreateNodeFromBlob(blob);
                    chessMoveNode.MoveVariationDepth = moveVariationDepth;
                    if ((stackChessMoveNodes.Count > 0) && (stackChessMoveNodes.Peek().isLeftParenthesisMove()))
                    {
                        chessMoveNode.ParentChessMove = GetNode3rdFromTopOfStack(stackChessMoveNodes);
                    }
                    else
                    {
                        chessMoveNode.ParentChessMove = stackChessMoveNodes.Count > 0 ? stackChessMoveNodes.Peek() : null;
                    }
                    stackChessMoveNodes.Push(chessMoveNode);
                    listChessMoveNodes.Add(chessMoveNode);
                    // set parent/child linkages
                    if (chessMoveNode.ParentChessMove != null)
                    {
                        chessMoveNode.ParentChessMove.ChildMoveVariations.Add(chessMoveNode);
                    }
                }
            }
            return listChessMoveNodes;
        }
        private static ChessMoveNode CreateNodeFromBlob(ChessMoveBlob chessMoveBlob)
        {
            ChessMoveNode chessMoveNode = new ChessMoveNode();
            chessMoveNode.FriendlyMoveNumber = chessMoveBlob.FriendlyMoveNumber;
            chessMoveNode.SANmove = chessMoveBlob.SANmove;
            chessMoveNode.TextBeforeMove = chessMoveBlob.TextBeforeMove;
            chessMoveNode.TextAfterMove = chessMoveBlob.TextAfterMove;
            return chessMoveNode;
        }
        private static ChessMoveNode GetNode3rdFromTopOfStack(Stack<ChessMoveNode> stack)
        {
            ChessMoveNode nodeTop = stack.Pop();
            ChessMoveNode node2ndFromTop = stack.Pop();
            ChessMoveNode node3rdFromTop = stack.Peek();
            // no put the top 2 nodes back on the stack!
            stack.Push(node2ndFromTop);
            stack.Push(nodeTop);
            return node3rdFromTop;
        }
    }
}
