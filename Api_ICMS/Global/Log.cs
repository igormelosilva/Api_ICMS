namespace Api_ICMS.Global
{
    public class Log
    {
        public static void Save(string msg)
        {
            //Verifica se a pasta existe
            if (!Directory.Exists(Config.folderPath))
            {
                Directory.CreateDirectory(Config.folderPath);
            }
            //verifica se o arquivo existe
            if (!File.Exists(Config.filePath))
            {
                File.Create(Config.filePath).Dispose();
            }
            //Grava o log no arquivo
            File.AppendAllText(Config.filePath, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - " + msg + Environment.NewLine);

        }
    }
}
