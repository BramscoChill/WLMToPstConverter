using System;

namespace WLMToPst
{
    public static class Utils
    {
        public static DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }

        public static long ToUnixTime(DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64((date - epoch).TotalSeconds);
        }

        public static int ToUnixTimeInt(DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt32((date - epoch).TotalSeconds);
        }
        public static string LogExceptionString(Exception ex)
        {
            string logString = string.Empty;
            if (ex != null)
            {
                logString += $"Error: { ex.Message.ToString()}, Type: {ex.GetType().ToString()}, Stacktrace: {ex.StackTrace.Replace("\r\n", "\\r\\n")}";
                Exception innerException = ex?.InnerException;
                int index = 1;
                while (innerException != null)
                {
                    logString += $", Inner Exception ({index}): {innerException.Message}" + (string.IsNullOrEmpty(innerException.StackTrace) ? string.Empty : (" - innerStacktrace:" + innerException.StackTrace.Replace("\r\n", "\\r\\n")));
                    innerException = innerException?.InnerException;
                }
            }

            return logString;
        }
    }
}