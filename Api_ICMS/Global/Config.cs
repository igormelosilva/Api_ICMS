namespace Api_ICMS.Global
{
    public class Config
    {
        //Variáveis vindas do json
        public static string fileName = string.Empty;
        public static string folderName = string.Empty;

        //Caminhos
        public static string basePath = string.Empty;
        public static string filePath = string.Empty;
        public static string folderPath = string.Empty;

        public static void LoadConfigurations()
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            try
            {
                fileName = config.GetValue<string>("Log:FileName");
                folderName = config.GetValue<string>("Log:FolderName");

                basePath = AppDomain.CurrentDomain.BaseDirectory;
                folderPath = Path.Combine(basePath, folderName);
                filePath = Path.Combine(folderPath, fileName);


            }
            catch (Exception ex)
            {
            }




        }
    }
}
