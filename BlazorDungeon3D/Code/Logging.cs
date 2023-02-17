using Microsoft.Extensions.Configuration;

namespace BlazorDungeon3D.Code
{
    public class Logging
    {
        public static void Log(string text, string logFile)
        {
            try
            {
                if (Directory.Exists(Path.GetDirectoryName(logFile)))
                {
                    string line = String.Format("{0} {1} {2}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss "), text, Environment.NewLine);
                    System.IO.File.AppendAllText(logFile, line);
                }
            }
            catch (Exception e)
            {
            }
        }
    }
}
