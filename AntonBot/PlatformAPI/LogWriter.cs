using System;

namespace AntonBot.PlatformAPI
{
    using System.IO;
    using System.Reflection;


    public static class LogWriter
    {
        public static string LogPath = string.Empty;
        static LogWriter()
        {
            LogWrite("Start Log-File");
        }
        public static void LogWrite(string logMessage)
        {
            if (LogPath.Equals(string.Empty))
            {
                LogPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar + "Log.txt";
            }
            try
            {
                using (StreamWriter w = File.AppendText(LogPath))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private static void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1} <br/>", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  :<br/>");
                txtWriter.WriteLine("  :{0}<br/>", logMessage);
                txtWriter.WriteLine("-------------------------------<br/>");
            }
            catch (Exception ex)
            {
            }
        }
    }
}
