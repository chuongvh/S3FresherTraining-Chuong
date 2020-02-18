using System;
using System.Text;

namespace MVC.Core.Extension.Helper
{
    public class ExceptionHelper
    {
        public static void CheckoutException(Exception ex, out string message, out string stackTrace)
        {
            CheckoutException(ex, out message, out stackTrace, "-->");
        }

        public static void CheckoutException(Exception ex, out string message, out string stackTrace, string space)
        {
            var messageBuilder = new StringBuilder();
            var stackTraceBuilder = new StringBuilder();
            var temp = ex;
            while (temp != null)
            {
                messageBuilder.Append(temp.Message + space);
                stackTraceBuilder.Append(temp.StackTrace + space);
                temp = temp.InnerException;
            }
            message = messageBuilder.ToString();
            stackTrace = stackTraceBuilder.ToString();
        }
    }

    public class ExceptionConstant
    {
        public const int Space = 30;
        public const string Line = "--------------------------------------------------";
    }
}