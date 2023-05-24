using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KenChessPGNCoreObjects
{
    /// <summary>
    /// Methods used to determine if active player is in check.
    /// </summary>
    public class UtilitiesActivePlayerInCheck
    {
        /// <summary>
        /// Determine if king of active player is in check. (i.e. is white king in check if it is white's turn to move )
        /// </summary>
        public static bool isActivePlayerInCheck(ChessBoard chessBoard)
        {
            ChessSquare chessSquareOfTargetKing = chessBoard.getChessSquareOfKing(chessBoard.ActivePlayer);
            bool isAttacked =
                isKingAttackedByKing(chessBoard, chessSquareOfTargetKing) ||
                isKingAttackedByBishopOrQueen(chessBoard, chessSquareOfTargetKing) ||
                isKingAttackedByRookOrQueen(chessBoard, chessSquareOfTargetKing) ||
                isKingAttackedByKnight(chessBoard, chessSquareOfTargetKing) ||
                isKingAttackedByPawn(chessBoard, chessSquareOfTargetKing);
            return isAttacked;
        }
        /// <summary>
        /// Determine if king of specific color is attacked by king.  This method helps logic for getting all legal moves.
        /// </summary>
        public static bool isKingAttackedByKing(ChessBoard chessBoard, ChessSquare chessSquareOfTargetKing)
        {
            bool isAttacked = false;
            ChessSquare candidateDestinationChessSquare = null;
            Direction direction = Direction.None;
            // check for attacked by Rook or Queen
            for (int iii = 0; iii < 8; iii++)
            {
                if (iii == 0) { direction = Direction.North; }
                if (iii == 1) { direction = Direction.NorthEast; }
                if (iii == 2) { direction = Direction.East; }
                if (iii == 3) { direction = Direction.SouthEast; }
                if (iii == 4) { direction = Direction.South; }
                if (iii == 5) { direction = Direction.SouthWest; }
                if (iii == 6) { direction = Direction.West; }
                if (iii == 7) { direction = Direction.NorthWest; }

                candidateDestinationChessSquare = chessBoard.getAdjacentSquare(chessSquareOfTargetKing, direction);
                if (candidateDestinationChessSquare != null)
                {
                    if ((candidateDestinationChessSquare.PieceOnSquare.PieceType == PieceType.King) &&
                    (candidateDestinationChessSquare.PieceOnSquare.PieceColor != chessSquareOfTargetKing.PieceOnSquare.PieceColor))
                    {
                        isAttacked = true;
                        break;
                    }
                }
            }
            return isAttacked;
        }
        /// <summary>
        /// Determine if king of specific color is attacked by rook or queen.
        /// </summary>
        public static bool isKingAttackedByRookOrQueen(ChessBoard chessBoard, ChessSquare chessSquareOfTargetKing)
        {
            bool isAttacked = false;
            ChessSquare candidateDestinationChessSquare = null;
            Direction direction = Direction.None;
            // we want to quit looking if we find that we are attacked or find that piece blocks attack
            bool quitLookingForAttacked = false;
            // check for attacked by Rook or Queen
            for (int iii = 0; iii < 4; iii++)
            {
                if (quitLookingForAttacked) { break; }
                if (iii == 0) { direction = Direction.North; }
                if (iii == 1) { direction = Direction.West; }
                if (iii == 2) { direction = Direction.South; }
                if (iii == 3) { direction = Direction.East; }
                candidateDestinationChessSquare = chessBoard.getAdjacentSquare(chessSquareOfTargetKing, direction);

                while (candidateDestinationChessSquare != null)
                {
                    bool candidateDestinationChessSquareTypeIsRookOrQueen =
                        (candidateDestinationChessSquare.PieceOnSquare.PieceType == PieceType.Rook) ||
                        (candidateDestinationChessSquare.PieceOnSquare.PieceType == PieceType.Queen);
                    if ((candidateDestinationChessSquareTypeIsRookOrQueen) &&
                        (candidateDestinationChessSquare.PieceOnSquare.PieceColor != chessSquareOfTargetKing.PieceOnSquare.PieceColor))
                    {
                        isAttacked = true;
                        // force break of outer loop
                        quitLookingForAttacked = true;
                        // break out of inner loop
                        break;
                    }
                    if (candidateDestinationChessSquare.PieceOnSquare.PieceType != PieceType.None)
                    {
                        // break out of inner loop
                        break;
                    }
                    candidateDestinationChessSquare = chessBoard.getAdjacentSquare(candidateDestinationChessSquare, direction);
                }
            }
            return isAttacked;
        }
        /// <summary>
        /// Determine if king of specific color is attacked by bishop or queen.
        /// </summary>
        public static bool isKingAttackedByBishopOrQueen(ChessBoard chessBoard, ChessSquare chessSquareOfTargetKing)
        {
            bool isAttacked = false;
            ChessSquare candidateDestinationChessSquare = null;
            Direction direction = Direction.None;
            // we want to quit looking if we find that we are attacked or find that piece blocks attack
            bool quitLookingForAttacked = false;
            for (int iii = 0; iii < 4; iii++)
            {
                if (quitLookingForAttacked) { break; }
                if (iii == 0) { direction = Direction.NorthWest; }
                if (iii == 1) { direction = Direction.SouthWest; }
                if (iii == 2) { direction = Direction.NorthEast; }
                if (iii == 3) { direction = Direction.SouthEast; }
                candidateDestinationChessSquare = chessBoard.getAdjacentSquare(chessSquareOfTargetKing, direction);

                while (candidateDestinationChessSquare != null)
                {
                    bool candidateDestinationChessSquareTypeIsBishopOrQueen =
                        (candidateDestinationChessSquare.PieceOnSquare.PieceType == PieceType.Bishop) ||
                        (candidateDestinationChessSquare.PieceOnSquare.PieceType == PieceType.Queen);
                    if ((candidateDestinationChessSquareTypeIsBishopOrQueen) &&
                        (candidateDestinationChessSquare.PieceOnSquare.PieceColor != chessSquareOfTargetKing.PieceOnSquare.PieceColor))
                    {
                        isAttacked = true;
                        quitLookingForAttacked = true;
                        break;
                    }
                    if (candidateDestinationChessSquare.PieceOnSquare.PieceType != PieceType.None)
                    {
                        // break out of inner loop
                        break;
                    }
                    candidateDestinationChessSquare = chessBoard.getAdjacentSquare(candidateDestinationChessSquare, direction);
                }
            }
            return isAttacked;
        }
        /// <summary>
        /// Determine if king of specific color is attacked by knight.
        /// </summary>
        public static bool isKingAttackedByKnight(ChessBoard chessBoard, ChessSquare chessSquareOfTargetKing)
        {
            bool isAttacked = false;
            ChessSquare candidateDestinationChessSquare = null;

            int knightFileIndex = -1;
            int knightRankIndex = -1;

            for (int iii = 0; iii < 8; iii++)
            {
                if (iii == 0)
                {
                    knightFileIndex = chessSquareOfTargetKing.fileIndex + 1;
                    knightRankIndex = chessSquareOfTargetKing.rankIndex + 2;
                }
                if (iii == 1)
                {
                    knightFileIndex = chessSquareOfTargetKing.fileIndex - 1;
                    knightRankIndex = chessSquareOfTargetKing.rankIndex + 2;
                }
                if (iii == 2)
                {
                    knightFileIndex = chessSquareOfTargetKing.fileIndex + 2;
                    knightRankIndex = chessSquareOfTargetKing.rankIndex + 1;
                }
                if (iii == 3)
                {
                    knightFileIndex = chessSquareOfTargetKing.fileIndex + 2;
                    knightRankIndex = chessSquareOfTargetKing.rankIndex - 1;
                }
                if (iii == 4)
                {
                    knightFileIndex = chessSquareOfTargetKing.fileIndex + 1;
                    knightRankIndex = chessSquareOfTargetKing.rankIndex - 2;
                }
                if (iii == 5)
                {
                    knightFileIndex = chessSquareOfTargetKing.fileIndex - 1;
                    knightRankIndex = chessSquareOfTargetKing.rankIndex - 2;
                }
                if (iii == 6)
                {
                    knightFileIndex = chessSquareOfTargetKing.fileIndex - 2;
                    knightRankIndex = chessSquareOfTargetKing.rankIndex + 1;
                }
                if (iii == 7)
                {
                    knightFileIndex = chessSquareOfTargetKing.fileIndex - 2;
                    knightRankIndex = chessSquareOfTargetKing.rankIndex - 1;
                }

                if ((knightFileIndex > 0) && (knightFileIndex < 8) && (knightRankIndex > 0) && (knightRankIndex < 8))
                {
                    candidateDestinationChessSquare = chessBoard.ChessBoardSquares[knightFileIndex, knightRankIndex];
                    if ((candidateDestinationChessSquare.PieceOnSquare.PieceType == PieceType.Knight) &&
                        (candidateDestinationChessSquare.PieceOnSquare.PieceColor != chessSquareOfTargetKing.PieceOnSquare.PieceColor))
                    {
                        isAttacked = true;
                        break;
                    }
                }
            }
            return isAttacked;
        }
        /// <summary>
        /// Determine if king of specific color is attacked by pawn
        /// </summary>
        public static bool isKingAttackedByPawn(ChessBoard chessBoard, ChessSquare chessSquareOfTargetKing)
        {
            bool isAttacked = false;
            char targetKingColor = chessSquareOfTargetKing.PieceOnSquare.PieceColor;
            // The 2 pawn squares which could attack white king are: adjacentNorthEast and adjacentNorthWest.
            // The 2 pawn squares which could attack black king are: adjacentSouthEast and adjacentSouthWest.

            ChessSquare squareAdjacentNorthEast = chessBoard.getAdjacentSquare(chessSquareOfTargetKing, Direction.NorthEast);
            ChessSquare squareAdjacentNorthWest = chessBoard.getAdjacentSquare(chessSquareOfTargetKing, Direction.NorthWest);
            ChessSquare squareAdjacentSouthEast = chessBoard.getAdjacentSquare(chessSquareOfTargetKing, Direction.SouthEast);
            ChessSquare squareAdjacentSouthWest = chessBoard.getAdjacentSquare(chessSquareOfTargetKing, Direction.SouthWest);

            if (targetKingColor == 'w')
            {
                if ((squareAdjacentNorthEast != null) &&
                    (squareAdjacentNorthEast.PieceOnSquare.PieceType == PieceType.Pawn) &&
                    (squareAdjacentNorthEast.PieceOnSquare.PieceColor == 'b'))
                {
                    isAttacked = true;
                }
                if ((squareAdjacentNorthWest != null) &&
                    (squareAdjacentNorthWest.PieceOnSquare.PieceType == PieceType.Pawn) &&
                    (squareAdjacentNorthWest.PieceOnSquare.PieceColor == 'b'))
                {
                    isAttacked = true;
                }
            }
            if (targetKingColor == 'b')
            {
                if ((squareAdjacentSouthEast != null) &&
                    (squareAdjacentSouthEast.PieceOnSquare.PieceType == PieceType.Pawn) &&
                    (squareAdjacentSouthEast.PieceOnSquare.PieceColor == 'w'))
                {
                    isAttacked = true;
                }
                if ((squareAdjacentSouthWest != null) &&
                    (squareAdjacentSouthWest.PieceOnSquare.PieceType == PieceType.Pawn) &&
                    (squareAdjacentSouthWest.PieceOnSquare.PieceColor == 'w'))
                {
                    isAttacked = true;
                }
            }
            return isAttacked;
        }
    }
}
