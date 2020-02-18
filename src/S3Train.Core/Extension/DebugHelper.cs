using System.Diagnostics;

namespace MVC.Core.Extension.Helper
{
    public static class DebugHelper
    {
        /// <summary>
        /// Get the calling function name
        /// </summary>
        /// <param name="stackDeepth">The deepth of stack track</param>
        /// <returns></returns>
        public static string GetCallingFunction(int stackDeepth = 2)
        {
            try
            {
                // stackDeepth
                // 0 => GetCallingFunction
                // 1 => Log
                // 2 => Calling function

                var stack = new StackTrace();
                var method = stack.GetFrame(stackDeepth).GetMethod();

                return (method.DeclaringType?.Name ?? "[Unknown]") + "." + method.Name;
            }
            catch
            {
                return $"[Unknown function at deepth={stackDeepth}]";
            }
        }
    }
}
