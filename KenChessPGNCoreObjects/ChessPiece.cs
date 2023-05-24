using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace KenChessPGNCoreObjects
{
    public class ChessPiece
    {
        public PieceType PieceType { get; set; }
        public char PieceColor { get; set; }
        private char unicodeCharForPiece;
        public char UnicodeCharForPiece
        {
            get { return getUnicodeCharForPiece(); }
            set { unicodeCharForPiece = value; }
        }
        private char fenCharForPiece;
        public char FENCharForPiece 
        {
            get { return getFENcharForPiece(); }
            set { fenCharForPiece = value; }
        }

        /// <summary>
        /// Creates a new ChessPiece based on piece type and color
        /// </summary>
        public ChessPiece(PieceType pieceType, char pieceColor)
        {
            PieceType = pieceType;
            PieceColor = pieceColor;
            UnicodeCharForPiece = getUnicodeCharForPiece();
            FENCharForPiece = getFENcharForPiece();
        }
        /// <summary>
        /// Create a new ChessPiece based on FENchar (ex: 'K' creates a white King)
        /// </summary>
        public ChessPiece(char FENchar)
        {
            switch (FENchar)
            {
                case 'P': PieceType = PieceType.Pawn; break;
                case 'p': PieceType = PieceType.Pawn; break;
                case 'R': PieceType = PieceType.Rook; break;
                case 'r': PieceType = PieceType.Rook; break;
                case 'N': PieceType = PieceType.Knight; break;
                case 'n': PieceType = PieceType.Knight; break;
                case 'B': PieceType = PieceType.Bishop; break;
                case 'b': PieceType = PieceType.Bishop; break;
                case 'Q': PieceType = PieceType.Queen; break;
                case 'q': PieceType = PieceType.Queen; break;
                case 'K': PieceType = PieceType.King; break;
                case 'k': PieceType = PieceType.King; break;
                default: PieceType = PieceType.None; break;
            }
            PieceColor = "PRNBQK".Contains(FENchar.ToString()) ? 'w' : 'b';
            if (PieceType == PieceType.None)
            {
                PieceColor = '?';
            }
        }
        // Reference: https://symbl.cc/en/collections/chess-symbols/
        // 4/22/2023 Tricky! The referenced web page had a copy button so I could copy the unicode char and paste here.
        // Suggestions on the internet to use Alt+x did not work.
        private char getUnicodeCharForPiece()
        {
            char pieceAsUnicodeChar = ' ';
            if (PieceColor == 'w')
            {
                switch (PieceType)
                {
                    case PieceType.None:
                        break;
                    case PieceType.Pawn: // Unicode 2659 
                        pieceAsUnicodeChar = '♙';
                        break;
                    case PieceType.Rook: // Unicode 2656
                        pieceAsUnicodeChar = '♖';
                        break;
                    case PieceType.Knight: // Unicode 2658
                        pieceAsUnicodeChar = '♘';
                        break;
                    case PieceType.Bishop: // Unicode 2657
                        pieceAsUnicodeChar = '♗';
                        break;
                    case PieceType.Queen: // Unicode 2655
                        pieceAsUnicodeChar = '♕';
                        break;
                    case PieceType.King: // Unicode 2654
                        pieceAsUnicodeChar = '♔';
                        break;
                    default:
                        break;
                }
            }
            if (PieceColor == 'b') // Unicode 265A-265F (black KQRBNP)
            {
                switch (PieceType)
                {
                    case PieceType.None:
                        break;
                    case PieceType.Pawn:
                        pieceAsUnicodeChar = '♟';
                        break;
                    case PieceType.Rook:
                        pieceAsUnicodeChar = '♜';
                        break;
                    case PieceType.Knight:
                        pieceAsUnicodeChar = '♞';
                        break;
                    case PieceType.Bishop:
                        pieceAsUnicodeChar = '♝';
                        break;
                    case PieceType.Queen:
                        pieceAsUnicodeChar = '♛';
                        break;
                    case PieceType.King:
                        pieceAsUnicodeChar = '♚';
                        break;
                    default:
                        break;
                }
            }
            return pieceAsUnicodeChar;
        }
        private char getFENcharForPiece()
        {
            char FENchar = ' ';
            switch (PieceType)
            {
                case PieceType.Pawn:
                    FENchar = PieceColor == 'w' ? 'P' : 'p';
                    break;
                case PieceType.Rook:
                    FENchar = PieceColor == 'w' ? 'R' : 'r';
                    break;
                case PieceType.Bishop:
                    FENchar = PieceColor == 'w' ? 'B' : 'b';
                    break;
                case PieceType.Knight:
                    FENchar = PieceColor == 'w' ? 'N' : 'n';
                    break;
                case PieceType.Queen:
                    FENchar = PieceColor == 'w' ? 'Q' : 'q';
                    break;
                case PieceType.King:
                    FENchar = PieceColor == 'w' ? 'K' : 'k';
                    break;
            }
            return FENchar;
        }
    }
}
