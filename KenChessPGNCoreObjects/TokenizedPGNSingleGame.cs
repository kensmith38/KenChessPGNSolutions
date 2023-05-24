using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenChessPGNCoreObjects
{
    // TokenizedPGNSingleGame: A list of PGNTokens for a single game.
    //    - Useful for creating a dictionary key-value pairs corresponding to the PGN tag section.
    public class TokenizedPGNSingleGame
    {
        public List<PGNToken> tokens;
        /// <summary>
        /// Constructor: Creates new TokenizedPGNSingleGame with empty list of tokens (caller will set the tokens).
        /// </summary>
        public TokenizedPGNSingleGame()
        {
            tokens = new List<PGNToken>();
        }
        /// <summary>
        /// Constructor: Creates new TokenizedPGNSingleGame given the rawPGNMultigameASCIItext and the desired game number.
        /// </summary>
        public TokenizedPGNSingleGame(string rawPGNMultigameASCIItext, int gameNumber)
        {
            List<TokenizedPGNSingleGame> listTokenizedPGNSingleGames = GetListTokenizedPGNSingleGames(rawPGNMultigameASCIItext);
            tokens = listTokenizedPGNSingleGames.ElementAt(gameNumber - 1).tokens;
        }
        /// <summary>
        /// Creates a dictionary for GameTags and passes back the reference to the index of the first movetext token.
        /// The indexFirstMovetextToken is useful for callers who need to know the starting index of the first movetext token.
        /// </summary>
        public Dictionary<string, string> CreateGameTagsDictionary(out int indexFirstMovetextToken)
        {
            indexFirstMovetextToken = 0;
            Dictionary<string, string> GameTags = new Dictionary<string, string>();
            int indexCurrentToken = 0;
            while (indexCurrentToken < tokens.Count)
            {
                PGNToken currentToken = tokens[indexCurrentToken];
                if (currentToken.tokenType != PGNTokenType.LeftBracketToken)
                {
                    // this helps keep track of indexFirstMovetextToken
                    indexCurrentToken++;
                    continue;
                }
                else
                {
                    // four consecutive tokens should be [ key content ]
                    if (tokens[indexCurrentToken + 3].tokenType != PGNTokenType.RightBracketToken)
                    {
                        throw new Exception("Error while parsing pgn tags!");
                    }
                    // the two tokens we deal with here are the tag name and tag value (tag value is wrapped in quotation marks so we strip them off)
                    string tagName = tokens[indexCurrentToken + 1].tokenContent;
                    string tagValue = tokens[indexCurrentToken + 2].tokenContent;
                    GameTags.Add(tagName, tagValue.Substring(1, tagValue.Length - 2));
                    indexCurrentToken += 4;
                    indexFirstMovetextToken = indexCurrentToken;
                }
            }
            return GameTags;
        }
        /// <summary>
        /// Get a list of TokenizedPGNSingleGames given the rawPGNMultigameASCIItext.
        /// </summary>
        public static List<TokenizedPGNSingleGame> GetListTokenizedPGNSingleGames(string rawPGNMultigameASCIItext)
        {
            List<PGNToken> tokenizedDataEntirePGNfile = PGNTokenizer.tokenizeDataFromRawPGNMultigameText(rawPGNMultigameASCIItext);
            List<TokenizedPGNSingleGame> listTokenizedPGNSingleGames = new List<TokenizedPGNSingleGame>();
            TokenizedPGNSingleGame tokenizedPGNSingleGame = new TokenizedPGNSingleGame();
            foreach (PGNToken pgnToken in tokenizedDataEntirePGNfile)
            {
                tokenizedPGNSingleGame.tokens.Add(pgnToken);
                if (pgnToken.tokenType == PGNTokenType.GameTerminationToken)
                {
                    listTokenizedPGNSingleGames.Add(tokenizedPGNSingleGame);
                    tokenizedPGNSingleGame = new TokenizedPGNSingleGame();
                }
            }
            return listTokenizedPGNSingleGames;
        }
    }
}
