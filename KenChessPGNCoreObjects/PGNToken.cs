using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenChessPGNCoreObjects
{
    public enum PGNTokenType
    {
        UNKNOWN,
        GameTerminationToken,   // 1-0   0-1   1/2-1/2  *
        StringToken,
        CommentToEOLToken,      // semicolon marks start of comment to end of line
        CommentBetweenBracesToken, // ex: {some comment}
        SymbolToken,
        IntegerToken,           // special case of SymbolToken
        PeriodToken,            // token for move numbers
        LeftBracketToken,       // brackets delimit tags
        RightBracketToken,
        LeftParenthesisToken,   // parentheses delimit variations (may be nested)
        RightParenthesisToken,
        NAGToken,               // dollar sign ($) is Numeric Annotation Glyph
        EscapeMechanismToken    // % in first column means ignore entire line
    }
    public class PGNToken
    {
        public PGNTokenType tokenType { get; set; }
        public string tokenContent { get; set; }
        public PGNToken(PGNTokenType tokenType, string tokenContent)
        {
            this.tokenType = tokenType;
            this.tokenContent = tokenContent;
        }
    }
}
