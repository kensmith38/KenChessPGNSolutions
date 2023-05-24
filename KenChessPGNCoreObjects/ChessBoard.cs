using KenChessPGNCoreObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenChessPGNCoreObjects
{
    /// <summary>
    /// ChessBoard is our C# object that contains all the information in a FEN (Forsyth-Edwards notation) string.
    /// A ChessBoard can be converted into a FEN string and vice versa.
    /// </summary>
    public class ChessBoard
    {
        /// <summary>
        /// 64 ChessBoardSquares (8 files x 8 ranks).  
        /// ChessSquare[file,rank] Ex: ChessBoardSquare[0,0] === a1  Ex: ChessBoardSquare[7,7] = h8
        /// Visualize in non-flipped board: lower left corner is a1 and upper right corner is h8
        /// </summary>
        public ChessSquare[,] ChessBoardSquares { get; set; } = new ChessSquare[8, 8];
        public char ActivePlayer { get; set; } // 'w' or 'b'
        /// <summary>
        /// This property is the FEN equivalent for this ChessBoard
        /// </summary>
        public string FEN 
        {
            get { return ConstructFEN(); }
        }
        public ChessSquare EnPassantTargetSquare { get; set; }
        public bool WhiteCanCastleLong { get; set; }
        public bool WhiteCanCastleShort { get; set; }
        public bool BlackCanCastleLong { get; set; }
        public bool BlackCanCastleShort { get; set; }
        // HalfmoveClock is the count of halfmoves (or ply) since the last pawn advance or capturing move. This value is used for the fifty move draw rule.
        public int HalfmoveClock { get; set; }
        public int FullMoveNumber { get; set; }
        
        /// <summary>
        /// Constructor: Creates a new ChessBoard based on a given FEN.  Standard default setup is used if given FEN is null.
        /// </summary>
        public ChessBoard(string fenPosition)
        {
            if (fenPosition == null)
            {
                // Default is the standard initial setup for a chess game
                fenPosition = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
            }
            string uciSquareName = null;
            for (int fileIndex = 0; fileIndex < 8; fileIndex++)
            {
                for (int rankIndex = 0; rankIndex < 8; rankIndex++)
                {
                    uciSquareName = "abcdefgh".Substring(fileIndex, 1) + (rankIndex + 1).ToString();
                    ChessBoardSquares[fileIndex, rankIndex] = new ChessSquare(uciSquareName);
                }
            }
            string[] FENparts = fenPosition.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string FENPiecePlacement = FENparts[0];
            string FENActivePlayer = FENparts[1];
            string FENCastlingAvailability = FENparts[2];
            string FENEnpassantTargetSquare = FENparts[3];
            string FENHalfmoveClock = FENparts[4];
            string FENFullMoveNumber = FENparts[5];
            // pieces - we must parse
            string[] rankPieces = FENPiecePlacement.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            for (int iii = 0; iii < rankPieces.Length; iii++)
            {
                // FEN: Each rank is described, starting with rank 8 and ending with rank 1
                int rankIndex = 7 - iii;
                int fileIndex = 0;
                for (int jjj = 0; jjj < rankPieces[iii].Length; jjj++)
                {
                    char nextChar = rankPieces[iii][jjj];
                    if (char.IsDigit(nextChar))
                    {
                        fileIndex = fileIndex + int.Parse(nextChar.ToString());
                    }
                    else
                    {
                        ChessPiece chessPiece = new ChessPiece(nextChar);
                        ChessSquare chessSquare = ChessBoardSquares[fileIndex, rankIndex];
                        chessSquare.PieceOnSquare = chessPiece;
                        fileIndex++;
                    }
                }
            }
            // Active player
            ActivePlayer = FENActivePlayer.Equals("w") ? 'w' : 'b';
            // Castling
            if (FENCastlingAvailability.Equals("-"))
            {
                WhiteCanCastleLong = false;
                WhiteCanCastleShort = false;
                BlackCanCastleLong = false;
                BlackCanCastleShort = false;
            }
            else
            {
                WhiteCanCastleLong = FENCastlingAvailability.Contains("Q");
                WhiteCanCastleShort = FENCastlingAvailability.Contains("K");
                BlackCanCastleLong = FENCastlingAvailability.Contains("q");
                BlackCanCastleShort = FENCastlingAvailability.Contains("k");
            }
            // EnPassantTargetSquare
            EnPassantTargetSquare = null;
            if (!FENEnpassantTargetSquare.Equals("-"))
            {
                EnPassantTargetSquare = getChessSquareWithUciName(FENEnpassantTargetSquare);
            }
            // Halfmove clock
            HalfmoveClock = int.Parse(FENHalfmoveClock);
            // Full move number
            FullMoveNumber = int.Parse(FENFullMoveNumber);
        }

        public ChessBoard clone()
        {
            // Create a new ChessBoard based on the FEN of the ChessBoard being cloned.
            ChessBoard clonedChessBoard = new ChessBoard(FEN);
            return clonedChessBoard;
        }
        /// <summary>
        /// Adjust ChessBoard to represent state after UCI move.
        /// </summary>
        /// <param name="uciMove"></param>
        public void PerformUciMove(string uciMove)
        {
            if (uciMove == null) { return; }
            // FEN of length 5 means pawn promotion (5th char is promotion piece).
            // Ex: e7e8q Tricky! Note that lowercase 'q' could be a White queen or black queen! It must be color of piece on e7.
            // FEN of length 4 can be a move, capture, or castle.
            EnPassantTargetSquare = null;

            ChessSquare chessSquareFrom = getChessSquareWithUciName(uciMove.Substring(0, 2));
            ChessSquare chessSquareTo = getChessSquareWithUciName(uciMove.Substring(2, 2));
            
            bool isCapture = chessSquareTo.PieceOnSquare.PieceType != PieceType.None;
            // if rook captured then castling rights must be changed
            if (chessSquareTo.PieceOnSquare.PieceType == PieceType.Rook)
            {
                if (chessSquareTo.UciSquareName.Equals("a1")) { WhiteCanCastleLong = false; }
                else if (chessSquareTo.UciSquareName.Equals("a8")) { BlackCanCastleLong = false; }
                else if (chessSquareTo.UciSquareName.Equals("h1")) { WhiteCanCastleShort = false; }
                else if (chessSquareTo.UciSquareName.Equals("h8")) { BlackCanCastleLong = false; }

            }
            if ((chessSquareFrom.PieceOnSquare.PieceType == PieceType.King) &&
                (uciMove.Equals("e1c1") || uciMove.Equals("e1g1") || uciMove.Equals("e8c8") || uciMove.Equals("e8g8")))
            {
                performCastling(uciMove);
            }
            else
            {
                // All moves other than castling including pawn enpassant
                int fromSquareRankIndex = int.Parse(uciMove.Substring(1, 1)) - 1;
                int toSquareRankIndex = int.Parse(uciMove.Substring(3, 1)) - 1;
                if ((chessSquareFrom.PieceOnSquare.PieceType == PieceType.Pawn) &&
                    (Math.Abs(toSquareRankIndex - fromSquareRankIndex) == 2))
                {
                    setEnpassantSquareForMove(uciMove);
                }
                // if king moves then castling rights must be changed
                if (chessSquareFrom.PieceOnSquare.PieceType == PieceType.King)
                {
                    if (chessSquareFrom.PieceOnSquare.PieceColor == 'w')
                    {
                        WhiteCanCastleLong = false;
                        WhiteCanCastleShort = false;
                    }
                    if (chessSquareFrom.PieceOnSquare.PieceColor == 'B')
                    {
                        BlackCanCastleLong = false;
                        BlackCanCastleLong = false;
                    }
                }
                // if rook moves then castling rights must be changed (previously we handled Rook captured)
                if (chessSquareFrom.PieceOnSquare.PieceType == PieceType.Rook)
                {
                    if ((chessSquareFrom.PieceOnSquare.PieceColor == 'w') && (chessSquareFrom.UciSquareName.Equals("a1")))
                    {
                        WhiteCanCastleLong = false;
                    }
                    if ((chessSquareFrom.PieceOnSquare.PieceColor == 'w') && (chessSquareFrom.UciSquareName.Equals("h1")))
                    {
                        WhiteCanCastleShort = false;
                    }
                    if ((chessSquareFrom.PieceOnSquare.PieceColor == 'b') && (chessSquareFrom.UciSquareName.Equals("a8")))
                    {
                        WhiteCanCastleLong = false;
                    }
                    if ((chessSquareFrom.PieceOnSquare.PieceColor == 'b') && (chessSquareFrom.UciSquareName.Equals("h8")))
                    {
                        WhiteCanCastleShort = false;
                    }
                }
                // HalfmoveClock is the count of halfmoves (or ply) since the last pawn advance or capturing move. This value is used for the fifty move draw rule.
                HalfmoveClock = (isCapture || chessSquareFrom.PieceOnSquare.PieceType == PieceType.Pawn) ? 0 : HalfmoveClock++;
                //
                if (ActivePlayer == 'b')
                {
                    FullMoveNumber++;
                }
                chessSquareTo.PieceOnSquare = chessSquareFrom.PieceOnSquare;
                chessSquareFrom.PieceOnSquare = new ChessPiece(PieceType.None, ' ');

                // pawn promotion
                if (chessSquareTo.PieceOnSquare.PieceType == PieceType.Pawn) 
                {
                    if ((chessSquareTo.UciSquareName.EndsWith("1")) || (chessSquareTo.UciSquareName.EndsWith("8")))
                    {
                        // Tricky! Pawn promotion is weird in UCI... Uppercase Q can mean either black or white queen!
                        chessSquareTo.PieceOnSquare.PieceColor = chessSquareTo.UciSquareName.EndsWith("1") ? 'b' : 'w';
                        switch (uciMove[4])
                        {
                            case 'Q':
                                chessSquareTo.PieceOnSquare.PieceType = PieceType.Queen;
                                break;
                            case 'R':
                                chessSquareTo.PieceOnSquare.PieceType = PieceType.Rook;
                                break;
                            case 'B':
                                chessSquareTo.PieceOnSquare.PieceType = PieceType.Bishop;
                                break;
                            case 'N':
                                chessSquareTo.PieceOnSquare.PieceType = PieceType.Knight;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            toggleActivePlayer();
        }
        private void setEnpassantSquareForMove(string twoCharPortionUciMove)
        {
            // we already know uciMove is a pawn move of two squares (ex: a2a4 or e2e4 or a7a5 or e7e5 etc) 
            ChessSquare chessSquareFrom = getChessSquareWithUciName(twoCharPortionUciMove.Substring(0, 2));
            string fileLetter = twoCharPortionUciMove.Substring(0, 1);
            int rankNumber = int.Parse(twoCharPortionUciMove.Substring(1, 1));
            // if black move
            if (rankNumber == 7)
            {
                EnPassantTargetSquare = getChessSquareWithUciName(fileLetter + (rankNumber - 1).ToString());
            }
            else
            {
                EnPassantTargetSquare = getChessSquareWithUciName(fileLetter + (rankNumber + 1).ToString());
            }

        }
        private void performCastling(string uciMove)
        {
            // special logic for castling (both king and rook must move)
            switch (uciMove)
            {
                case "e1c1":    // white long castle
                    getChessSquareWithUciName("a1").PieceOnSquare = new ChessPiece(PieceType.None, ' ');
                    getChessSquareWithUciName("d1").PieceOnSquare = new ChessPiece('R');
                    getChessSquareWithUciName("e1").PieceOnSquare = new ChessPiece(PieceType.None, ' ');
                    getChessSquareWithUciName("c1").PieceOnSquare = new ChessPiece('K');
                    break;
                case "e1g1":    // white short castle
                    getChessSquareWithUciName("h1").PieceOnSquare = new ChessPiece(PieceType.None, ' ');
                    getChessSquareWithUciName("f1").PieceOnSquare = new ChessPiece('R');
                    getChessSquareWithUciName("e1").PieceOnSquare = new ChessPiece(PieceType.None, ' ');
                    getChessSquareWithUciName("g1").PieceOnSquare = new ChessPiece('K');
                    break;
                case "e8c8":    // black long castle
                    getChessSquareWithUciName("a8").PieceOnSquare = new ChessPiece(PieceType.None, ' ');
                    getChessSquareWithUciName("d8").PieceOnSquare = new ChessPiece('r');
                    getChessSquareWithUciName("e8").PieceOnSquare = new ChessPiece(PieceType.None, ' ');
                    getChessSquareWithUciName("c8").PieceOnSquare = new ChessPiece('k');
                    break;
                case "e8g8":    // black short castle
                    getChessSquareWithUciName("h8").PieceOnSquare = new ChessPiece(PieceType.None, ' ');
                    getChessSquareWithUciName("f8").PieceOnSquare = new ChessPiece('r');
                    getChessSquareWithUciName("e8").PieceOnSquare = new ChessPiece(PieceType.None, ' ');
                    getChessSquareWithUciName("g8").PieceOnSquare = new ChessPiece('k');
                    break;
                default:
                    break;
            }
            if (ActivePlayer == 'w')
            {
                WhiteCanCastleLong = false;
                WhiteCanCastleShort = false;
            }
            else if (ActivePlayer == 'b')
            {
                BlackCanCastleLong = false;
                BlackCanCastleShort = false;
            }
        }
        public void toggleActivePlayer()
        {
            ActivePlayer = ActivePlayer == 'w' ? 'b' : 'w';
        }
        /// <summary>
        /// Gets ChessSquare corresponding to UCI Move Notation. uciMove must be 2 characters. Ex: e4 f7 etc.
        /// </summary>
        public ChessSquare getChessSquareWithUciName(string twoCharPortionUciMove)
        {
            char fileLetter = twoCharPortionUciMove[0];
            string rankNumber = twoCharPortionUciMove.Substring(1, 1);
            int rankIndex = int.Parse(rankNumber) - 1;
            int fileIndex = "abcdefgh".IndexOf(fileLetter);
            ChessSquare chessSquare = ChessBoardSquares[fileIndex, rankIndex];
            return chessSquare;
        }
        public ChessPiece getChessPieceOnSquare(string uciSquareName)
        {
            ChessPiece chessPiece;
            ChessSquare chessSquare = getChessSquareWithUciName(uciSquareName);
            chessPiece = chessSquare.PieceOnSquare;
            return chessPiece;
        }
        public ChessSquare getChessSquareOfKing(char kingColor)
        {
            ChessSquare chessSquare = null;
            for (int fileIndex = 0; fileIndex < 8; fileIndex++)
            {
                for (int rankIndex = 0; rankIndex < 8; rankIndex++)
                {
                    if ((ChessBoardSquares[fileIndex, rankIndex].PieceOnSquare.PieceType == PieceType.King) &&
                        (ChessBoardSquares[fileIndex, rankIndex].PieceOnSquare.PieceColor == kingColor))
                    {
                        chessSquare = ChessBoardSquares[fileIndex, rankIndex];
                        break;
                    }
                }
            }
            return chessSquare;
        }
        
        /// <summary>
        /// Get adjacent square in direction specified
        /// </summary>
        public ChessSquare getAdjacentSquare(ChessSquare chessSquare, Direction direction)
        {
            ChessSquare adjChessSquare = null;
            int adjFileIndex = chessSquare.fileIndex;
            int adjRankIndex = chessSquare.rankIndex;
            switch (direction)
            {
                case Direction.North:
                    adjRankIndex++;
                    break;
                case Direction.South:
                    adjRankIndex--;
                    break;
                case Direction.East:
                    adjFileIndex++;
                    break;
                case Direction.West:
                    adjFileIndex--;
                    break;
                case Direction.NorthEast:
                    adjFileIndex++;
                    adjRankIndex++;
                    break;
                case Direction.SouthEast:
                    adjFileIndex++;
                    adjRankIndex--;
                    break;
                case Direction.NorthWest:
                    adjFileIndex--;
                    adjRankIndex++;
                    break;
                case Direction.SouthWest:
                    adjFileIndex--;
                    adjRankIndex--;
                    break;
                default:
                    break;
            }
            if ((adjFileIndex >= 0) && (adjFileIndex < 8) && (adjRankIndex >= 0) && (adjRankIndex < 8))
            {
                adjChessSquare = ChessBoardSquares[adjFileIndex, adjRankIndex];
            }
            return adjChessSquare;
        }
        /// <summary>
        /// Get square that knight can jump to in direction specified
        /// </summary>
        public ChessSquare getKnightJumpSquare(ChessSquare chessSquare, KnightJumpDirection direction)
        {
            ChessSquare adjChessSquare = null;
            int adjFileIndex = chessSquare.fileIndex;
            int adjRankIndex = chessSquare.rankIndex;
            switch (direction)
            {
                case KnightJumpDirection.North2East1:
                    adjRankIndex += 2;
                    adjFileIndex += 1;
                    break;
                case KnightJumpDirection.North2West1:
                    adjRankIndex += 2;
                    adjFileIndex += -1;
                    break;
                case KnightJumpDirection.East2North1:
                    adjRankIndex += 1;
                    adjFileIndex += 2; 
                    break;
                case KnightJumpDirection.East2South1:
                    adjRankIndex += -1;
                    adjFileIndex += 2;
                    break;
                case KnightJumpDirection.South2East1:
                    adjRankIndex += -2;
                    adjFileIndex += 1;
                    break;
                case KnightJumpDirection.South2West1:
                    adjRankIndex += -2;
                    adjFileIndex += -1;
                    break;
                case KnightJumpDirection.West2North1:
                    adjRankIndex += 1;
                    adjFileIndex += -2;
                    break;
                case KnightJumpDirection.West2South1:
                    adjRankIndex += -1;
                    adjFileIndex += -2;
                    break;
                default:
                    break;
            }
            if ((adjFileIndex >= 0) && (adjFileIndex < 8) && (adjRankIndex >= 0) && (adjRankIndex < 8))
            {
                adjChessSquare = ChessBoardSquares[adjFileIndex, adjRankIndex];
            }
            return adjChessSquare;
        }
        /// <summary>
        /// Constructs a FEN string equivalent to this ChessBoard
        /// </summary>
        private string ConstructFEN()
        {
            string equivalentFEN;
            string FENPiecePlacement = ""; ;
            string FENActivePlayer;
            string FENCastlingAvailability = "-";
            string FENEnpassantTargetSquare;
            string FENHalfmoveClock;
            string FENFullMoveNumber;
            for (int rankIndex = 7; rankIndex >= 0; rankIndex--)
            {
                int consecutiveEmptySquares = 0;
                for (int fileIndex = 0; fileIndex < 8; fileIndex++)
                {
                    ChessPiece chessPiece = ChessBoardSquares[fileIndex, rankIndex].PieceOnSquare;
                    if (chessPiece.PieceType == PieceType.None)
                    {
                        consecutiveEmptySquares++;
                    }
                    else
                    {
                        if (consecutiveEmptySquares > 0)
                        {
                            FENPiecePlacement += consecutiveEmptySquares.ToString();
                            consecutiveEmptySquares = 0;
                        }
                        FENPiecePlacement += chessPiece.FENCharForPiece.ToString();
                    }
                }
                if (rankIndex > 0)
                {
                    if (consecutiveEmptySquares > 0)
                    {
                        FENPiecePlacement += consecutiveEmptySquares.ToString();
                    }
                    FENPiecePlacement += "/";
                }
            }
            FENActivePlayer = ActivePlayer.ToString();
            if (WhiteCanCastleLong || WhiteCanCastleShort || BlackCanCastleLong || BlackCanCastleShort)
            {
                string whiteCanCastleLong = WhiteCanCastleLong ? "Q" : "";
                string whiteCanCastleShort = WhiteCanCastleShort ? "K" : "";
                string blackCanCastleLong = BlackCanCastleLong ? "q" : "";
                string blackCanCastleShort = BlackCanCastleShort ? "k" : "";
                FENCastlingAvailability = whiteCanCastleLong + whiteCanCastleShort + blackCanCastleLong + blackCanCastleShort;
            }
            FENEnpassantTargetSquare = EnPassantTargetSquare == null ? "-" : EnPassantTargetSquare.UciSquareName;
            FENHalfmoveClock = HalfmoveClock.ToString();
            FENFullMoveNumber = FullMoveNumber.ToString();
            equivalentFEN = FENPiecePlacement + " " + FENActivePlayer + " " + FENCastlingAvailability
                + " " + FENEnpassantTargetSquare + " " + FENHalfmoveClock + " " + FENFullMoveNumber;
            return equivalentFEN;
        }
    }
}
