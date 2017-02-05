using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Configuration;

namespace Xfx
{
     public class ConfigurationManagerLightBootstrapper : ConfigurationManagerLight
    {
        public static void Init()
        {
            var kvp = WebConfigurationManager.AppSettings.AllKeys
                .Select(key => new KeyValuePair<string, string>(key, WebConfigurationManager.AppSettings[key]))
                .ToList();

            var conStr = ConfigurationManager.ConnectionStrings.Cast<System.Configuration.ConnectionStringSettings>()
                .ToDictionary(x => x.Name, x => new ConnectionStringSettings(x.Name, x.ProviderName, x.ConnectionString));

            InitInternal(kvp, conStr);
        }
    }
}
