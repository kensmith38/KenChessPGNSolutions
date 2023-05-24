using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenChessPGNCoreObjects
{
    public enum PieceType { None, Pawn, Rook, Knight, Bishop, Queen, King }
    public enum Direction { None, North, South, East, West, NorthEast, SouthEast, NorthWest, SouthWest}
    public enum KnightJumpDirection { None, North2West1, North2East1, East2North1, East2South1, South2East1, South2West1, West2North1, West2South1 }
}
