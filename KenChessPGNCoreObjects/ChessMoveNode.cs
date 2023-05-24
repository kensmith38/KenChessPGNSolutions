using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenChessPGNCoreObjects
{
    // Tricky! A ChessMoveNode with SANmove=null and TextBeforeMove="(" is called a "LeftParenthesisMove".
    //          This is very useful when we parse ChessMoveBlobs!
    // A ChessMove is more than the Standard Alagebraic Notation (SAN); it is also the move color and text commentary and much more.
    public class ChessMoveNode
    {
        public string FriendlyMoveNumber { get; set; }
        // Moves at variation depth=0 are the mainline moves.
        public int MoveVariationDepth { get; set; }
        // Standard Algebraic Notation move (ex: Nf3 exf4 Red1)
        public string SANmove { get; set; }
        // Tricky! UCImove is initially null.  It is set when a StructuredPGNGame is instantiated.
        public string UCImove { get; set; }
        // Numeric Annotation Glyph
        // For values whose text meaning is only 1 or 2 characters, that text is appended to SANmove; otherwise the text is comment after move.
        // ex: value=3 changes SANmove from Qxd1 to Qxd1!!
        //..public int NAGvalue { get; set; }
        public string TextBeforeMove { get; set; }
        public string TextAfterMove { get; set; }

        // List of child moves (the 1st element always represents the main line move).
        public List<ChessMoveNode> ChildMoveVariations { get; set; }
        public ChessMoveNode ParentChessMove { get; set; }
        // Tricky! FENPositionAfterChessMove is initially null; it set when a StructuredPGNGame is instantiated.
        public string FENPositionAfterChessMove { get; set; }

        public ChessMoveNode()
        {
            FriendlyMoveNumber = "";
            MoveVariationDepth = 0;
            SANmove = null;
            //..NAGvalue = -1;
            TextBeforeMove = "";
            TextAfterMove = "";
            ChildMoveVariations = new List<ChessMoveNode>();
            ParentChessMove = null;
        }
        public bool isLeftParenthesisMove()
        {
            return (SANmove != null) && SANmove.Equals("(");
        }
    }
}
