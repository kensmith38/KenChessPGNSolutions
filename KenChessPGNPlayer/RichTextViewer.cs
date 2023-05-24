using KenChessPGNCoreObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KenChessPGNPlayer
{
    public class RichTextViewer
    {
        public RichTextBox RichTextBox { get; set; }
        StructuredPGNGame StructuredPGNGame { get; set; }
        public List<MapItemForRichText> mapItems { get; set; }
        // The MapItemForCurrentlyHighlightedChessMove helps us highlight and un-highlight moves in the RichTextBox as current move changes.
        public MapItemForRichText MapItemForCurrentlyHighlightedChessMove { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public RichTextViewer(StructuredPGNGame structuredPGNGame, RichTextBox rtb) 
        { 
            StructuredPGNGame = structuredPGNGame;
            RichTextBox = rtb;
            mapItems = new List<MapItemForRichText>();
            generateRichTextFromListChessMoveNodes();
            RichTextBox.SelectionStart = 0;
            RichTextBox.SelectionLength = 0;
            RichTextBox.ScrollToCaret();
        }
        public void generateRichTextFromListChessMoveNodes()
        {
            int prevVariationDepth = 0;
            Font boldFont = new Font(RichTextBox.Font, FontStyle.Bold);
            RichTextBox.Clear();
            int currentRichTextPos = 0;
            foreach (ChessMoveNode chessMove in StructuredPGNGame.OrderedListOfChessMoveNodes)
            {
                MapItemForRichText mapItem = new MapItemForRichText();
                mapItem.ChessMove = chessMove;
                mapItem.StartPosition = currentRichTextPos;
                if ((chessMove.MoveVariationDepth == prevVariationDepth) && (chessMove.TextBeforeMove.StartsWith("(")))
                {
                    RichTextBox.AppendText("\n");
                    RichTextBox.SelectionIndent = 20 * chessMove.MoveVariationDepth;
                }
                if (chessMove.MoveVariationDepth != prevVariationDepth)
                {
                    RichTextBox.AppendText("\n");
                    RichTextBox.SelectionIndent = 20 * chessMove.MoveVariationDepth;
                }
                if (chessMove.TextBeforeMove.Length > 0)
                {
                    RichTextBox.SelectionColor = Color.Blue;
                    RichTextBox.SelectionFont = RichTextBox.Font;
                    RichTextBox.AppendText(chessMove.TextBeforeMove.Trim() + " ");
                }
                if (chessMove.FriendlyMoveNumber.Length > 0)
                {
                    RichTextBox.SelectionColor = Color.Black;
                    RichTextBox.SelectionFont = (chessMove.MoveVariationDepth == 0) ? boldFont : RichTextBox.Font;
                    RichTextBox.AppendText(chessMove.FriendlyMoveNumber);
                    // TODO Maybe? Insert blank space after multiple periods of FriendlyMoveNumber
                    RichTextBox.AppendText(" ");
                    /*
                    if (chessMove.FriendlyMoveNumber.EndsWith(".."))
                    {
                        RichTextBox.AppendText(" ");
                    }
                    */
                }
                if (chessMove.SANmove != null)
                {
                    RichTextBox.SelectionColor = Color.Black;
                    RichTextBox.SelectionFont = (chessMove.MoveVariationDepth == 0) ? boldFont : RichTextBox.Font;
                    RichTextBox.AppendText(chessMove.SANmove);
                }
                RichTextBox.SelectionFont = RichTextBox.Font;
                if (chessMove.TextAfterMove.Length > 0)
                {
                    RichTextBox.SelectionColor = Color.Blue;
                    RichTextBox.SelectionFont = RichTextBox.Font;
                    RichTextBox.AppendText(" " + chessMove.TextAfterMove.Trim());
                }
                RichTextBox.AppendText("  ");
                prevVariationDepth = chessMove.MoveVariationDepth;
                mapItem.EndPosition = RichTextBox.Text.Length;
                mapItems.Add(mapItem);
                currentRichTextPos = mapItem.EndPosition;
            }
        }
        public ChessMoveNode userMouseDownInRichTextBox(MouseEventArgs e)
        {
            ChessMoveNode chessMove = null;
            // Make sure this is a left mouse button and single click.
            if (e.Clicks == 1 && e.Button == MouseButtons.Left)
            {
                if (StructuredPGNGame != null)
                {
                    // Obtain the character index where the user clicks on the control.
                    int clickedPosition = RichTextBox.GetCharIndexFromPosition(new Point(e.X, e.Y));
                    if (clickedPosition <= RichTextBox.Text.Length)
                    {
                        //char characterClicked = richTextBoxShowingMoves.Text.Length > clickedPosition ? richTextBoxShowingMoves.Text[clickedPosition] : '~';
                        //Constants.DisplayInfoMessage($"Clicked position {clickedPosition.ToString()}; char={characterClicked}");
                        chessMove = GetChessMove(clickedPosition);
                        //Constants.DisplayInfoMessage($"Clicked SAN: {chessMove.SANmove}");
                        if (chessMove.SANmove != null)
                        {
                            highlightCurrentMoveInRichText(chessMove);
                        }
                    }
                }
            }
            return chessMove;
        }
        public void highlightCurrentMoveInRichText(ChessMoveNode chessMove)
        {
            MapItemForRichText mapItem = GetMapItem(chessMove);
            if (mapItem != null)
            {
                // Remove highlight from last move
                if (MapItemForCurrentlyHighlightedChessMove != null)
                {
                    RichTextBox.Select(MapItemForCurrentlyHighlightedChessMove.StartPosition,
                        (MapItemForCurrentlyHighlightedChessMove.EndPosition - MapItemForCurrentlyHighlightedChessMove.StartPosition));
                    RichTextBox.SelectionBackColor = Color.White;
                }
                // Tricky! We want to highlight SAN but not the comments before or after the SAN of the ChessMove
                int highlightStart = RichTextBox.Find(chessMove.SANmove,
                    mapItem.StartPosition, mapItem.EndPosition, RichTextBoxFinds.WholeWord);
                int highlightEnd = highlightStart + chessMove.SANmove.Length;
                RichTextBox.Select(highlightStart, highlightEnd - highlightStart);
                RichTextBox.SelectionBackColor = Color.PaleGreen;
                MapItemForCurrentlyHighlightedChessMove = mapItem;
                RichTextBox.Select(mapItem.StartPosition, 0);
            }
            else
            {
                // Remove highlight from last move
                if (MapItemForCurrentlyHighlightedChessMove != null)
                {
                    RichTextBox.Select(MapItemForCurrentlyHighlightedChessMove.StartPosition,
                        (MapItemForCurrentlyHighlightedChessMove.EndPosition - MapItemForCurrentlyHighlightedChessMove.StartPosition));
                    RichTextBox.SelectionBackColor = Color.White;
                }
                RichTextBox.Select(0, 0);
                MapItemForCurrentlyHighlightedChessMove = null;
            }
        }
        /// <summary>
        /// Gets the ChessMove corresponding to the position specified in RichText.
        /// </summary>
        /// <param name="richtextPosition"></param>
        /// <returns></returns>
        public ChessMoveNode GetChessMove(int richtextPosition)
        {
            ChessMoveNode chessMove = null;
            foreach (MapItemForRichText mapItem in mapItems)
            {
                if ((mapItem.StartPosition <= richtextPosition) && (mapItem.EndPosition >= richtextPosition))
                {
                    chessMove = mapItem.ChessMove;
                    break;
                }
            }
            return chessMove;
        }
        /// <summary>
        /// Gets the MapItem corresponding to the specific chessMove.
        /// </summary>
        /// <param name="chessMove"></param>
        /// <returns></returns>
        public MapItemForRichText GetMapItem(ChessMoveNode chessMove)
        {
            MapItemForRichText desiredMapItem = null;
            foreach (MapItemForRichText mapItem in mapItems)
            {
                if (mapItem.ChessMove == chessMove)
                {
                    desiredMapItem = mapItem;
                    break;
                }
            }
            return desiredMapItem;
        }
    }
    public class MapItemForRichText
    {
        public int StartPosition { get; set; }
        public int EndPosition { get; set; }
        public ChessMoveNode ChessMove { get; set; }
        public MapItemForRichText()
        {
            StartPosition = 0;
            EndPosition = 0;
            ChessMove = null; ;
        }
    }
}
