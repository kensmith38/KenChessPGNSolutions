using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenChessPGNCoreObjects
{
    public class ChessSquare
    {
        // PieceOnSquare may never be null but it may be PieceType.None
        public ChessPiece PieceOnSquare { get; set; }
        // Universal Chess Interface name for this square (ex: e4)
        public string UciSquareName { get; set; }
        public int fileIndex { get; set; }
        public int rankIndex { get; set; }
        public ChessSquare(string uciSquareName)
        {
            PieceOnSquare = new ChessPiece(PieceType.None, ' ');
            UciSquareName = uciSquareName;
            fileIndex = "abcdefgh".IndexOf(uciSquareName.Substring(0, 1));
            rankIndex = int.Parse(uciSquareName.Substring(1, 1)) - 1;
        }
    }
}
