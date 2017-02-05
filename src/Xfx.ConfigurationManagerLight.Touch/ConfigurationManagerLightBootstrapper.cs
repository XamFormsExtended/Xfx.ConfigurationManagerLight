using System.IO;

namespace Xfx
{
    public class ConfigurationManagerLightBootstrapper : ConfigurationManagerLight
    {
        public static void Init(string config = "Assets/App.config")
        {
            using (var stream = new StreamReader(config))
            {
                Init(stream);
            }
        }
    }
}
