using System;

namespace LogAn
{
    public class LogAnalyzer
    {
        public bool IsValidLogFileName(string fileName)
        {
            //Allow StringComparison to be case-insensitive by changing culture from en-US-POSIX
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException( "filename has to be provided");
            }
            
            if (!fileName.EndsWith(".SLF", StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }
            return true;
        }
    }
}
