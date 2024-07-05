using Data;
namespace WebApplication2
{
    public class Config
    {
        public static IConfigurationRoot GetConfiguracion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

        public static string GetConString()
        {
            string ConString = "";
            var Conf = GetConfiguracion();
            ConString = Conf.GetSection("Data").GetSection("ConnectionString").Value;
            return ConString;

        }
        //public static MailSettings GetMailSetting()
        //{
        //    MailSettings setting = new MailSettings();
        //    var Conf = GetConfiguracion();
        //    setting.Mail = Conf.GetSection("MailSettings").GetSection("Mail").Value;
        //    setting.DisplayName = Conf.GetSection("MailSettings").GetSection("DisplayName").Value;
        //    setting.Password = Conf.GetSection("MailSettings").GetSection("Password").Value;
        //    setting.Host = Conf.GetSection("MailSettings").GetSection("Host").Value;
        //    setting.Port = int.Parse(Conf.GetSection("MailSettings").GetSection("Port").Value);
        //    return setting;
        //}
    }
}
