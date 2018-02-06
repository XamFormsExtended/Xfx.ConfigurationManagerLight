using System.IO;
using Android.Content;

namespace Xfx
{
    public class ConfigurationManagerLightBootstrapper : ConfigurationManagerLight
    {
        public static void Init(Context context, string config = "App.config")
        {;
            using (var stream = new StreamReader(context.Assets.Open(config)))
                Init(stream);
        }
    }
}