using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KenChessPGNCoreObjects;
namespace KenChessPGNPlayer
{
    public partial class FormListGames : Form
    {
        public string RawPGNMultiGameContent { get; set; }
        public FormListGames()
        {
            InitializeComponent();
        }

        private void FormListGames_Load(object sender, EventArgs e)
        {
            version1004ToolStripMenuItem.Text = Constants.VersionInfo;
            // taller rows for button 
            dataGridViewListGames.RowTemplate.Height = 26;
        }

        private void loadPGNFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var fileContent = string.Empty;
                var filePath = string.Empty;

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    openFileDialog.Filter = "pgn files (*.pgn)|*.pgn|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;

                        //Read the contents of the file into a stream
                        var fileStream = openFileDialog.OpenFile();

                        using (StreamReader reader = new StreamReader(fileStream))
                        {
                            fileContent = reader.ReadToEnd();
                        }
                    }
                }
                RawPGNMultiGameContent = fileContent;
                populateListOfGames();
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
        private void pastePGNFromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                RawPGNMultiGameContent = Clipboard.GetText();
                populateListOfGames();
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
        private void loadSampleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RawPGNMultiGameContent = SamplePGN.SampleGame1;
            populateListOfGames();
        }
        private void populateListOfGames()
        {
            List<GameInfo> listGameInfo = GameInfo.GetListGameInfo(RawPGNMultiGameContent);
            int gameNumber = 1;
            dataGridViewListGames.Rows.Clear();

            foreach (GameInfo gameInfo in listGameInfo)
            {
                DataGridViewRow dgvrow = dataGridViewListGames.Rows[dataGridViewListGames.Rows.Add()];
                string pgnEvent = gameInfo.Event;
                string pgnDate = gameInfo.Date;
                string pgnWhite = gameInfo.White;
                string pgnBlack = gameInfo.Black;
                string pgnResult = gameInfo.Result;

                dgvrow.Cells[Column_ListGames_GameNumber.Index].Value = gameNumber;
                dgvrow.Cells[Column_ListGames_Event.Index].Value = pgnEvent;
                dgvrow.Cells[Column_ListGames_Date.Index].Value = pgnDate;
                dgvrow.Cells[Column_ListGames_Black.Index].Value = pgnBlack;
                dgvrow.Cells[Column_ListGames_White.Index].Value = pgnWhite;
                dgvrow.Cells[Column_ListGames_Result.Index].Value = pgnResult;
                gameNumber++;
            }
            textBoxCtrGames.Text = (gameNumber - 1).ToString();
        }
        private void dataGridViewListGames_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (e.ColumnIndex == Column_ListGames_LoadGame.Index)
                {
                    DataGridViewRow dgvrow = dataGridViewListGames.Rows[e.RowIndex];
                    int gameNumber = (int)dgvrow.Cells[Column_ListGames_GameNumber.Index].Value;
                    StructuredPGNGame structuredPGNGame =new StructuredPGNGame(RawPGNMultiGameContent, gameNumber);

                    FormChessPGNPlayer formChessPGNPlayer = new FormChessPGNPlayer(structuredPGNGame);
                    formChessPGNPlayer.Show();
                }
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
    }
}
