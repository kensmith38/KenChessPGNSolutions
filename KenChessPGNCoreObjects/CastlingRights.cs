using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenChessPGNCoreObjects
{
    /// The Castling Rights (as stored in FEN position) specify whether both sides are principally able to castle king-side or queen-side,
    /// now or later during the game - whether the involved pieces have already moved or in case of the rooks, were captured. 
    /// Castling rights do not specify, whether castling is actually possible, but are a pre-condition for both wing castlings.
    /// Thus castling might still be illegal at this point for 3 reasons:
    /// 1. there are pieces between king and rook
    /// 2. king is in check
    /// 3. king passes over or ends up on attacked square
    public class CastlingRights
    {
        public bool WhiteKingCanCastleLong { get; set; }
        public bool WhiteKingCanCastleShort { get; set; }
        public bool BlackKingCanCastleLong { get; set; }
        public bool BlackKingCanCastleShort { get; set; }

        public CastlingRights(string fenPosition)
        {
            string[] FENparts = fenPosition.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //string FENPiecePlacement = FENparts[0];
            //string FENActivePlayer = FENparts[1];
            string FENCastlingAvailability = FENparts[2];
            //string FENEnpassantTargetSquare = FENparts[3];
            //string FENHalfmoveClock = FENparts[4];
            //string FENFullMoveNumber = FENparts[5];
            if (FENCastlingAvailability.Equals("-"))
            {
                WhiteKingCanCastleLong = false;
                WhiteKingCanCastleShort = false;
                BlackKingCanCastleLong = false;
                BlackKingCanCastleShort = false;
            }
            else
            {
                WhiteKingCanCastleLong = FENCastlingAvailability.Contains("Q");
                WhiteKingCanCastleShort = FENCastlingAvailability.Contains("K");
                BlackKingCanCastleLong = FENCastlingAvailability.Contains("q");
                BlackKingCanCastleShort = FENCastlingAvailability.Contains("k"); ;
            }
        }
    }
}
