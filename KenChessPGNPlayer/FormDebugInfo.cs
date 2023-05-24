using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KenChessPGNCoreObjects;

namespace KenChessPGNPlayer
{
    public partial class FormDebugInfo : Form
    {
        ChessMoveNode CurrentChessMoveNode;
        StructuredPGNGame StructuredPGNGame;
        //
        FormChessPGNPlayer Publisher;
        public FormDebugInfo(FormChessPGNPlayer publisher, StructuredPGNGame StructuredPGNGame)
        {
            InitializeComponent();
            this.StructuredPGNGame = StructuredPGNGame;
            Publisher = publisher;
        }

        private void FormDebugInfo_Load(object sender, EventArgs e)
        {
            Publisher.RaiseChessBoardChanged += HandleChessBoardChangedEvent;
        }
        private void HandleChessBoardChangedEvent(object sender, CustomEventArgs customEventArgs)
        {
            CurrentChessMoveNode = customEventArgs.chessMoveNode;
            refreshScreen();
        }
        private void refreshScreen()
        {
            textBoxDebugBlackCanCastleLong.Clear();
            textBoxDebugBlackCanCastleShort.Clear();
            textBoxDebugWhiteCanCastleLong.Clear();
            textBoxDebugWhiteCanCastleShort.Clear();
            textBoxDebugLastMoveSAN.Clear();
            textBoxDebugLastMoveUCI.Clear();
            textBoxDebugLastMoveTextBeforeMove.Clear();
            textBoxDebugLastMoveTextAfterMove.Clear();
            textBoxDebugActivePlayerColor.Clear();
            textBoxDebugLastMoveColor.Clear();
            textBoxDebugEnPassantSquare.Clear();
            textBoxDebugPlayerIsInCheck.Clear();
            dataGridView1.Rows.Clear();
            
            string FENPositionForActivePlayer = CurrentChessMoveNode == null ?
                UtilitiesFEN.GetInitialFENSetupFromGameTags(StructuredPGNGame.GameTags) : 
                CurrentChessMoveNode.FENPositionAfterChessMove;
            CastlingRights castlingRights = new CastlingRights(FENPositionForActivePlayer);
            textBoxDebugWhiteCanCastleLong.Text = castlingRights.WhiteKingCanCastleLong ? "Y" : "N";
            textBoxDebugWhiteCanCastleShort.Text = castlingRights.WhiteKingCanCastleShort ? "Y" : "N";
            textBoxDebugBlackCanCastleLong.Text = castlingRights.BlackKingCanCastleLong ? "Y" : "N";
            textBoxDebugBlackCanCastleShort.Text = castlingRights.BlackKingCanCastleShort ? "Y" : "N";

            if (CurrentChessMoveNode != null)
            {
                textBoxDebugLastMoveSAN.Text = CurrentChessMoveNode.SANmove;
                textBoxDebugLastMoveUCI.Text = CurrentChessMoveNode.UCImove;
                textBoxDebugLastMoveTextBeforeMove.Text = CurrentChessMoveNode.TextBeforeMove;
                textBoxDebugLastMoveTextAfterMove.Text = CurrentChessMoveNode.TextAfterMove;
            }

            string activePlayerMoveColor = UtilitiesFEN.GetActivePlayerFromFEN(FENPositionForActivePlayer);
            textBoxDebugActivePlayerColor.Text = activePlayerMoveColor;
            if (CurrentChessMoveNode != null)
            {
                textBoxDebugLastMoveColor.Text = activePlayerMoveColor.Equals("w") ? "b" : "w";
            }

            textBoxDebugEnPassantSquare.Text = UtilitiesFEN.GetEnPassantSquareFromFEN(FENPositionForActivePlayer);
            ChessBoard chessBoard = new ChessBoard(FENPositionForActivePlayer);
            textBoxDebugPlayerIsInCheck.Text = UtilitiesActivePlayerInCheck.isActivePlayerInCheck(chessBoard) ? "Y" : "N";
            performDisplayLegalMoves(chessBoard);
        }
        private void performDisplayLegalMoves(ChessBoard chessBoard)
        {
            dataGridView1.Rows.Clear();
            char pieceFilter = '*';
            if (radioButtonDebugFilterKing.Checked) { pieceFilter = 'K'; }
            else if (radioButtonDebugFilterQueen.Checked) { pieceFilter = 'Q'; }
            else if (radioButtonDebugFilterBishop.Checked) { pieceFilter = 'B'; }
            else if (radioButtonDebugFilterKnight.Checked) { pieceFilter = 'N'; }
            else if (radioButtonDebugFilterRook.Checked) { pieceFilter = 'R'; }
            else if (radioButtonDebugFilterPawn.Checked) { pieceFilter = 'P'; }

            List<string> listLegalUciMoves = UtilitiesLegalUCIMoves.getAllLegalUciMovesForActivePlayer(chessBoard, pieceFilter);
            foreach (string uciMove in listLegalUciMoves)
            {
                DataGridViewRow dgvrow = dataGridView1.Rows[dataGridView1.Rows.Add()];
                dgvrow.Cells[Column_Debug_UciMove.Index].Value = uciMove;
                ChessPiece chessPiece = chessBoard.getChessSquareWithUciName(uciMove).PieceOnSquare;
                string chessPieceBeingMoved = chessPiece.FENCharForPiece.ToString();
                if (chessPiece.PieceType == PieceType.King)
                {
                    if (uciMove.Equals("e1g1")) { chessPieceBeingMoved = "O-O"; }
                    if (uciMove.Equals("e8g8")) { chessPieceBeingMoved = "O-O"; }
                    if (uciMove.Equals("e1c1")) { chessPieceBeingMoved = "O-O-O"; }
                    if (uciMove.Equals("e1c8")) { chessPieceBeingMoved = "O-O-O"; }
                }
                dgvrow.Cells[Column_Debug_PieceType.Index].Value = chessPieceBeingMoved;
            }
        }

        private void radioButtonDebugFilterAnyPieces_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                refreshScreen();
            }
        }

        private void FormDebugInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Publisher.RaiseChessBoardChanged -= HandleChessBoardChangedEvent;
        }
    }
}
