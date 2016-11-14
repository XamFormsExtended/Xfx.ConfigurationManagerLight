using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Xfx
{
    public class ConfigurationManagerLightBootstrapper: ConfigurationManagerLight
    {
        public static void Init()
        {
            var kvp = ConfigurationManager.AppSettings.AllKeys
                .Select(key => new KeyValuePair<string, string>(key, ConfigurationManager.AppSettings[key]))
                .ToList();
            AppSettings = new NameValueCollection(kvp);
        }
    }
}
