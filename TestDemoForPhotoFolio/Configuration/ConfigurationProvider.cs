using Microsoft.Extensions.Configuration;


namespace PhotoFolio.Configration
{
        internal class ConfigurationProvider
        {
            private static ConfigurationManager configurationManager;
            public static ConfigurationManager ConfigurationManager
            {
                get
                {
                    if (configurationManager == null)
                    {
                        configurationManager = new ConfigurationManager();
                        configurationManager
                            .AddJsonFile("appsettings.local.json", false, false);
                    }
                    return configurationManager;
                }
            }
        }
}
