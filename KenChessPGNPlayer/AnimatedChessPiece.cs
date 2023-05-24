using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KenChessPGNCoreObjects;

namespace KenChessPGNPlayer
{
    /// <summary>
    /// An AnimatedChessPiece is used to slowly move a piece from one square to another so it is seen by the user.
    /// </summary>
    public class AnimatedChessPiece
    {
        public ChessPiece ChessPiece { get; set; }
        public ChessSquare squareFrom { get; set; }
        public ChessSquare squareTo { get; set; }
        public float PercentComplete { get; set; }

        public AnimatedChessPiece(ChessPiece chessPiece, ChessSquare squareFrom, ChessSquare squareTo)
        {
            ChessPiece = chessPiece;
            this.squareFrom = squareFrom;
            this.squareTo = squareTo;
            PercentComplete = 0;
        }

        public RectangleF getRectForPercentComplete(KenDoubleBufferedPanel.KenPanel panelChessBoard, bool boardIsFlipped)
        {
            RectangleF rect = new RectangleF();
            int squareFromAdjustedFileIndex = boardIsFlipped ? 7 - squareFrom.fileIndex : squareFrom.fileIndex;
            int squareFromAdjustedRankIndex = boardIsFlipped ? 7 - squareFrom.rankIndex : squareFrom.rankIndex;
            int squareToAdjustedFileIndex = boardIsFlipped ? 7 - squareTo.fileIndex : squareTo.fileIndex;
            int squareToAdjustedRankIndex = boardIsFlipped ? 7 - squareTo.rankIndex : squareTo.rankIndex;

            float startCornerX = (squareFromAdjustedFileIndex) * ((float)panelChessBoard.Width / 8);
            float startCornerY = (float)panelChessBoard.Height - (squareFromAdjustedRankIndex + 1) * ((float)panelChessBoard.Height / 8);
            float endCornerX = (squareToAdjustedFileIndex) * ((float)panelChessBoard.Width / 8);
            float endCornerY = (float)panelChessBoard.Height - (squareToAdjustedRankIndex + 1) * ((float)panelChessBoard.Height / 8);
            float xDistance = endCornerX - startCornerX;
            float yDistance = endCornerY - startCornerY;

            rect.X = startCornerX + (PercentComplete * xDistance);
            rect.Y = startCornerY + (PercentComplete * yDistance);
            rect.Width = panelChessBoard.Width / 8;
            rect.Height = panelChessBoard.Height / 8;
            return rect;
        }
    }
}
