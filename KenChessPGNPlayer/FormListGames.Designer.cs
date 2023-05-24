namespace KenChessPGNPlayer
{
    partial class FormListGames
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBoxCtrGames = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewListGames = new System.Windows.Forms.DataGridView();
            this.Column_ListGames_GameNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ListGames_Event = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ListGames_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ListGames_White = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ListGames_Black = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ListGames_Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ListGames_LoadGame = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadPGNFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pastePGNFromClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.loadSampleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionNnnnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.version1004ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListGames)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxCtrGames
            // 
            this.textBoxCtrGames.Location = new System.Drawing.Point(599, 93);
            this.textBoxCtrGames.Name = "textBoxCtrGames";
            this.textBoxCtrGames.ReadOnly = true;
            this.textBoxCtrGames.Size = new System.Drawing.Size(75, 20);
            this.textBoxCtrGames.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(500, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Number of games:";
            // 
            // dataGridViewListGames
            // 
            this.dataGridViewListGames.AllowUserToAddRows = false;
            this.dataGridViewListGames.AllowUserToDeleteRows = false;
            this.dataGridViewListGames.AllowUserToResizeRows = false;
            this.dataGridViewListGames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewListGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListGames.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_ListGames_GameNumber,
            this.Column_ListGames_Event,
            this.Column_ListGames_Date,
            this.Column_ListGames_White,
            this.Column_ListGames_Black,
            this.Column_ListGames_Result,
            this.Column_ListGames_LoadGame});
            this.dataGridViewListGames.Location = new System.Drawing.Point(12, 116);
            this.dataGridViewListGames.Name = "dataGridViewListGames";
            this.dataGridViewListGames.ReadOnly = true;
            this.dataGridViewListGames.RowHeadersVisible = false;
            this.dataGridViewListGames.Size = new System.Drawing.Size(685, 433);
            this.dataGridViewListGames.TabIndex = 23;
            this.dataGridViewListGames.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewListGames_CellContentClick);
            // 
            // Column_ListGames_GameNumber
            // 
            this.Column_ListGames_GameNumber.HeaderText = "Game #";
            this.Column_ListGames_GameNumber.Name = "Column_ListGames_GameNumber";
            this.Column_ListGames_GameNumber.ReadOnly = true;
            this.Column_ListGames_GameNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_ListGames_GameNumber.Width = 60;
            // 
            // Column_ListGames_Event
            // 
            this.Column_ListGames_Event.HeaderText = "Event";
            this.Column_ListGames_Event.Name = "Column_ListGames_Event";
            this.Column_ListGames_Event.ReadOnly = true;
            // 
            // Column_ListGames_Date
            // 
            this.Column_ListGames_Date.HeaderText = "Date";
            this.Column_ListGames_Date.Name = "Column_ListGames_Date";
            this.Column_ListGames_Date.ReadOnly = true;
            // 
            // Column_ListGames_White
            // 
            this.Column_ListGames_White.HeaderText = "White";
            this.Column_ListGames_White.Name = "Column_ListGames_White";
            this.Column_ListGames_White.ReadOnly = true;
            // 
            // Column_ListGames_Black
            // 
            this.Column_ListGames_Black.HeaderText = "Black";
            this.Column_ListGames_Black.Name = "Column_ListGames_Black";
            this.Column_ListGames_Black.ReadOnly = true;
            // 
            // Column_ListGames_Result
            // 
            this.Column_ListGames_Result.HeaderText = "Result";
            this.Column_ListGames_Result.Name = "Column_ListGames_Result";
            this.Column_ListGames_Result.ReadOnly = true;
            // 
            // Column_ListGames_LoadGame
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Column_ListGames_LoadGame.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column_ListGames_LoadGame.HeaderText = "Load game...";
            this.Column_ListGames_LoadGame.Name = "Column_ListGames_LoadGame";
            this.Column_ListGames_LoadGame.ReadOnly = true;
            this.Column_ListGames_LoadGame.Text = "Load game...";
            this.Column_ListGames_LoadGame.UseColumnTextForButtonValue = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 24);
            this.label1.TabIndex = 22;
            this.label1.Text = "List of games in PGN file";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.versionNnnnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(744, 24);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadPGNFileToolStripMenuItem,
            this.pastePGNFromClipboardToolStripMenuItem,
            this.toolStripSeparator1,
            this.loadSampleToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadPGNFileToolStripMenuItem
            // 
            this.loadPGNFileToolStripMenuItem.Name = "loadPGNFileToolStripMenuItem";
            this.loadPGNFileToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.loadPGNFileToolStripMenuItem.Text = "Load PGN file";
            this.loadPGNFileToolStripMenuItem.Click += new System.EventHandler(this.loadPGNFileToolStripMenuItem_Click);
            // 
            // pastePGNFromClipboardToolStripMenuItem
            // 
            this.pastePGNFromClipboardToolStripMenuItem.Name = "pastePGNFromClipboardToolStripMenuItem";
            this.pastePGNFromClipboardToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.pastePGNFromClipboardToolStripMenuItem.Text = "Paste PGN from clipboard";
            this.pastePGNFromClipboardToolStripMenuItem.Click += new System.EventHandler(this.pastePGNFromClipboardToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(208, 6);
            // 
            // loadSampleToolStripMenuItem
            // 
            this.loadSampleToolStripMenuItem.Name = "loadSampleToolStripMenuItem";
            this.loadSampleToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.loadSampleToolStripMenuItem.Text = "Load sample";
            this.loadSampleToolStripMenuItem.Click += new System.EventHandler(this.loadSampleToolStripMenuItem_Click);
            // 
            // versionNnnnToolStripMenuItem
            // 
            this.versionNnnnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.version1004ToolStripMenuItem});
            this.versionNnnnToolStripMenuItem.Name = "versionNnnnToolStripMenuItem";
            this.versionNnnnToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.versionNnnnToolStripMenuItem.Text = "About";
            // 
            // version1004ToolStripMenuItem
            // 
            this.version1004ToolStripMenuItem.Name = "version1004ToolStripMenuItem";
            this.version1004ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.version1004ToolStripMenuItem.Text = "Version n.n.n.n";
            // 
            // FormListGames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 561);
            this.Controls.Add(this.textBoxCtrGames);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewListGames);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormListGames";
            this.Text = "KenChessPGNPlayer";
            this.Load += new System.EventHandler(this.FormListGames_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListGames)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCtrGames;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewListGames;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ListGames_GameNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ListGames_Event;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ListGames_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ListGames_White;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ListGames_Black;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ListGames_Result;
        private System.Windows.Forms.DataGridViewButtonColumn Column_ListGames_LoadGame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadPGNFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pastePGNFromClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem loadSampleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionNnnnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem version1004ToolStripMenuItem;
    }
}

