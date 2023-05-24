using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenChessPGNCoreObjects
{
    public class GameInfo
    {
        // nth game in the rawPGNMultigameASCIItext
        public int GameNumber { get; set; }
        public string Event { get; set; }
        public string Date { get; set; }
        public string White { get; set; }
        public string Black { get; set; }
        public string Result { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public GameInfo(int gameNumber, string Event, string Date, string White, string Black, string Result) 
        { 
            this.GameNumber = gameNumber;
            this.Event = Event;
            this.Date = Date;
            this.White = White;
            this.Black = Black;
            this.Result = Result;
        }
        /// <summary>
        /// Get a list of games (GameInfo objects) from rawMultigameASCIIContent.
        /// The list can be displayed to the user, perhaps in a DataGridView, and the desired game number can be selected by the user.
        /// </summary>
        public static List<GameInfo> GetListGameInfo(string rawMultigameASCIIContent)
        {
            List<GameInfo> listGames = new List<GameInfo>();
            // Start by getting listTokenizedPGNSingleGame
            List<TokenizedPGNSingleGame> listTokenizedPGNSingleGame = TokenizedPGNSingleGame.GetListTokenizedPGNSingleGames(rawMultigameASCIIContent);
            int gameNumber = 1;

            foreach (TokenizedPGNSingleGame tokenizedPGNSingleGame in listTokenizedPGNSingleGame)
            {
                int indexFirstMovetextToken = 0;
                Dictionary<string, string> GameTags = tokenizedPGNSingleGame.CreateGameTagsDictionary(out indexFirstMovetextToken);
                string pgnEvent = GameTags.ContainsKey("Event") ? GameTags["Event"] : "?";
                string pgnDate = GameTags.ContainsKey("Date") ? GameTags["Date"] : "?";
                string pgnWhite = GameTags.ContainsKey("White") ? GameTags["White"] : "?";
                string pgnBlack = GameTags.ContainsKey("Black") ? GameTags["Black"] : "?";
                string pgnResult = GameTags.ContainsKey("Result") ? GameTags["Result"] : "?";
                GameInfo gameInfo = new GameInfo(gameNumber, pgnEvent, pgnDate, pgnWhite, pgnBlack, pgnResult);
                listGames.Add(gameInfo);
                gameNumber++;
            }
            return listGames;
        }
    }
}
