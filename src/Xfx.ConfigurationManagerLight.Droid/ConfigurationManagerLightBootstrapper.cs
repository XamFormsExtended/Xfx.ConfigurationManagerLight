using System.IO;
using Android.App;

namespace Xfx
{
    public class ConfigurationManagerLightBootstrapper : ConfigurationManagerLight
    {
        public static void Init(Activity activity, string config = "app.config")
        {
            var assets = activity.Assets;
            using (var stream = new StreamReader(assets.Open(config)))
            {
                Init(stream);
            }
        }
    }
}