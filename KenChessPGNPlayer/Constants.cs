using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KenChessPGNPlayer
{
    public static class Constants
    {
        public const string AppName = "KenChessPGNPlayer";
        public const string WindowShortTitleText = "KenChessPGNPlayer";
        public const string VersionInfo = "Version 1.0.1.1";

        public static void DisplayInfoMessage(string message)
        {
            MessageBox.Show(message, WindowShortTitleText, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void DisplayErrorMessage(string message)
        {
            MessageBox.Show(message, WindowShortTitleText, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void DisplayExceptionMessage(Exception exc)
        {
            if (exc == null)
            {
                throw new ArgumentNullException(nameof(exc));
            }
            string primaryMessage = exc.Message;
            // The null-propagation operator (?.) will return null if anything in the object reference chain is null. 
            string innerMessage = exc.InnerException?.Message;
            string message = primaryMessage + ((innerMessage == null) ? "" : "\n" + innerMessage);
            message = message + "\nStack trace:\n" + exc.StackTrace;
            MessageBox.Show(message, WindowShortTitleText, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult AskYesNoQuestion(string question)
        {
            DialogResult result = MessageBox.Show(question, WindowShortTitleText,
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result;
        }
    }
}
