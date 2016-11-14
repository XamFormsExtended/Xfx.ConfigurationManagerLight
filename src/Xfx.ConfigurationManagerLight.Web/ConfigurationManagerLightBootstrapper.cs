using System.Collections.Generic;
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
            AppSettings = new NameValueCollection(kvp);
        }
    }
}
