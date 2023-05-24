namespace KenChessPGNPlayer
{
    partial class FormChessPGNPlayer
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
            this.panelGameTags = new System.Windows.Forms.Panel();
            this.textBoxGameTagResult = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxGameTagDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxGameTagBlack = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxGameTagWhite = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxGameTagEvent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBoxShowingMoves = new System.Windows.Forms.RichTextBox();
            this.checkBoxFlipBoard = new System.Windows.Forms.CheckBox();
            this.panelBottomCoordinates = new System.Windows.Forms.Panel();
            this.panelLeftCoordinates = new System.Windows.Forms.Panel();
            this.panelChessBoard = new KenDoubleBufferedPanel.KenPanel();
            this.trackBarAnimationSpeed = new System.Windows.Forms.TrackBar();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonGoToEnd = new System.Windows.Forms.Button();
            this.buttonBackOneMove = new System.Windows.Forms.Button();
            this.buttonForwardOneMove = new System.Windows.Forms.Button();
            this.buttonGoToStart = new System.Windows.Forms.Button();
            this.buttonOpenDebugWindow = new System.Windows.Forms.Button();
            this.textBoxCtrPaints = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxAvgElapsedTimeMillisec = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBoxUseImagesForPieces = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonResetElapsedTime = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.panelGameTags.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAnimationSpeed)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGameTags
            // 
            this.panelGameTags.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGameTags.Controls.Add(this.textBoxGameTagResult);
            this.panelGameTags.Controls.Add(this.label6);
            this.panelGameTags.Controls.Add(this.textBoxGameTagDate);
            this.panelGameTags.Controls.Add(this.label5);
            this.panelGameTags.Controls.Add(this.textBoxGameTagBlack);
            this.panelGameTags.Controls.Add(this.label4);
            this.panelGameTags.Controls.Add(this.textBoxGameTagWhite);
            this.panelGameTags.Controls.Add(this.label3);
            this.panelGameTags.Controls.Add(this.textBoxGameTagEvent);
            this.panelGameTags.Controls.Add(this.label2);
            this.panelGameTags.Location = new System.Drawing.Point(691, 57);
            this.panelGameTags.Name = "panelGameTags";
            this.panelGameTags.Size = new System.Drawing.Size(416, 161);
            this.panelGameTags.TabIndex = 24;
            // 
            // textBoxGameTagResult
            // 
            this.textBoxGameTagResult.Location = new System.Drawing.Point(74, 119);
            this.textBoxGameTagResult.Name = "textBoxGameTagResult";
            this.textBoxGameTagResult.ReadOnly = true;
            this.textBoxGameTagResult.Size = new System.Drawing.Size(191, 20);
            this.textBoxGameTagResult.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Result";
            // 
            // textBoxGameTagDate
            // 
            this.textBoxGameTagDate.Location = new System.Drawing.Point(74, 15);
            this.textBoxGameTagDate.Name = "textBoxGameTagDate";
            this.textBoxGameTagDate.ReadOnly = true;
            this.textBoxGameTagDate.Size = new System.Drawing.Size(191, 20);
            this.textBoxGameTagDate.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Date:";
            // 
            // textBoxGameTagBlack
            // 
            this.textBoxGameTagBlack.Location = new System.Drawing.Point(74, 93);
            this.textBoxGameTagBlack.Name = "textBoxGameTagBlack";
            this.textBoxGameTagBlack.ReadOnly = true;
            this.textBoxGameTagBlack.Size = new System.Drawing.Size(300, 20);
            this.textBoxGameTagBlack.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Black:";
            // 
            // textBoxGameTagWhite
            // 
            this.textBoxGameTagWhite.Location = new System.Drawing.Point(74, 67);
            this.textBoxGameTagWhite.Name = "textBoxGameTagWhite";
            this.textBoxGameTagWhite.ReadOnly = true;
            this.textBoxGameTagWhite.Size = new System.Drawing.Size(300, 20);
            this.textBoxGameTagWhite.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "White:";
            // 
            // textBoxGameTagEvent
            // 
            this.textBoxGameTagEvent.Location = new System.Drawing.Point(74, 41);
            this.textBoxGameTagEvent.Name = "textBoxGameTagEvent";
            this.textBoxGameTagEvent.ReadOnly = true;
            this.textBoxGameTagEvent.Size = new System.Drawing.Size(300, 20);
            this.textBoxGameTagEvent.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Event:";
            // 
            // richTextBoxShowingMoves
            // 
            this.richTextBoxShowingMoves.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxShowingMoves.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxShowingMoves.Location = new System.Drawing.Point(691, 224);
            this.richTextBoxShowingMoves.Name = "richTextBoxShowingMoves";
            this.richTextBoxShowingMoves.Size = new System.Drawing.Size(700, 553);
            this.richTextBoxShowingMoves.TabIndex = 21;
            this.richTextBoxShowingMoves.Text = "";
            this.richTextBoxShowingMoves.MouseDown += new System.Windows.Forms.MouseEventHandler(this.richTextBoxShowingMoves_MouseDown);
            // 
            // checkBoxFlipBoard
            // 
            this.checkBoxFlipBoard.AutoSize = true;
            this.checkBoxFlipBoard.Location = new System.Drawing.Point(537, 33);
            this.checkBoxFlipBoard.Name = "checkBoxFlipBoard";
            this.checkBoxFlipBoard.Size = new System.Drawing.Size(72, 17);
            this.checkBoxFlipBoard.TabIndex = 31;
            this.checkBoxFlipBoard.Text = "Flip board";
            this.checkBoxFlipBoard.UseVisualStyleBackColor = true;
            this.checkBoxFlipBoard.CheckedChanged += new System.EventHandler(this.checkBoxFlipBoard_CheckedChanged);
            // 
            // panelBottomCoordinates
            // 
            this.panelBottomCoordinates.Location = new System.Drawing.Point(37, 691);
            this.panelBottomCoordinates.Name = "panelBottomCoordinates";
            this.panelBottomCoordinates.Size = new System.Drawing.Size(630, 26);
            this.panelBottomCoordinates.TabIndex = 32;
            this.panelBottomCoordinates.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBottomCoordinates_Paint);
            // 
            // panelLeftCoordinates
            // 
            this.panelLeftCoordinates.Location = new System.Drawing.Point(5, 55);
            this.panelLeftCoordinates.Name = "panelLeftCoordinates";
            this.panelLeftCoordinates.Size = new System.Drawing.Size(26, 630);
            this.panelLeftCoordinates.TabIndex = 33;
            this.panelLeftCoordinates.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLeftCoordinates_Paint);
            // 
            // panelChessBoard
            // 
            this.panelChessBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelChessBoard.Location = new System.Drawing.Point(37, 55);
            this.panelChessBoard.Name = "panelChessBoard";
            this.panelChessBoard.Size = new System.Drawing.Size(630, 630);
            this.panelChessBoard.TabIndex = 35;
            this.panelChessBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.panelChessBoard_Paint);
            // 
            // trackBarAnimationSpeed
            // 
            this.trackBarAnimationSpeed.LargeChange = 1;
            this.trackBarAnimationSpeed.Location = new System.Drawing.Point(548, 726);
            this.trackBarAnimationSpeed.Name = "trackBarAnimationSpeed";
            this.trackBarAnimationSpeed.Size = new System.Drawing.Size(104, 45);
            this.trackBarAnimationSpeed.TabIndex = 36;
            this.trackBarAnimationSpeed.Value = 9;
            this.trackBarAnimationSpeed.Scroll += new System.EventHandler(this.trackBarAnimationSpeed_Scroll);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(550, 774);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(117, 13);
            this.label12.TabIndex = 37;
            this.label12.Text = "Piece animation speed:";
            // 
            // buttonGoToEnd
            // 
            this.buttonGoToEnd.BackgroundImage = global::KenChessPGNPlayer.Properties.Resources.Nav_GoToEnd;
            this.buttonGoToEnd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonGoToEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGoToEnd.Location = new System.Drawing.Point(434, 723);
            this.buttonGoToEnd.Name = "buttonGoToEnd";
            this.buttonGoToEnd.Size = new System.Drawing.Size(84, 54);
            this.buttonGoToEnd.TabIndex = 28;
            this.buttonGoToEnd.UseVisualStyleBackColor = true;
            this.buttonGoToEnd.Click += new System.EventHandler(this.buttonGoToEnd_Click);
            // 
            // buttonBackOneMove
            // 
            this.buttonBackOneMove.BackgroundImage = global::KenChessPGNPlayer.Properties.Resources.Nav_GoBackOneMove;
            this.buttonBackOneMove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonBackOneMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBackOneMove.Location = new System.Drawing.Point(275, 723);
            this.buttonBackOneMove.Name = "buttonBackOneMove";
            this.buttonBackOneMove.Size = new System.Drawing.Size(54, 54);
            this.buttonBackOneMove.TabIndex = 27;
            this.buttonBackOneMove.UseVisualStyleBackColor = true;
            this.buttonBackOneMove.Click += new System.EventHandler(this.buttonBackOneMove_Click);
            // 
            // buttonForwardOneMove
            // 
            this.buttonForwardOneMove.BackgroundImage = global::KenChessPGNPlayer.Properties.Resources.Nav_GoForwardOneMove;
            this.buttonForwardOneMove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonForwardOneMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonForwardOneMove.Location = new System.Drawing.Point(358, 723);
            this.buttonForwardOneMove.Name = "buttonForwardOneMove";
            this.buttonForwardOneMove.Size = new System.Drawing.Size(54, 54);
            this.buttonForwardOneMove.TabIndex = 26;
            this.buttonForwardOneMove.UseVisualStyleBackColor = true;
            this.buttonForwardOneMove.Click += new System.EventHandler(this.buttonForwardOneMove_Click);
            // 
            // buttonGoToStart
            // 
            this.buttonGoToStart.BackgroundImage = global::KenChessPGNPlayer.Properties.Resources.Nav_GoToStart;
            this.buttonGoToStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonGoToStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGoToStart.Location = new System.Drawing.Point(159, 723);
            this.buttonGoToStart.Name = "buttonGoToStart";
            this.buttonGoToStart.Size = new System.Drawing.Size(84, 54);
            this.buttonGoToStart.TabIndex = 25;
            this.buttonGoToStart.UseVisualStyleBackColor = true;
            this.buttonGoToStart.Click += new System.EventHandler(this.buttonGoToStart_Click);
            // 
            // buttonOpenDebugWindow
            // 
            this.buttonOpenDebugWindow.Location = new System.Drawing.Point(691, 30);
            this.buttonOpenDebugWindow.Name = "buttonOpenDebugWindow";
            this.buttonOpenDebugWindow.Size = new System.Drawing.Size(142, 23);
            this.buttonOpenDebugWindow.TabIndex = 38;
            this.buttonOpenDebugWindow.Text = "Open Debug Window";
            this.buttonOpenDebugWindow.UseVisualStyleBackColor = true;
            this.buttonOpenDebugWindow.Click += new System.EventHandler(this.buttonOpenDebugWindow_Click);
            // 
            // textBoxCtrPaints
            // 
            this.textBoxCtrPaints.Location = new System.Drawing.Point(144, 35);
            this.textBoxCtrPaints.Name = "textBoxCtrPaints";
            this.textBoxCtrPaints.ReadOnly = true;
            this.textBoxCtrPaints.Size = new System.Drawing.Size(53, 20);
            this.textBoxCtrPaints.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Number of paints:";
            // 
            // textBoxAvgElapsedTimeMillisec
            // 
            this.textBoxAvgElapsedTimeMillisec.Location = new System.Drawing.Point(144, 61);
            this.textBoxAvgElapsedTimeMillisec.Name = "textBoxAvgElapsedTimeMillisec";
            this.textBoxAvgElapsedTimeMillisec.ReadOnly = true;
            this.textBoxAvgElapsedTimeMillisec.Size = new System.Drawing.Size(53, 20);
            this.textBoxAvgElapsedTimeMillisec.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Avg elapsed time (ms):";
            // 
            // checkBoxUseImagesForPieces
            // 
            this.checkBoxUseImagesForPieces.AutoSize = true;
            this.checkBoxUseImagesForPieces.Checked = true;
            this.checkBoxUseImagesForPieces.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUseImagesForPieces.Location = new System.Drawing.Point(537, 10);
            this.checkBoxUseImagesForPieces.Name = "checkBoxUseImagesForPieces";
            this.checkBoxUseImagesForPieces.Size = new System.Drawing.Size(130, 17);
            this.checkBoxUseImagesForPieces.TabIndex = 43;
            this.checkBoxUseImagesForPieces.Text = "Use images for pieces";
            this.checkBoxUseImagesForPieces.UseVisualStyleBackColor = true;
            this.checkBoxUseImagesForPieces.CheckedChanged += new System.EventHandler(this.checkBoxUseImagesForPieces_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonResetElapsedTime);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.textBoxCtrPaints);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxAvgElapsedTimeMillisec);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(1122, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(223, 151);
            this.panel1.TabIndex = 44;
            // 
            // buttonResetElapsedTime
            // 
            this.buttonResetElapsedTime.Location = new System.Drawing.Point(81, 105);
            this.buttonResetElapsedTime.Name = "buttonResetElapsedTime";
            this.buttonResetElapsedTime.Size = new System.Drawing.Size(75, 23);
            this.buttonResetElapsedTime.TabIndex = 44;
            this.buttonResetElapsedTime.Text = "Reset";
            this.buttonResetElapsedTime.UseVisualStyleBackColor = true;
            this.buttonResetElapsedTime.Click += new System.EventHandler(this.buttonResetElapsedTime_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(46, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "Debug elapsed paint time";
            // 
            // FormChessPGNPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1434, 811);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBoxUseImagesForPieces);
            this.Controls.Add(this.buttonOpenDebugWindow);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.trackBarAnimationSpeed);
            this.Controls.Add(this.panelChessBoard);
            this.Controls.Add(this.panelLeftCoordinates);
            this.Controls.Add(this.panelBottomCoordinates);
            this.Controls.Add(this.checkBoxFlipBoard);
            this.Controls.Add(this.buttonGoToEnd);
            this.Controls.Add(this.buttonBackOneMove);
            this.Controls.Add(this.buttonForwardOneMove);
            this.Controls.Add(this.buttonGoToStart);
            this.Controls.Add(this.panelGameTags);
            this.Controls.Add(this.richTextBoxShowingMoves);
            this.Name = "FormChessPGNPlayer";
            this.Text = "Ken\'s Chess PGN Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormChessPGNPlayer_FormClosing);
            this.Load += new System.EventHandler(this.FormChessPGNPlayer_Load);
            this.panelGameTags.ResumeLayout(false);
            this.panelGameTags.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAnimationSpeed)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelGameTags;
        private System.Windows.Forms.TextBox textBoxGameTagResult;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxGameTagDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxGameTagBlack;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxGameTagWhite;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxGameTagEvent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBoxShowingMoves;
        private System.Windows.Forms.Button buttonGoToStart;
        private System.Windows.Forms.Button buttonForwardOneMove;
        private System.Windows.Forms.Button buttonBackOneMove;
        private System.Windows.Forms.Button buttonGoToEnd;
        private System.Windows.Forms.CheckBox checkBoxFlipBoard;
        private System.Windows.Forms.Panel panelBottomCoordinates;
        private System.Windows.Forms.Panel panelLeftCoordinates;
        private KenDoubleBufferedPanel.KenPanel panelChessBoard;
        private System.Windows.Forms.TrackBar trackBarAnimationSpeed;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonOpenDebugWindow;
        private System.Windows.Forms.TextBox textBoxCtrPaints;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxAvgElapsedTimeMillisec;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBoxUseImagesForPieces;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonResetElapsedTime;
    }
}