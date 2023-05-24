namespace KenChessPGNPlayer
{
    partial class FormDebugInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxDebugBlackCanCastleShort = new System.Windows.Forms.TextBox();
            this.textBoxDebugBlackCanCastleLong = new System.Windows.Forms.TextBox();
            this.textBoxDebugWhiteCanCastleShort = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxDebugWhiteCanCastleLong = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxDebugLastMoveSAN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDebugLastMoveColor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDebugLastMoveUCI = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxDebugActivePlayerColor = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxDebugPlayerIsInCheck = new System.Windows.Forms.TextBox();
            this.textBoxDebugEnPassantSquare = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonDebugFilterRook = new System.Windows.Forms.RadioButton();
            this.radioButtonDebugFilterAllPieces = new System.Windows.Forms.RadioButton();
            this.radioButtonDebugFilterPawn = new System.Windows.Forms.RadioButton();
            this.radioButtonDebugFilterKnight = new System.Windows.Forms.RadioButton();
            this.radioButtonDebugFilterBishop = new System.Windows.Forms.RadioButton();
            this.radioButtonDebugFilterQueen = new System.Windows.Forms.RadioButton();
            this.radioButtonDebugFilterKing = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column_Debug_UciMove = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Debug_PieceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxDebugLastMoveTextBeforeMove = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxDebugLastMoveTextAfterMove = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Debug Info";
            // 
            // textBoxDebugBlackCanCastleShort
            // 
            this.textBoxDebugBlackCanCastleShort.Location = new System.Drawing.Point(147, 78);
            this.textBoxDebugBlackCanCastleShort.Name = "textBoxDebugBlackCanCastleShort";
            this.textBoxDebugBlackCanCastleShort.ReadOnly = true;
            this.textBoxDebugBlackCanCastleShort.Size = new System.Drawing.Size(23, 20);
            this.textBoxDebugBlackCanCastleShort.TabIndex = 30;
            // 
            // textBoxDebugBlackCanCastleLong
            // 
            this.textBoxDebugBlackCanCastleLong.Location = new System.Drawing.Point(110, 78);
            this.textBoxDebugBlackCanCastleLong.Name = "textBoxDebugBlackCanCastleLong";
            this.textBoxDebugBlackCanCastleLong.ReadOnly = true;
            this.textBoxDebugBlackCanCastleLong.Size = new System.Drawing.Size(23, 20);
            this.textBoxDebugBlackCanCastleLong.TabIndex = 29;
            // 
            // textBoxDebugWhiteCanCastleShort
            // 
            this.textBoxDebugWhiteCanCastleShort.Location = new System.Drawing.Point(147, 52);
            this.textBoxDebugWhiteCanCastleShort.Name = "textBoxDebugWhiteCanCastleShort";
            this.textBoxDebugWhiteCanCastleShort.ReadOnly = true;
            this.textBoxDebugWhiteCanCastleShort.Size = new System.Drawing.Size(23, 20);
            this.textBoxDebugWhiteCanCastleShort.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Black can castle:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(144, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Short";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(107, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Long";
            // 
            // textBoxDebugWhiteCanCastleLong
            // 
            this.textBoxDebugWhiteCanCastleLong.Location = new System.Drawing.Point(110, 52);
            this.textBoxDebugWhiteCanCastleLong.Name = "textBoxDebugWhiteCanCastleLong";
            this.textBoxDebugWhiteCanCastleLong.ReadOnly = true;
            this.textBoxDebugWhiteCanCastleLong.Size = new System.Drawing.Size(23, 20);
            this.textBoxDebugWhiteCanCastleLong.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "White can castle:";
            // 
            // textBoxDebugLastMoveSAN
            // 
            this.textBoxDebugLastMoveSAN.Location = new System.Drawing.Point(132, 65);
            this.textBoxDebugLastMoveSAN.Name = "textBoxDebugLastMoveSAN";
            this.textBoxDebugLastMoveSAN.ReadOnly = true;
            this.textBoxDebugLastMoveSAN.Size = new System.Drawing.Size(82, 20);
            this.textBoxDebugLastMoveSAN.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Last move PGN (SAN):";
            // 
            // textBoxDebugLastMoveColor
            // 
            this.textBoxDebugLastMoveColor.Location = new System.Drawing.Point(132, 39);
            this.textBoxDebugLastMoveColor.Name = "textBoxDebugLastMoveColor";
            this.textBoxDebugLastMoveColor.ReadOnly = true;
            this.textBoxDebugLastMoveColor.Size = new System.Drawing.Size(30, 20);
            this.textBoxDebugLastMoveColor.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Last move color:";
            // 
            // textBoxDebugLastMoveUCI
            // 
            this.textBoxDebugLastMoveUCI.Location = new System.Drawing.Point(333, 65);
            this.textBoxDebugLastMoveUCI.Name = "textBoxDebugLastMoveUCI";
            this.textBoxDebugLastMoveUCI.ReadOnly = true;
            this.textBoxDebugLastMoveUCI.Size = new System.Drawing.Size(82, 20);
            this.textBoxDebugLastMoveUCI.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(241, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Last move (UCI):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Current castling rights";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.textBoxDebugWhiteCanCastleLong);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.textBoxDebugBlackCanCastleShort);
            this.panel1.Controls.Add(this.textBoxDebugWhiteCanCastleShort);
            this.panel1.Controls.Add(this.textBoxDebugBlackCanCastleLong);
            this.panel1.Location = new System.Drawing.Point(287, 256);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 117);
            this.panel1.TabIndex = 36;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.textBoxDebugActivePlayerColor);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.textBoxDebugPlayerIsInCheck);
            this.panel2.Controls.Add(this.textBoxDebugEnPassantSquare);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(24, 198);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(502, 551);
            this.panel2.TabIndex = 37;
            // 
            // textBoxDebugActivePlayerColor
            // 
            this.textBoxDebugActivePlayerColor.Location = new System.Drawing.Point(385, 22);
            this.textBoxDebugActivePlayerColor.Name = "textBoxDebugActivePlayerColor";
            this.textBoxDebugActivePlayerColor.ReadOnly = true;
            this.textBoxDebugActivePlayerColor.Size = new System.Drawing.Size(30, 20);
            this.textBoxDebugActivePlayerColor.TabIndex = 40;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(282, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 13);
            this.label13.TabIndex = 39;
            this.label13.Text = "Active player color:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(337, 425);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 36;
            this.label12.Text = "In check:";
            // 
            // textBoxDebugPlayerIsInCheck
            // 
            this.textBoxDebugPlayerIsInCheck.Location = new System.Drawing.Point(395, 422);
            this.textBoxDebugPlayerIsInCheck.Name = "textBoxDebugPlayerIsInCheck";
            this.textBoxDebugPlayerIsInCheck.ReadOnly = true;
            this.textBoxDebugPlayerIsInCheck.Size = new System.Drawing.Size(23, 20);
            this.textBoxDebugPlayerIsInCheck.TabIndex = 37;
            // 
            // textBoxDebugEnPassantSquare
            // 
            this.textBoxDebugEnPassantSquare.Location = new System.Drawing.Point(395, 396);
            this.textBoxDebugEnPassantSquare.Name = "textBoxDebugEnPassantSquare";
            this.textBoxDebugEnPassantSquare.ReadOnly = true;
            this.textBoxDebugEnPassantSquare.Size = new System.Drawing.Size(78, 20);
            this.textBoxDebugEnPassantSquare.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(288, 399);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "En Passant Square:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.radioButtonDebugFilterRook);
            this.groupBox1.Controls.Add(this.radioButtonDebugFilterAllPieces);
            this.groupBox1.Controls.Add(this.radioButtonDebugFilterPawn);
            this.groupBox1.Controls.Add(this.radioButtonDebugFilterKnight);
            this.groupBox1.Controls.Add(this.radioButtonDebugFilterBishop);
            this.groupBox1.Controls.Add(this.radioButtonDebugFilterQueen);
            this.groupBox1.Controls.Add(this.radioButtonDebugFilterKing);
            this.groupBox1.Location = new System.Drawing.Point(287, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(113, 202);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter by piece";
            // 
            // radioButtonDebugFilterRook
            // 
            this.radioButtonDebugFilterRook.AutoSize = true;
            this.radioButtonDebugFilterRook.Location = new System.Drawing.Point(27, 143);
            this.radioButtonDebugFilterRook.Name = "radioButtonDebugFilterRook";
            this.radioButtonDebugFilterRook.Size = new System.Drawing.Size(51, 17);
            this.radioButtonDebugFilterRook.TabIndex = 6;
            this.radioButtonDebugFilterRook.Text = "Rook";
            this.radioButtonDebugFilterRook.UseVisualStyleBackColor = true;
            this.radioButtonDebugFilterRook.CheckedChanged += new System.EventHandler(this.radioButtonDebugFilterAnyPieces_CheckedChanged);
            // 
            // radioButtonDebugFilterAllPieces
            // 
            this.radioButtonDebugFilterAllPieces.AutoSize = true;
            this.radioButtonDebugFilterAllPieces.Checked = true;
            this.radioButtonDebugFilterAllPieces.Location = new System.Drawing.Point(27, 28);
            this.radioButtonDebugFilterAllPieces.Name = "radioButtonDebugFilterAllPieces";
            this.radioButtonDebugFilterAllPieces.Size = new System.Drawing.Size(36, 17);
            this.radioButtonDebugFilterAllPieces.TabIndex = 5;
            this.radioButtonDebugFilterAllPieces.TabStop = true;
            this.radioButtonDebugFilterAllPieces.Text = "All";
            this.radioButtonDebugFilterAllPieces.UseVisualStyleBackColor = true;
            this.radioButtonDebugFilterAllPieces.CheckedChanged += new System.EventHandler(this.radioButtonDebugFilterAnyPieces_CheckedChanged);
            // 
            // radioButtonDebugFilterPawn
            // 
            this.radioButtonDebugFilterPawn.AutoSize = true;
            this.radioButtonDebugFilterPawn.Location = new System.Drawing.Point(27, 166);
            this.radioButtonDebugFilterPawn.Name = "radioButtonDebugFilterPawn";
            this.radioButtonDebugFilterPawn.Size = new System.Drawing.Size(52, 17);
            this.radioButtonDebugFilterPawn.TabIndex = 4;
            this.radioButtonDebugFilterPawn.Text = "Pawn";
            this.radioButtonDebugFilterPawn.UseVisualStyleBackColor = true;
            this.radioButtonDebugFilterPawn.CheckedChanged += new System.EventHandler(this.radioButtonDebugFilterAnyPieces_CheckedChanged);
            // 
            // radioButtonDebugFilterKnight
            // 
            this.radioButtonDebugFilterKnight.AutoSize = true;
            this.radioButtonDebugFilterKnight.Location = new System.Drawing.Point(27, 120);
            this.radioButtonDebugFilterKnight.Name = "radioButtonDebugFilterKnight";
            this.radioButtonDebugFilterKnight.Size = new System.Drawing.Size(55, 17);
            this.radioButtonDebugFilterKnight.TabIndex = 3;
            this.radioButtonDebugFilterKnight.Text = "Knight";
            this.radioButtonDebugFilterKnight.UseVisualStyleBackColor = true;
            this.radioButtonDebugFilterKnight.CheckedChanged += new System.EventHandler(this.radioButtonDebugFilterAnyPieces_CheckedChanged);
            // 
            // radioButtonDebugFilterBishop
            // 
            this.radioButtonDebugFilterBishop.AutoSize = true;
            this.radioButtonDebugFilterBishop.Location = new System.Drawing.Point(27, 97);
            this.radioButtonDebugFilterBishop.Name = "radioButtonDebugFilterBishop";
            this.radioButtonDebugFilterBishop.Size = new System.Drawing.Size(57, 17);
            this.radioButtonDebugFilterBishop.TabIndex = 2;
            this.radioButtonDebugFilterBishop.Text = "Bishop";
            this.radioButtonDebugFilterBishop.UseVisualStyleBackColor = true;
            this.radioButtonDebugFilterBishop.CheckedChanged += new System.EventHandler(this.radioButtonDebugFilterAnyPieces_CheckedChanged);
            // 
            // radioButtonDebugFilterQueen
            // 
            this.radioButtonDebugFilterQueen.AutoSize = true;
            this.radioButtonDebugFilterQueen.Location = new System.Drawing.Point(27, 74);
            this.radioButtonDebugFilterQueen.Name = "radioButtonDebugFilterQueen";
            this.radioButtonDebugFilterQueen.Size = new System.Drawing.Size(57, 17);
            this.radioButtonDebugFilterQueen.TabIndex = 1;
            this.radioButtonDebugFilterQueen.Text = "Queen";
            this.radioButtonDebugFilterQueen.UseVisualStyleBackColor = true;
            this.radioButtonDebugFilterQueen.CheckedChanged += new System.EventHandler(this.radioButtonDebugFilterAnyPieces_CheckedChanged);
            // 
            // radioButtonDebugFilterKing
            // 
            this.radioButtonDebugFilterKing.AutoSize = true;
            this.radioButtonDebugFilterKing.Location = new System.Drawing.Point(27, 51);
            this.radioButtonDebugFilterKing.Name = "radioButtonDebugFilterKing";
            this.radioButtonDebugFilterKing.Size = new System.Drawing.Size(46, 17);
            this.radioButtonDebugFilterKing.TabIndex = 0;
            this.radioButtonDebugFilterKing.Text = "King";
            this.radioButtonDebugFilterKing.UseVisualStyleBackColor = true;
            this.radioButtonDebugFilterKing.CheckedChanged += new System.EventHandler(this.radioButtonDebugFilterAnyPieces_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Debug_UciMove,
            this.Column_Debug_PieceType});
            this.dataGridView1.Location = new System.Drawing.Point(29, 48);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(236, 486);
            this.dataGridView1.TabIndex = 16;
            // 
            // Column_Debug_UciMove
            // 
            this.Column_Debug_UciMove.HeaderText = "UCI move";
            this.Column_Debug_UciMove.Name = "Column_Debug_UciMove";
            this.Column_Debug_UciMove.ReadOnly = true;
            // 
            // Column_Debug_PieceType
            // 
            this.Column_Debug_PieceType.HeaderText = "Piece";
            this.Column_Debug_PieceType.Name = "Column_Debug_PieceType";
            this.Column_Debug_PieceType.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(212, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Legal moves for active player";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.textBoxDebugLastMoveTextAfterMove);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.textBoxDebugLastMoveTextBeforeMove);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.textBoxDebugLastMoveUCI);
            this.panel3.Controls.Add(this.textBoxDebugLastMoveSAN);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.textBoxDebugLastMoveColor);
            this.panel3.Location = new System.Drawing.Point(24, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(502, 148);
            this.panel3.TabIndex = 38;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(4, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(158, 16);
            this.label14.TabIndex = 35;
            this.label14.Text = "Last move information";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(33, 94);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 13);
            this.label15.TabIndex = 36;
            this.label15.Text = "Text before move:";
            // 
            // textBoxDebugLastMoveTextBeforeMove
            // 
            this.textBoxDebugLastMoveTextBeforeMove.Location = new System.Drawing.Point(132, 91);
            this.textBoxDebugLastMoveTextBeforeMove.Name = "textBoxDebugLastMoveTextBeforeMove";
            this.textBoxDebugLastMoveTextBeforeMove.ReadOnly = true;
            this.textBoxDebugLastMoveTextBeforeMove.Size = new System.Drawing.Size(355, 20);
            this.textBoxDebugLastMoveTextBeforeMove.TabIndex = 37;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(42, 120);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(84, 13);
            this.label16.TabIndex = 38;
            this.label16.Text = "Text after move:";
            // 
            // textBoxDebugLastMoveTextAfterMove
            // 
            this.textBoxDebugLastMoveTextAfterMove.Location = new System.Drawing.Point(132, 117);
            this.textBoxDebugLastMoveTextAfterMove.Name = "textBoxDebugLastMoveTextAfterMove";
            this.textBoxDebugLastMoveTextAfterMove.ReadOnly = true;
            this.textBoxDebugLastMoveTextAfterMove.Size = new System.Drawing.Size(355, 20);
            this.textBoxDebugLastMoveTextAfterMove.TabIndex = 39;
            // 
            // FormDebugInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 761);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label7);
            this.Name = "FormDebugInfo";
            this.Text = "FormDebugInfo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDebugInfo_FormClosing);
            this.Load += new System.EventHandler(this.FormDebugInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxDebugBlackCanCastleShort;
        private System.Windows.Forms.TextBox textBoxDebugBlackCanCastleLong;
        private System.Windows.Forms.TextBox textBoxDebugWhiteCanCastleShort;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxDebugWhiteCanCastleLong;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxDebugLastMoveSAN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDebugLastMoveColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDebugLastMoveUCI;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonDebugFilterRook;
        private System.Windows.Forms.RadioButton radioButtonDebugFilterAllPieces;
        private System.Windows.Forms.RadioButton radioButtonDebugFilterPawn;
        private System.Windows.Forms.RadioButton radioButtonDebugFilterKnight;
        private System.Windows.Forms.RadioButton radioButtonDebugFilterBishop;
        private System.Windows.Forms.RadioButton radioButtonDebugFilterQueen;
        private System.Windows.Forms.RadioButton radioButtonDebugFilterKing;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Debug_UciMove;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Debug_PieceType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxDebugEnPassantSquare;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxDebugPlayerIsInCheck;
        private System.Windows.Forms.TextBox textBoxDebugActivePlayerColor;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBoxDebugLastMoveTextAfterMove;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxDebugLastMoveTextBeforeMove;
        private System.Windows.Forms.Label label14;
    }
}