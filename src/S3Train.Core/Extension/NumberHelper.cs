namespace MVC.Core.Extension.Helper
{
    public static class NumberHelper
    {
        public delegate bool TryParseHandler<T>(string value, out T result);

        public static T? TryParse<T>(string value, TryParseHandler<T> handler) where T : struct
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            if (handler(value, out T result))
            {
                return result;
            }
            return null;
        }
    }
}