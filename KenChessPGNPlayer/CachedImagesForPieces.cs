using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace KenChessPGNPlayer
{
    public class CachedImagesForPieces
    {
        public Dictionary<char,Image> CachedImages { get; set; } = new Dictionary<char, Image>();
        public CachedImagesForPieces(Image ConglomerateChessPieceImages) 
        {
            Image WhiteKing =   CreateImageForPieceFromConglomerateImage('K', ConglomerateChessPieceImages);
            Image WhiteQueen =  CreateImageForPieceFromConglomerateImage('Q', ConglomerateChessPieceImages);
            Image WhiteRook =   CreateImageForPieceFromConglomerateImage('R', ConglomerateChessPieceImages);
            Image WhiteBishop = CreateImageForPieceFromConglomerateImage('B', ConglomerateChessPieceImages);
            Image WhiteKnight = CreateImageForPieceFromConglomerateImage('N', ConglomerateChessPieceImages);
            Image WhitePawn =   CreateImageForPieceFromConglomerateImage('P', ConglomerateChessPieceImages);
            //
            Image BlackKing =   CreateImageForPieceFromConglomerateImage('k', ConglomerateChessPieceImages);
            Image BlackQueen =  CreateImageForPieceFromConglomerateImage('q', ConglomerateChessPieceImages);
            Image BlackRook =   CreateImageForPieceFromConglomerateImage('r', ConglomerateChessPieceImages);
            Image BlackBishop = CreateImageForPieceFromConglomerateImage('b', ConglomerateChessPieceImages);
            Image BlackKnight = CreateImageForPieceFromConglomerateImage('n', ConglomerateChessPieceImages);
            Image BlackPawn =   CreateImageForPieceFromConglomerateImage('p', ConglomerateChessPieceImages);

            CachedImages.Add('K', WhiteKing);
            CachedImages.Add('Q', WhiteQueen);
            CachedImages.Add('R', WhiteRook);
            CachedImages.Add('B', WhiteBishop);
            CachedImages.Add('N', WhiteKnight);
            CachedImages.Add('P', WhitePawn);
            //
            CachedImages.Add('k', BlackKing);
            CachedImages.Add('q', BlackQueen);
            CachedImages.Add('r', BlackRook);
            CachedImages.Add('b', BlackBishop);
            CachedImages.Add('n', BlackKnight);
            CachedImages.Add('p', BlackPawn);
        }
        private static Image CreateImageForPieceFromConglomerateImage(char chessPieceFENchar, Image ConglomerateChessPieceImages)
        {
            Image pieceImage = null;
            Rectangle srcRect = GetRectangleForPieceInConglomerateImage(chessPieceFENchar,ConglomerateChessPieceImages);
            pieceImage = new Bitmap(srcRect.Width, srcRect.Height);
            using (Graphics graphics = Graphics.FromImage(pieceImage))
            {
                graphics.DrawImage(ConglomerateChessPieceImages, new Rectangle(0,0,pieceImage.Width,pieceImage.Height), srcRect, GraphicsUnit.Pixel);
            }
            return pieceImage;
        }
        /// <summary>
        /// Gets rectangle for specific image (based on chessPieceFENchar) in the ConglomerateChessPieceImages
        /// </summary>
        private static Rectangle GetRectangleForPieceInConglomerateImage(char chessPieceFENchar, Image ConglomerateChessPieceImages)
        {
            Rectangle rect = new Rectangle();
            // The conglomerate image has 2 rows of 6 pieces (top row is white pieces)
            rect.Width = ConglomerateChessPieceImages.Width / 6;
            rect.Height = ConglomerateChessPieceImages.Height / 2;
            switch (chessPieceFENchar)
            {
                case 'K': rect.X = 0 * rect.Width; rect.Y = 0; break;
                case 'Q': rect.X = 1 * rect.Width; rect.Y = 0; break;
                case 'B': rect.X = 2 * rect.Width; rect.Y = 0; break;
                case 'N': rect.X = 3 * rect.Width; rect.Y = 0; break;
                case 'R': rect.X = 4 * rect.Width; rect.Y = 0; break;
                case 'P': rect.X = 5 * rect.Width; rect.Y = 0; break;
                case 'k': rect.X = 0 * rect.Width; rect.Y = rect.Height; break;
                case 'q': rect.X = 1 * rect.Width; rect.Y = rect.Height; break;
                case 'b': rect.X = 2 * rect.Width; rect.Y = rect.Height; break;
                case 'n': rect.X = 3 * rect.Width; rect.Y = rect.Height; break;
                case 'r': rect.X = 4 * rect.Width; rect.Y = rect.Height; break;
                case 'p': rect.X = 5 * rect.Width; rect.Y = rect.Height; break;
                default:
                    rect.X = 0; rect.Y = 0; rect.Width = 1; rect.Height = 1;
                    break;
            }
            return rect;
        }
    }
}
