using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using MSConnSettings =System.Configuration.ConnectionStringSettings;
using MSWebCfgMgr = System.Web.Configuration.WebConfigurationManager;
using MSCfgMgr = System.Configuration.ConfigurationManager;
namespace Xfx
{
     public class ConfigurationManagerLightBootstrapper : ConfigurationManagerLight
    {
        public static void Init()
        {
            var appSettings = MSWebCfgMgr.AppSettings.AllKeys.Select(GenerateKeyValuePair).ToList();
            var connectionStrings = MSCfgMgr.ConnectionStrings.Cast<MSConnSettings>().ToDictionary(x => x.Name, GenerateConnectionStringSettings);
            InitInternal(appSettings, connectionStrings);
        }

        private static ConnectionStringSettings GenerateConnectionStringSettings(MSConnSettings x) => new ConnectionStringSettings(x.Name, x.ProviderName, x.ConnectionString);

        private static KeyValuePair<string,string> GenerateKeyValuePair(string key) => new KeyValuePair<string, string>(key, WebConfigurationManager.AppSettings[key]);
    }
}
