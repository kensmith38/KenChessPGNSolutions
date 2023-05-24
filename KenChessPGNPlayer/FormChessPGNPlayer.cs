using KenChessPGNCoreObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
// Reference: https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/usercontrol-act-control-container-design-time
namespace KenChessPGNPlayer
{
    public partial class FormChessPGNPlayer : Form
    {
        // publisher for event (subscriber is FormDebugInfo)
        public event EventHandler<CustomEventArgs> RaiseChessBoardChanged;
        bool debugPerformance = true;
        public double TotalPaintTimeMillisec { get; set; } = 0;
        public int ctrPaints { get; set; } = 0;
        public bool AtLeastOneDebugWindowWasOpened { get; set; }
        public StructuredPGNGame StructuredPGNGame { get; set; }
        public RichTextViewer RichTextViewer { get; set; }
        public ChessBoard ChessBoard { get; set; }
        /// <summary>
        /// When the chess panel is painted, it also paints the AnimatedPiece
        /// </summary>
        public AnimatedChessPiece AnimatedChessPiece { get; set; }
        public StringFormat stringFormatForPaint = new StringFormat();
        
        public Font FontForPieces { get; set; }
        public Font FontForCoordinates { get; set; }
        // The ChessBoard should always reflect the status at CurrentChessMove (which is the current node in the StructuredPGNGame.OrderedListOfChessMoveNodes
        public ChessMoveNode CurrentChessMove { get; set; }
        public Color LightSquareColor { get; set; } = Color.White;
        public Color DarkSquareColor { get; set; } = Color.Turquoise;
        SolidBrush LightColorBrush;
        SolidBrush DarkColorBrush;
        // ConglomerateChessPieceImages is a rectangular grid of all the white/black piece images.  It is a resource, AlphaChessPieces.png.
        Image ConglomerateChessPieceImages { get; set; }
        public CachedImagesForPieces CachedImagesForPieces { get; set; }
        // need to avoid problems if user clicks move buttons too quickly
        public bool UserActionEnabled { get; set; } = true;
        // Pieces look nicer using images.  Pieces are displayed using Unicode font or images.
        public bool UseImagesForPieces { get; set; } = true;
        public FormChessPGNPlayer(StructuredPGNGame StructuredPGNGame)
        {
            InitializeComponent();
            this.StructuredPGNGame = StructuredPGNGame;
        }

        private void FormChessPGNPlayer_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                stringFormatForPaint.LineAlignment = StringAlignment.Center;
                stringFormatForPaint.Alignment = StringAlignment.Center;
                ConglomerateChessPieceImages = (Image)Properties.Resources.ResourceManager.GetObject("AlphaChessPieces");
                CachedImagesForPieces = new CachedImagesForPieces(ConglomerateChessPieceImages);
                //trackBarAnimationSpeed.Value = 20;
                populateGameTagInfo();
                LightColorBrush = new SolidBrush(LightSquareColor);
                DarkColorBrush = new SolidBrush(DarkSquareColor);
                //
                RichTextViewer = new RichTextViewer(StructuredPGNGame, richTextBoxShowingMoves);
                string currentFEN = UtilitiesFEN.GetInitialFENSetupFromGameTags(StructuredPGNGame.GameTags); 
                ChessBoard =  new ChessBoard(currentFEN);
                CurrentChessMove = null;
                // Publish event (subscriber is FormDebugInfo)
                OnRaiseChessBoardChanged(new CustomEventArgs(CurrentChessMove));
                FontForPieces = GetAdjustedFont(
                    panelChessBoard.CreateGraphics(), new ChessPiece('K').UnicodeCharForPiece.ToString(), this.Font, panelChessBoard.Width / 8, 36, 6, true);
                FontForCoordinates = new Font(this.Font.Name, 14);
                //
                panelBottomCoordinates.Invalidate();
                panelLeftCoordinates.Invalidate();
                panelChessBoard.Invalidate();
            }
            catch (Exception exc)
            {
                Constants.DisplayExceptionMessage(exc);
            }
            finally
            {
                Cursor.Current = Cursors.Arrow;
            }
        }
        // Publish events for Debug forms
        protected virtual void OnRaiseChessBoardChanged(CustomEventArgs customEventArgs)
        {
            RaiseChessBoardChanged?.Invoke(this, customEventArgs);
        }
        private void populateGameTagInfo()
        {
            textBoxGameTagEvent.Text = StructuredPGNGame.GameTags["Event"];
            textBoxGameTagDate.Text = StructuredPGNGame.GameTags["Date"];
            textBoxGameTagWhite.Text = StructuredPGNGame.GameTags["White"];
            textBoxGameTagBlack.Text = StructuredPGNGame.GameTags["Black"];
            textBoxGameTagResult.Text = StructuredPGNGame.GameTags["Result"];
        }
        // User action is asking to jump to specific move (node).
        private void richTextBoxShowingMoves_MouseDown(object sender, MouseEventArgs e)
        {
            // pass event to RichTextViewer which tells us the ChessMove that the user wants to jump to
            ChessMoveNode userRequestsJumpToChessMove = RichTextViewer.userMouseDownInRichTextBox(e);
            jumpToSpecificChessMove(userRequestsJumpToChessMove, null);
        }
        /// <summary>
        /// Update the ChessBoard based on the CurrentChessMove (currently selected node).
        /// </summary>
        private async void jumpToSpecificChessMove(ChessMoveNode chessMoveNode, AnimatedChessPiece animatedChessPiece)
        {
            // The GUI paints the chessboard using ChessBoard in the state corresponding to the specific move (node).
            if ((chessMoveNode != null) && (chessMoveNode.SANmove != null))
            {
                if (animatedChessPiece != null)
                {
                    // delay is related to animation speed
                    int delayMillisec = 20 * (trackBarAnimationSpeed.Maximum - trackBarAnimationSpeed.Value);
                    UserActionEnabled = false;
                    int ctrAnimatedFrames = 10;
                    for (int iii = 1; iii <= ctrAnimatedFrames; iii++)
                    {
                        await Task.Delay(delayMillisec);
                        AnimatedChessPiece.PercentComplete = (float)iii / ctrAnimatedFrames;
                        panelChessBoard.Invalidate();
                    }
                }
                UserActionEnabled = true;
                AnimatedChessPiece = null;
                ChessBoard =  new ChessBoard(chessMoveNode.FENPositionAfterChessMove);
                CurrentChessMove = chessMoveNode;
                // Publish event
                OnRaiseChessBoardChanged(new CustomEventArgs(CurrentChessMove));
                panelChessBoard.Invalidate();
                RichTextViewer.highlightCurrentMoveInRichText(CurrentChessMove);
            }
        }
        private void panelChessBoard_Paint(object sender, PaintEventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            if (debugPerformance) { stopwatch.Start(); }
            SolidBrush brush = LightColorBrush;
            int adjustedFileIndex;
            int adjustedRankIndex;
            float squareHeight = (float)panelChessBoard.Height / 8;
            float squareWidth = (float)panelChessBoard.Width / 8;
            RectangleF animatedPieceLayoutRect = new RectangleF();
            e.Graphics.Clear(LightColorBrush.Color);
            if (AnimatedChessPiece != null)
            {
                animatedPieceLayoutRect = AnimatedChessPiece.getRectForPercentComplete(panelChessBoard, checkBoxFlipBoard.Checked);
            }
            for (int fileIndex=0; fileIndex<8; fileIndex++)
            {
                for (int rankIndex=0; rankIndex<8; rankIndex++)
                {
                    ChessSquare chessSquare = ChessBoard.ChessBoardSquares[fileIndex, rankIndex];
                    adjustedFileIndex = checkBoxFlipBoard.Checked ? 7 - fileIndex : fileIndex;
                    adjustedRankIndex = checkBoxFlipBoard.Checked ? 7 - rankIndex : rankIndex;

                    float cornerX = (adjustedFileIndex) * (squareWidth);
                    float cornerY = (float)panelChessBoard.Height - (adjustedRankIndex + 1) * (squareHeight);
                    Rectangle destRect = new Rectangle((int)cornerX, (int)cornerY, (int)squareWidth, (int)squareHeight);
                    brush = (adjustedFileIndex + adjustedRankIndex) % 2 == 0 ? DarkColorBrush : LightColorBrush;
                    // Only color dark squares! We set whole background with Light color earlier!
                    if (brush == DarkColorBrush)
                    {
                        e.Graphics.FillRectangle(brush, destRect);
                    }
                    //
                    if (chessSquare.PieceOnSquare.PieceType != PieceType.None)
                    {
                        // put pieces on squares (except for animated square from)
                        if (UseImagesForPieces)
                        {
                            CachedImagesForPieces.CachedImages.TryGetValue(chessSquare.PieceOnSquare.FENCharForPiece, out Image pieceImage);
                            e.Graphics.DrawImage(pieceImage, destRect);
                            if ((AnimatedChessPiece != null) && (AnimatedChessPiece.squareFrom == chessSquare))
                            {
                                e.Graphics.FillRectangle(brush, destRect);
                            }
                        }
                        else
                        {
                            char pieceAsUnicodeChar = chessSquare.PieceOnSquare.UnicodeCharForPiece;
                            e.Graphics.DrawString(pieceAsUnicodeChar.ToString(), FontForPieces, Brushes.Black, destRect, stringFormatForPaint);
                        }
                    }
                }
                if (AnimatedChessPiece != null)
                {
                    if (UseImagesForPieces)
                    {
                        Rectangle destRect = new Rectangle((int)animatedPieceLayoutRect.X, (int)animatedPieceLayoutRect.Y, 
                            (int)animatedPieceLayoutRect.Width, (int)animatedPieceLayoutRect.Height);
                        CachedImagesForPieces.CachedImages.TryGetValue(AnimatedChessPiece.squareFrom.PieceOnSquare.FENCharForPiece, out Image pieceImage);
                        e.Graphics.DrawImage(pieceImage, destRect);
                    }
                    else
                    {
                        char pieceAsUnicodeChar = AnimatedChessPiece.ChessPiece.UnicodeCharForPiece;
                        e.Graphics.DrawString(pieceAsUnicodeChar.ToString(), FontForPieces, Brushes.Black, animatedPieceLayoutRect, stringFormatForPaint);
                    }
                }
            }
            if (debugPerformance)
            {
                stopwatch.Stop();
                ctrPaints++;
                TotalPaintTimeMillisec += stopwatch.Elapsed.TotalMilliseconds;
                var gunga1 = stopwatch.Elapsed.TotalMilliseconds;
                var gunga2 = stopwatch.ElapsedMilliseconds;
                stopwatch.Reset();
                textBoxCtrPaints.Text = ctrPaints.ToString();
                textBoxAvgElapsedTimeMillisec.Text = (TotalPaintTimeMillisec / ctrPaints).ToString("N0");
            }
        }

        private void panelLeftCoordinates_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(panelLeftCoordinates.BackColor);
            for (int rankLetterIndex = 0; rankLetterIndex < 8; rankLetterIndex++)
            {
                char letter = checkBoxFlipBoard.Checked ? "87654321"[7 - rankLetterIndex] : "87654321"[rankLetterIndex];
                float cornerX = 0;
                float cornerY = (rankLetterIndex) * ((float)panelLeftCoordinates.Height / 8); ;
                RectangleF layoutRect = new RectangleF(cornerX, cornerY, panelLeftCoordinates.Width, panelLeftCoordinates.Height / 8);

                // put pieces on squares
                e.Graphics.DrawString(letter.ToString(), FontForCoordinates, Brushes.Black, layoutRect, stringFormatForPaint);
            }
        }
        private void panelBottomCoordinates_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(panelBottomCoordinates.BackColor);
            for (int fileLetterIndex = 0; fileLetterIndex < 8; fileLetterIndex++)
            {
                char letter = checkBoxFlipBoard.Checked ? "abcdefgh"[7 - fileLetterIndex] : "abcdefgh"[fileLetterIndex];
                float cornerX = (fileLetterIndex) * ((float)panelBottomCoordinates.Width / 8);
                float cornerY = 0;
                RectangleF layoutRect = new RectangleF(cornerX, cornerY, panelBottomCoordinates.Width / 8, panelBottomCoordinates.Height);

                // put pieces on squares
                e.Graphics.DrawString(letter.ToString(), FontForCoordinates, Brushes.Black, layoutRect, stringFormatForPaint);
            }
        }
        private void buttonGoToStart_Click(object sender, EventArgs e)
        {
            AnimatedChessPiece = null;
            string fenInitialSetup = UtilitiesFEN.GetInitialFENSetupFromGameTags(StructuredPGNGame.GameTags);
            ChessBoard = new ChessBoard(fenInitialSetup);
            CurrentChessMove = null; 
            // Publish event
            OnRaiseChessBoardChanged(new CustomEventArgs(CurrentChessMove));
            panelChessBoard.Invalidate();
            RichTextViewer.highlightCurrentMoveInRichText(CurrentChessMove);
        }

        private void buttonBackOneMove_Click(object sender, EventArgs e)
        {
            if (UserActionEnabled == false) { return; }
            if ((CurrentChessMove == null) || (CurrentChessMove.ParentChessMove == null))
            {
                buttonGoToStart_Click(null, null);
            }
            else
            {
                jumpToSpecificChessMove(CurrentChessMove.ParentChessMove, null);
            }
        }

        private void buttonForwardOneMove_Click(object sender, EventArgs e)
        {
            if (UserActionEnabled == false) { return; }
            if (CurrentChessMove == null) 
            {
                jumpToSpecificChessMove(StructuredPGNGame.OrderedListOfChessMoveNodes[0], null);
            }
            else
            {
                if (CurrentChessMove.ChildMoveVariations.Count > 0)
                {
                    string uciMove = UtilitiesConvertPgnSANtoUCI.ConvertPgnSANtoUCI(ChessBoard, CurrentChessMove.ChildMoveVariations[0].SANmove);
                    // uciMove is null at last move
                    if (uciMove != null)
                    {
                        ChessSquare squareFrom = ChessBoard.getChessSquareWithUciName(uciMove.Substring(0, 2));
                        ChessSquare squareTo = ChessBoard.getChessSquareWithUciName(uciMove.Substring(2, 2));
                        ChessPiece chessPiece = squareFrom.PieceOnSquare;
                        // Handle pawn promotion
                        if (uciMove.Length == 5)
                        {
                            chessPiece = new ChessPiece(uciMove[4]);
                            // Tricky! Pawn promotion is weird in UCI... Uppercase Q can mean either black or white queen!
                            chessPiece.PieceColor = squareTo.UciSquareName.EndsWith("1") ? 'b' : 'w';
                        }
                        AnimatedChessPiece = new AnimatedChessPiece(chessPiece, squareFrom, squareTo);
                        jumpToSpecificChessMove(CurrentChessMove.ChildMoveVariations[0], AnimatedChessPiece);
                    }
                }
            }
        }

        private void buttonGoToEnd_Click(object sender, EventArgs e)
        {
            jumpToSpecificChessMove(StructuredPGNGame.OrderedListOfChessMoveNodes.Last().ParentChessMove, null);
        }

        private void checkBoxFlipBoard_CheckedChanged(object sender, EventArgs e)
        {
            panelChessBoard.Invalidate();
            panelLeftCoordinates.Invalidate();
            panelBottomCoordinates.Invalidate();
        }
        
        private void trackBarAnimationSpeed_Scroll(object sender, EventArgs e)
        {

        }

        private void buttonOpenDebugWindow_Click(object sender, EventArgs e)
        {
            AtLeastOneDebugWindowWasOpened = true;
            FormDebugInfo frm = new FormDebugInfo(this, StructuredPGNGame);
            frm.Show();
            // Publish event
            OnRaiseChessBoardChanged(new CustomEventArgs(CurrentChessMove));
        }

        private void FormChessPGNPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AtLeastOneDebugWindowWasOpened)
            {
                string infomssg = "You should close any 'Debug' windows that are associated with this game.";
                Constants.DisplayInfoMessage(infomssg);
            }
        }

        private void checkBoxUseImagesForPieces_CheckedChanged(object sender, EventArgs e)
        {
            UseImagesForPieces = !UseImagesForPieces;
            panelChessBoard.Invalidate();
        }

        private void buttonResetElapsedTime_Click(object sender, EventArgs e)
        {
            ctrPaints = 0;
            TotalPaintTimeMillisec = 0;
            textBoxCtrPaints.Clear();
            textBoxAvgElapsedTimeMillisec.Clear();
        }
        /// <summary>
        /// Adjusts a Font to ensure text fits in specified rectangle.  Min and max fontsize must be specified.
        /// Does not consider height of text!
        /// </summary>
        /// <param name="g"></param>
        /// <param name="graphicString"></param>
        /// <param name="originalFont"></param>
        /// <param name="containerWidth"></param>
        /// <param name="maxFontSize"></param>
        /// <param name="minFontSize"></param>
        /// <param name="smallestOnFail"></param>
        /// <returns></returns>
        public static Font GetAdjustedFont(Graphics g, string graphicString, Font originalFont, int containerWidth, int maxFontSize, int minFontSize, bool smallestOnFail)
        {
            Font testFont = null;
            // We utilize MeasureString which we get via a control instance           
            for (int adjustedSize = maxFontSize; adjustedSize >= minFontSize; adjustedSize--)
            {
                testFont = new Font(originalFont.Name, adjustedSize, originalFont.Style);

                // Test the string with the new size
                SizeF adjustedSizeNew = g.MeasureString(graphicString, testFont);

                if (containerWidth > Convert.ToInt32(adjustedSizeNew.Width))
                {
                    // Good font, return it
                    return testFont;
                }
            }

            // If you get here there was no fontsize that worked
            // return minimumSize or original?
            if (smallestOnFail)
            {
                return testFont;
            }
            else
            {
                return originalFont;
            }
        }
    }
    public class CustomEventArgs : EventArgs
    {
        public ChessMoveNode chessMoveNode;
        public CustomEventArgs(ChessMoveNode chessMoveNode) 
        { 
            this.chessMoveNode = chessMoveNode;
        }
    }
}
