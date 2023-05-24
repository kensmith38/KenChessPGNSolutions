using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenChessPGNCoreObjects
{
    public static class PGNTokenizer
    {
        public const string lettersAndDigits = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        /*
         * Design: The first step in reading a pgn file (or similar content on Clipboard) is to map the input stream as a stream of tokens.
         * Consider this method, getTokenizedData, as the lexer which creates the stream of tokens.
         * The tokens are defined in the Standard: Portable Game Notation Specification and Implementation Guide
         * */
        /// <summary>
        /// Tokenizes raw PGN multigame text.
        /// </summary>
        /// <param name="entireContent"></param>
        /// <returns></returns>
        public static List<PGNToken> tokenizeDataFromRawPGNMultigameText(string entireContent)
        {
            List<PGNToken> tokenizedData = new List<PGNToken>();
            int ctrGames = 0;
            int currentPosition = 0;    // zero-based index into entireContent
            char prevChar = '\n';
            // At this point we are always looking for the START of the next token
            while (currentPosition < entireContent.Length)
            {
                string nextChar = entireContent.Substring(currentPosition, 1);
                string lookAheadChar = currentPosition < entireContent.Length - 1 ? entireContent.Substring(currentPosition + 1, 1) : " ";

                // Must check for game termination token before checking for IntegerToken
                // Tricky! Returns null if currentPosition is not the start of a Game Termination Token.
                PGNToken gameTerminationToken = getGameTerminationToken(currentPosition, entireContent);
                if (gameTerminationToken != null)
                {
                    tokenizedData.Add(gameTerminationToken);
                    currentPosition += gameTerminationToken.tokenContent.Length;
                    ctrGames++;
                    if (ctrGames > 250)
                    {
                        throw new Exception("Error! KenChessPGNUtilities does not allow more than 250 games in a single pgn file.");
                    }
                }
                // Check for special escape mechanism (see PGN Spec)
                else if ((prevChar == '\n') && nextChar.Equals("%"))
                {
                    PGNToken pgnToken = getEscapeMechanismToken(currentPosition, entireContent);
                    tokenizedData.Add(pgnToken);
                    currentPosition += pgnToken.tokenContent.Length;
                    if (currentPosition >= entireContent.Length)
                    {
                        break;
                    }
                }
                // check for comment-to-end-of-line 
                else if (nextChar.Equals(";"))
                {
                    PGNToken pgnToken = getCommentToEOLToken(currentPosition, entireContent);
                    tokenizedData.Add(pgnToken);
                    currentPosition += pgnToken.tokenContent.Length;
                }
                // check for comment between braces
                else if (nextChar.Equals("{"))
                {
                    PGNToken pgnToken = getBracedCommentToken(currentPosition, entireContent);
                    tokenizedData.Add(pgnToken);
                    currentPosition += pgnToken.tokenContent.Length;
                }
                // check for string token
                else if (nextChar.Equals("\""))
                {
                    PGNToken pgnToken = getStringToken(currentPosition, entireContent);
                    tokenizedData.Add(pgnToken);
                    currentPosition += pgnToken.tokenContent.Length;
                }
                else if (".[]()".Contains(nextChar))
                {
                    PGNToken pgnToken = getSingleCharacterPGNToken(nextChar[0]);
                    tokenizedData.Add(pgnToken);
                    currentPosition++;
                }
                else if (nextChar.Equals("!"))
                {
                    PGNToken pgnToken = new PGNToken(PGNTokenType.NAGToken, "");
                    switch (lookAheadChar)
                    {
                        case "!": 
                            pgnToken.tokenContent = "$3";
                            currentPosition += 2;
                            break;
                        case "?": 
                            pgnToken.tokenContent = "$5";
                            currentPosition += 2;
                            break;
                        case " ": 
                            pgnToken.tokenContent = "$1";
                            currentPosition++;
                            break;
                    }
                    tokenizedData.Add(pgnToken);
                }
                else if (nextChar.Equals("?"))
                {
                    PGNToken pgnToken = new PGNToken(PGNTokenType.NAGToken, "");
                    switch (lookAheadChar)
                    {
                        case "!":
                            pgnToken.tokenContent = "$6";
                            currentPosition += 2;
                            break;
                        case "?":
                            pgnToken.tokenContent = "$4";
                            currentPosition += 2;
                            break;
                        case " ":
                            pgnToken.tokenContent = "$2";
                            currentPosition++;
                            break;
                    }
                    tokenizedData.Add(pgnToken);
                }
                else if (nextChar.Equals("$"))
                {
                    PGNToken pgnToken = getNAGToken(currentPosition, entireContent);
                    tokenizedData.Add(pgnToken);
                    currentPosition += pgnToken.tokenContent.Length;
                }
                else if (Char.IsDigit(nextChar[0]))
                {
                    PGNToken pgnToken = getIntegerToken(currentPosition, entireContent);
                    tokenizedData.Add(pgnToken);
                    currentPosition += pgnToken.tokenContent.Length;
                }
                else if (lettersAndDigits.Contains(nextChar[0]))
                {
                    PGNToken pgnToken = getSymbolToken(currentPosition, entireContent);
                    tokenizedData.Add(pgnToken);
                    currentPosition += pgnToken.tokenContent.Length;
                }
                else
                {
                    currentPosition++;
                }
                prevChar = entireContent.Substring(currentPosition - 1)[0];
            }
            return tokenizedData;
        }
        // Game Termination Token
        // Tricky! Returns null if currentPosition is not the start of a Game Termination Token.
        private static PGNToken getGameTerminationToken(int currentPosition, string entireContent)
        {
            PGNToken pgnToken = null;
            int numberRemainingChars = entireContent.Length - currentPosition;
            // check for game termination token
            if (entireContent.Substring(currentPosition, 1).Equals("*"))
            {
                pgnToken = new PGNToken(PGNTokenType.GameTerminationToken, "*");
            }
            else if ((numberRemainingChars >= 3) && (entireContent.Substring(currentPosition, 3).Equals("1-0")))
            {
                pgnToken = new PGNToken(PGNTokenType.GameTerminationToken, "1-0");
            }
            else if ((numberRemainingChars >= 3) && (entireContent.Substring(currentPosition, 3).Equals("0-1")))
            {
                pgnToken = new PGNToken(PGNTokenType.GameTerminationToken, "0-1");
            }
            else if ((numberRemainingChars >= 7) && (entireContent.Substring(currentPosition, 7).Equals("1/2-1/2")))
            {
                pgnToken = new PGNToken(PGNTokenType.GameTerminationToken, "1/2-1/2");
            }
            return pgnToken;
        }
        // Single character tokens
        private static PGNToken getSingleCharacterPGNToken(char tokenChar)
        {
            string tokenContent = tokenChar.ToString();
            PGNTokenType pgnTokenType = PGNTokenType.UNKNOWN;
            switch (tokenChar)
            {
                case '.':
                    pgnTokenType = PGNTokenType.PeriodToken; break;
                case '[':
                    pgnTokenType = PGNTokenType.LeftBracketToken; break;
                case ']':
                    pgnTokenType = PGNTokenType.RightBracketToken; break;
                case '(':
                    pgnTokenType = PGNTokenType.LeftParenthesisToken; break;
                case ')':
                    pgnTokenType = PGNTokenType.RightParenthesisToken; break;
                default:
                    break;
            }
            PGNToken pgnToken = new PGNToken(pgnTokenType, tokenContent);
            return pgnToken;
        }
        // NAG = Numeric Annotation Glyph
        private static PGNToken getNAGToken(int currentPosition, string entireContent)
        {
            string tokenContent = "$";
            while (true)
            {
                currentPosition++;
                char nextChar = entireContent.Substring(currentPosition, 1)[0];
                if (Char.IsDigit(nextChar))
                {
                    tokenContent += nextChar;
                }
                else
                {
                    break;
                }
            }
            PGNToken pgnToken = new PGNToken(PGNTokenType.NAGToken, tokenContent);
            return pgnToken;
        }
        // The returned token will be percent (%) + all characters up to and including new line character
        private static PGNToken getEscapeMechanismToken(int currentPosition, string entireContent)
        {
            string tokenContent = "%";
            while (true)
            {
                currentPosition++;
                char nextChar = entireContent.Substring(currentPosition, 1)[0];
                tokenContent += nextChar;
                if (nextChar == '\n')
                {
                    break;
                }
            }
            PGNToken pgnToken = new PGNToken(PGNTokenType.EscapeMechanismToken, tokenContent);
            return pgnToken;
        }
        // The returned token will be semicolon + all characters up to and including new line character
        private static PGNToken getCommentToEOLToken(int currentPosition, string entireContent)
        {
            string tokenContent = ";";
            while (true)
            {
                currentPosition++;
                char nextChar = entireContent.Substring(currentPosition, 1)[0];
                tokenContent += nextChar;
                if (nextChar == '\n')
                {
                    break;
                }
            }
            PGNToken pgnToken = new PGNToken(PGNTokenType.CommentToEOLToken, tokenContent);
            return pgnToken;
        }
        // The returned token will be left brace + all characters up to and including right brace.
        // Any newline chars in the token content will be replaced with a blank space character.
        private static PGNToken getBracedCommentToken(int currentPosition, string entireContent)
        {
            string tokenContent = "{";
            while (true)
            {
                currentPosition++;
                char nextChar = entireContent.Substring(currentPosition, 1)[0];
                //
                if (nextChar == '\n')
                {
                    nextChar = ' ';
                }
                tokenContent += nextChar;
                if (nextChar == '}')
                {
                    break;
                }
            }
            tokenContent = tokenContent.Replace("\r\n", " ");
            tokenContent = tokenContent.Replace("\r", " ");
            tokenContent = tokenContent.Replace("\n", " ");

            PGNToken pgnToken = new PGNToken(PGNTokenType.CommentBetweenBracesToken, tokenContent);
            return pgnToken;
        }
        // The returned token will be left double-quote + all characters up to and including right double-quote.
        // Tricky! Be careful with escaped double-quote (ex "From book, \"Chess Strategy\" at page 11.")
        private static PGNToken getStringToken(int currentPosition, string entireContent)
        {
            char prevChar = ' ';
            string tokenContent = "\"";
            while (true)
            {
                currentPosition++;
                char nextChar = entireContent.Substring(currentPosition, 1)[0];
                tokenContent += nextChar;
                if ((nextChar == '\"') && (prevChar != '\\'))
                {
                    break;
                }
                prevChar = nextChar;
            }
            PGNToken pgnToken = new PGNToken(PGNTokenType.StringToken, tokenContent);
            return pgnToken;
        }
        // The returned token will be all the consecutive digit characters starting at current position 
        private static PGNToken getIntegerToken(int currentPosition, string entireContent)
        {
            string tokenContent = entireContent.Substring(currentPosition, 1);
            while (true)
            {
                currentPosition++;
                char nextChar = entireContent.Substring(currentPosition, 1)[0];
                if (Char.IsDigit(nextChar))
                {
                    tokenContent += nextChar;
                }
                else
                {
                    break;
                }
            }
            PGNToken pgnToken = new PGNToken(PGNTokenType.IntegerToken, tokenContent);
            return pgnToken;
        }
        // A symbol token starts with a letter or digit character and is immediately followed by a sequence of zero or more symbol
        // continuation characters. These continuation characters are letter characters ("A-Za-z"), digit characters ("0-9"),
        // the underscore ("_"), the plus sign ("+"), the octothorpe sign ("#"), the equal sign ("="), the colon (":"), and the hyphen ("-").  
        private static PGNToken getSymbolToken(int currentPosition, string entireContent)
        {
            // symbol continuation characters
            string scc = lettersAndDigits + "_+#=:-";
            string tokenContent = entireContent.Substring(currentPosition, 1);
            while (true)
            {
                currentPosition++;
                char nextChar = entireContent.Substring(currentPosition, 1)[0];
                if (scc.Contains(nextChar))
                {
                    tokenContent += nextChar;
                }
                else
                {
                    break;
                }
            }
            PGNToken pgnToken = new PGNToken(PGNTokenType.SymbolToken, tokenContent);
            return pgnToken;
        }
    }
}
