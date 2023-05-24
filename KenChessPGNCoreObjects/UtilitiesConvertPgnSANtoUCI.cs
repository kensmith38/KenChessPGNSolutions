using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenChessPGNCoreObjects
{
    public static class UtilitiesConvertPgnSANtoUCI
    {
        public static string ConvertPgnSANtoUCI(string fenPositionBeforeMove, string pgnSAN)
        {
            ChessBoard chessBoard = new ChessBoard(fenPositionBeforeMove);
            string uciMoveNotation = ConvertPgnSANtoUCI(chessBoard, pgnSAN);
            return uciMoveNotation;
        }
        /// <summary>
        /// Convert a PGN SAN move to UCI 
        /// ex: e4 --> e2e4 or e3e4 depending on piece at e2 before the move
        /// ex: Nf3 --> ??f3 where ?? must be determined based on what Knights can legally move to f3 (legally must ensure Knight not pinned) 
        /// </summary>
        public static string ConvertPgnSANtoUCI(ChessBoard chessBoardBeforeMove, string pgnSAN)
        {
            string uciMoveNotation = null;
            // pgnSAN is null at last move
            if (pgnSAN != null)
            {
                string adjustedPgnSAN = pgnSAN;
                adjustedPgnSAN = adjustedPgnSAN.Replace("!!", "");
                adjustedPgnSAN = adjustedPgnSAN.Replace("!?", "");
                adjustedPgnSAN = adjustedPgnSAN.Replace("?!", "");
                adjustedPgnSAN = adjustedPgnSAN.Replace("??", "");
                adjustedPgnSAN = adjustedPgnSAN.Replace("!", "");
                adjustedPgnSAN = adjustedPgnSAN.Replace("?", "");

                // Ex:  "Qa6xb7#", "fxg1=Q+"
                adjustedPgnSAN = adjustedPgnSAN.Trim(new char[] { '+', '#' });
                if (adjustedPgnSAN.Equals("O-O"))
                {
                    uciMoveNotation = (chessBoardBeforeMove.ActivePlayer.Equals('w')) ? "e1g1" : "e8g8";
                }
                else if (adjustedPgnSAN.Equals("O-O-O"))
                {
                    uciMoveNotation = (chessBoardBeforeMove.ActivePlayer.Equals('w')) ? "e1c1" : "e8c8";
                }
                else if (adjustedPgnSAN.Contains('='))
                {
                    // dealing with pawn promotion
                    uciMoveNotation = ConvertPgnSANtoUCIForPawnPromotion(chessBoardBeforeMove, adjustedPgnSAN);
                }
                else if ("RNBQK".Contains(adjustedPgnSAN.Substring(0, 1)))
                {
                    uciMoveNotation = ConvertPgnSANtoUCIForRNBQKNonCastlingMove(chessBoardBeforeMove, adjustedPgnSAN);
                }
                else
                {
                    // The move is a pawn forward move (but not pawn promotion); it could be a pawn capturing move.
                    uciMoveNotation = ConvertPgnSANtoUCIForPawnForwardMove(chessBoardBeforeMove, adjustedPgnSAN);
                }
            }
            return uciMoveNotation;
        }
        /// <summary>
        /// Called from method ConvertPgnSANtoUCI.  The adjustedPgnSAN has been stripped of suffixes (?? !! etc) and check/checkmate chars (+ #);
        /// We also know that this is a rook, knight, bishop, queen or King (non-castling) move.
        /// </summary>
        private static string ConvertPgnSANtoUCIForRNBQKNonCastlingMove(ChessBoard chessBoardBeforeMove, string adjustedPgnSAN)
        {
            string uciMoveNotation = null;

            // We also know that this is a rook, knight, bishop, queen or King (non-castling) move.
            // These moves are the most difficult because of disambiguation steps!
            string fromPortionPGN = null;
            string toPortionPGN = null;
            string toSquareUCI = null;
            // toPortionPGN is always last 2 chars of adjustedPgnSAN
            toPortionPGN = adjustedPgnSAN.Substring(adjustedPgnSAN.Length - 2, 2);
            // nice observation
            toSquareUCI = toPortionPGN;
            // first step will give information describing the from square but it will not be easy to find UCI for that square!
            fromPortionPGN = adjustedPgnSAN.Substring(0, adjustedPgnSAN.Length - 2);
            // at this point, fromPortion could end in 'x' (capture char) so strip it
            fromPortionPGN = fromPortionPGN.Trim('x');
            // from portion could now be length 1, 2, or 3
            // Length 3: Trivial case - get rid of 1st char of fromPortionPGN and the remaining 2 chars are the from portion of UCI move 
            // ex: Ne3 is from portion for Ne3xd5
            if (fromPortionPGN.Length == 3)
            {
                uciMoveNotation = fromPortionPGN.Substring(1, 2) + toSquareUCI;
            }
            // Length 2 ex: Nf or N3    Disambiguation distinguishes by file; if that fails then by rank; if both fail then by file+rank
            // ex: Nf is from portion for Nfd5 or Nfxd5 (another knight at b4 could also move/attack d5)
            // ex: N3 is from portion for N3d5 or N3xd5
            if (fromPortionPGN.Length == 2)
            {
                // must be disambiguation by rank or file so determine which it is
                char disambiguationChar = fromPortionPGN[1];
                bool disambiguationByRank = char.IsDigit(disambiguationChar);
                // get all legal UCI moves for this piece type (note that adjustedPgnSAN[0] is first char of adjustedPgnSAN which idnetifies piece type)
                List<string> listUciMoves = UtilitiesLegalUCIMoves.getAllLegalUciMovesForActivePlayer(chessBoardBeforeMove, adjustedPgnSAN[0]);
                if (disambiguationByRank)
                {
                    // clue: the listUciMoves will only contain one move where the 2nd char of uciMove=disambiguationChar and uciToPortion=toSquareUCI
                    foreach (string uciMove in listUciMoves)
                    {
                        char uciFromRank = uciMove[1];
                        string uciToPortion = uciMove.Substring(2);
                        if ((uciFromRank == disambiguationChar) && (uciToPortion.Equals(toSquareUCI)))
                        {
                            uciMoveNotation = uciMove;
                            break;
                        }
                    }
                }
                else
                {
                    // clue: the listUciMoves will only contain one move where the 1st char of uciMove=disambiguationChar and uciToPortion=toSquareUCI
                    foreach (string uciMove in listUciMoves)
                    {
                        char uciFromFile = uciMove[0];
                        string uciToPortion = uciMove.Substring(2);
                        if ((uciFromFile == disambiguationChar) && (uciToPortion.Equals(toSquareUCI)))
                        {
                            uciMoveNotation = uciMove;
                            break;
                        }
                    }

                }
            }
            // Length 1: Use fact: Only one piece for active player can move (or capture) to toPortionPGN
            // ex: N is from portion for moves Nf3 Nxe5
            if (fromPortionPGN.Length == 1)
            {
                // clue: Only one piece for active player can move (or capture) to toPortionPGN
                List<string> listUciMoves = UtilitiesLegalUCIMoves.getAllLegalUciMovesForActivePlayer(chessBoardBeforeMove, adjustedPgnSAN[0]);
                foreach (string uciMove in listUciMoves)
                {
                    string uciToPortion = uciMove.Substring(2);
                    if (uciToPortion.Equals(toSquareUCI))
                    {
                        uciMoveNotation = uciMove;
                        break;
                    }
                }
            }

            return uciMoveNotation;
        }
        /// <summary>
        /// Called from method ConvertPgnSANtoUCI.  The adjustedPgnSAN has been stripped of suffixes (?? !! etc) and check/checkmate chars (+ #);
        /// We also know that the adjustedPgnSAN contains '=' char.
        /// </summary>
        private static string ConvertPgnSANtoUCIForPawnPromotion(ChessBoard chessBoardBeforeMove, string adjustedPgnSAN)
        {
            string uciMoveNotation = null;
            string fromPortionPGN = null;
            string toPortionPGN = null;
            string promotionPortionPGN = null;
            // dealing with pawn promotion
            //  ex: fxg1=Q+!! but we have already adjusted to fxg1=Q
            //  ex: e8=Q+!! but we have already adjusted to e8=Q
            promotionPortionPGN = adjustedPgnSAN.Substring(adjustedPgnSAN.IndexOf('=') + 1, 1);
            adjustedPgnSAN = adjustedPgnSAN.Substring(0, adjustedPgnSAN.IndexOf('='));
            if (adjustedPgnSAN.Contains("x"))
            {
                toPortionPGN = adjustedPgnSAN.Substring(2);

                int rankNumberCapturedPiece = int.Parse(toPortionPGN.Substring(1, 1));
                int rankNumberOrigPawnPosition = (chessBoardBeforeMove.ActivePlayer.Equals('w')) ?
                    rankNumberCapturedPiece - 1 : rankNumberCapturedPiece + 1;
                fromPortionPGN = adjustedPgnSAN.Substring(0, 1) + rankNumberOrigPawnPosition.ToString();
            }
            else
            {
                toPortionPGN = adjustedPgnSAN;
                fromPortionPGN = (chessBoardBeforeMove.ActivePlayer.Equals('w')) ?
                    adjustedPgnSAN.Substring(0, 1) + "7" : adjustedPgnSAN.Substring(0, 1) + "2";
            }
            uciMoveNotation = fromPortionPGN + toPortionPGN + promotionPortionPGN;
            return uciMoveNotation;
        }
        /// <summary>
        /// Called from method ConvertPgnSANtoUCI.  The adjustedPgnSAN has been stripped of suffixes (?? !! etc) and check/checkmate chars (+ #);
        /// We also know that this is a pawn forward move (1 or 2 square move to be determined).  It could also be a pawn capturing move.
        /// </summary>
        private static string ConvertPgnSANtoUCIForPawnForwardMove(ChessBoard chessBoardBeforeMove, string adjustedPgnSAN)
        {
            string uciMoveNotation = null;
            string fromPortionPGN = null;
            string toPortionPGN = null;
            // The move is a pawn forward move (but not pawn promotion)
            // ex: e4 --> e3e4 or e2e4 for white  OR  e5e4 for black
            if (adjustedPgnSAN.Length == 2)
            {
                // Here we know that this is a pawn move forward on file (but not pawn promotion which we handled earlier).
                // Pawns can move 2 squares if they start on their original rank so we must determine if this is a 1 or 2 square move.
                // The starting square cannot be empty (piece.type = None).
                toPortionPGN = adjustedPgnSAN;
                int rankNumberDestSquare = int.Parse(toPortionPGN.Substring(1, 1));
                int rankNumberOrigSquare = (chessBoardBeforeMove.ActivePlayer.Equals('w')) ?
                    rankNumberDestSquare - 1 : rankNumberDestSquare + 1;
                // try first candidate
                fromPortionPGN = toPortionPGN.Substring(0, 1) + rankNumberOrigSquare.ToString();
                ChessSquare chessSquare = chessBoardBeforeMove.getChessSquareWithUciName(fromPortionPGN);
                if (chessSquare.PieceOnSquare.PieceType == PieceType.None)
                {
                    // pawn must have moved forward 2 squares 
                    rankNumberOrigSquare = (chessBoardBeforeMove.ActivePlayer.Equals('w')) ?
                    rankNumberDestSquare - 2 : rankNumberDestSquare + 2;
                    fromPortionPGN = toPortionPGN.Substring(0, 1) + rankNumberOrigSquare.ToString();
                }
            }
            else
            {
                // this must be pawn capture! EX: fxg4
                toPortionPGN = adjustedPgnSAN.Substring(2);

                int rankNumberCapturedPiece = int.Parse(toPortionPGN.Substring(1, 1));
                int rankNumberOrigPawnPosition = (chessBoardBeforeMove.ActivePlayer.Equals('w')) ?
                    rankNumberCapturedPiece - 1 : rankNumberCapturedPiece + 1;
                fromPortionPGN = adjustedPgnSAN.Substring(0, 1) + rankNumberOrigPawnPosition.ToString();
            }
            uciMoveNotation = fromPortionPGN + toPortionPGN;

            return uciMoveNotation;
        }
    }
}
