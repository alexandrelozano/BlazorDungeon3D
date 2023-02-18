using Microsoft.Extensions.Configuration;

namespace BlazorDungeon3D.Code
{
    public class Logging
    {
        public string remoteIpAddress;
        public string userAgent;
        public string logFile;

        public void Log(string text, string file)
        {
            try
            {
                if (Directory.Exists(Path.GetDirectoryName(file)))
                {
                    string line = String.Format("{0} {1} {2}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss "), text, Environment.NewLine);
                    System.IO.File.AppendAllText(file, line);
                }
            }
            catch (Exception e)
            {
            }
        }
    }
}
