using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace KenChessPGNCoreObjects
{
    // A raw ASCII PGN game is composed of two sections. The first is the tag pair section and the second is the movetext section.
    // A StructuredPGNGame is the C# representation of a raw ASCII PGN game.
    // The primary properties of a StructuredPGNGame are:
    // The moves in the chess game will be displayed in a RichTextBox whose text is generated from the MoveTree.
    // GameTags - A C# Dictionary where each PGN tag pair is a dictionary key-value pair.
    // OrderedListOfChessMoveNodes - A C# List of all ChessMoveNodess in the game.  Each ChessMoveNode has a property identifying
    //                      the parent ChessMoveNode and a List of child moves.
    //                      The first element in the list of child moves is considered to be the main line; other moves in the list are variations.
    /// <summary>
    /// 1.  Any node in the StructuredPGNGame.OrderedListOfChessMoveNodes should contain all the information necessary to display a GUI chessboard
    ///         representing the state of the game at that node.
    /// 2.  Each node will be mapped to an entry in List<MapItemForRichText>.  When the user clicks on a move in the RichText then the
    ///         GUI chessboard must be changed to show the current state of the game at that move!
    /// </summary>
    public class StructuredPGNGame
    {
        /// <summary>
        /// The GameTags dictionary corresponds to the "Tag Pair" section of a PGN game.
        /// </summary>
        public Dictionary<string, string> GameTags { get; set; }
        // Ordered list of ChessMoveNodes corresponds to the "Movetext" section of a PGN game.
        // The order is the same order as moves appear in raw PGN ASCII text.
        // RichText will also be constructed from this ordered list of ChessMoveNodes.
        // Raw pgn moves, RichText, and this list all have moves in the same order.
        public List<ChessMoveNode> OrderedListOfChessMoveNodes { get; set; }
        
        /// <summary>
        /// Constructor: Creates a StructuredPGNGame which is the most useful object in this library.
        /// </summary>
        public StructuredPGNGame(string rawPGNMultigameASCIItext, int gameNumber)
        {
            bool debugPerformance = false;
            TokenizedPGNSingleGame tokenizedPGNSingleGame = new TokenizedPGNSingleGame(rawPGNMultigameASCIItext, gameNumber);
            int indexFirstMovetextToken;
            GameTags = tokenizedPGNSingleGame.CreateGameTagsDictionary(out indexFirstMovetextToken);
            string FENinitialSetup = UtilitiesFEN.GetInitialFENSetupFromGameTags(GameTags);
            List<PGNToken> listMovetextTokens = new List<PGNToken>();
            for (int iii = indexFirstMovetextToken; iii < tokenizedPGNSingleGame.tokens.Count; iii++)
            {
                listMovetextTokens.Add(tokenizedPGNSingleGame.tokens[iii]);
            }
            List<ChessMoveBlob> listChessMoveBlobs = UtilitiesParseMovetextIntoChessMoveNodes.CreateListChessMoveBlobs(listMovetextTokens);
            OrderedListOfChessMoveNodes = UtilitiesParseMovetextIntoChessMoveNodes.ConstructListChessMoveNodes(listChessMoveBlobs);
            // set FEN for all moves! Do the first move and then use a loop for all other nodes.
            ChessMoveNode firstNode = OrderedListOfChessMoveNodes.ElementAt(0);
            string uciMove = UtilitiesConvertPgnSANtoUCI.ConvertPgnSANtoUCI(FENinitialSetup, firstNode.SANmove);
            // For Performance, save the uciMove so it won't need to be calculated again!
            firstNode.UCImove = uciMove;
            firstNode.FENPositionAfterChessMove = UtilitiesFEN.GetFENPositionAfterChessMove(FENinitialSetup, firstNode.UCImove);

            Stopwatch stopwatch = new Stopwatch();
            if (debugPerformance) { stopwatch.Start(); }
            for (int iii=1; iii<OrderedListOfChessMoveNodes.Count; iii++)
            {
                ChessMoveNode nextNode = OrderedListOfChessMoveNodes.ElementAt(iii);
                string fenPositionBeforeMove = nextNode.ParentChessMove.FENPositionAfterChessMove;
                uciMove = UtilitiesConvertPgnSANtoUCI.ConvertPgnSANtoUCI(fenPositionBeforeMove, nextNode.SANmove);
                // For Performance, save the uciMove and FENPositionAfterChessMove so they won't need to be calculated again!
                nextNode.UCImove = uciMove;
                nextNode.FENPositionAfterChessMove = UtilitiesFEN.GetFENPositionAfterChessMove(fenPositionBeforeMove, uciMove);

            }
            if (debugPerformance)
            {
                stopwatch.Stop();
                var gunga1 = stopwatch.Elapsed.TotalMilliseconds;
                var gunga2 = stopwatch.ElapsedMilliseconds;
                stopwatch.Reset();
            }
        }
    }
}
