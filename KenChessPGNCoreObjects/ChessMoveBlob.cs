using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenChessPGNCoreObjects
{
    /// <summary>
    /// ChessMoveBlobs are temporary objects used in the process of parsing PGN movetext into ChessMoveNodes.
    /// </summary>
    public class ChessMoveBlob
    {
        public string FriendlyMoveNumber { get; set; }
        public string SANmove { get; set; }
        // Numeric Annotation Glyph
        // For values whose text meaning is only 1 or 2 characters, that text is appended to SANmove; otherwise the text is comment after move.
        // ex: value=3 changes SANmove from Qxd1 to Qxd1!!
        //..public int NAGvalue { get; set; }
        public string TextBeforeMove { get; set; }
        public string TextAfterMove { get; set; }
        public ChessMoveBlob()
        {
            FriendlyMoveNumber = "";
            SANmove = null;
            //..NAGvalue = -1;
            TextBeforeMove = "";
            TextAfterMove = "";
        }
        public bool isLeftParenthesisMove()
        {
            return (SANmove != null) && SANmove.Equals("(");
        }
        public bool isRightParenthesisMove()
        {
            return (SANmove != null) && SANmove.Equals(")");
        }
        public static ChessMoveBlob createLeftParenthesisChessMoveBlob()
        {
            ChessMoveBlob chessMoveBlob = new ChessMoveBlob();
            chessMoveBlob.SANmove = "(";
            return chessMoveBlob;
        }
        public static ChessMoveBlob createRightParenthesisChessMoveBlob()
        {
            ChessMoveBlob chessMoveBlob = new ChessMoveBlob();
            chessMoveBlob.SANmove = ")";
            return chessMoveBlob;
        }
        public override string ToString()
        {
            string objString = TextBeforeMove + " " + FriendlyMoveNumber + " " + SANmove + " " + TextAfterMove;
            return objString.Trim();
        }
    }
}
