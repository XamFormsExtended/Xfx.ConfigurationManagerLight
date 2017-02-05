##ConfigurationManagerLight##

Configuration Manager Light provides an easy way to use XML `App.settings` across your desktop, web, and mobile applications.

###Platform Support###

- [x] Windows Deskop
- [x] ASP.Net Web App
- [x] Android
- [x] iOS
- [ ] UWP
- [ ] Linux
- [ ] Mac OS X

###Gettings Started###

Once you've brought ConfigurationManagerLight into your application, you are required to create your App.config file and initialize it on your respective platform.

**Desktop or Web**

App.config should be exactly as you would always do it.
```
// somewhere in your app startup
ConfigurationManagerLightBootstrapper.Init();
```

**Droid**
App.config should be located in your `Assets` folder and build action set to `AndroidAsset`

```
public class MainActivity {
    protected override void OnCreate(Bundle bundle)
	{
	    base.OnCreate(bundle);
		ConfigurationManagerLightBootstrapper.Init(this);
	}
}
```

**Touch**
App.config should be located in your `Assets` folder and build action set to `BundleResource`

```
public partial class AppDelegate
{
    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
	{
	    ConfigurationManagerLightBootstrapper.Init();
	    return base.FinishedLaunching(app,options);
	}   
}
```

*note: config format*

```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <appSettings>
	    <add key="foo" value="bar" />
	</appSettings>
    <connectionStrings>
        <add name="test" providerName="my provider" connectionString="my connection string"/>
    </connectionStrings>
</configuration>
```

###What's the point?###

If you're looking at this repo, you probaby already have a need for App.config in your app; that being said however, here's my personal rational for needing this.

When we deliver our app through the DevOps release pipeline, we needed a way to update config for various environments without recompiling the app. Basically, the old way was to use something like this... it's damn ugly, hard to maintain, and required you to recompile for every environment.

```
#if _DEV_
var environment = "development";
#elif _TEST_
var environment = "test";
#else
var environment = "production";
#endif
```

And now, with ConfigurationManagerLight, we can simply do this

```
var magicString = ConfigurationManagerLight.AppSettings["environment"];
```

###Great, but how do we update our Touch/Droid apps after they've been bundled?###

So this is the tricky part, and somthing that I won't cover here. The basics of it is that your app bundle for Touch and Droid apps is simply a zip file. You need to unzip your app, update the `App.config` with the new values, and then re-zip and re-sign your app. I've personally scripted this to happen within our Octopus Deploy deployment steps, and once it's setup, it really works great.

###License###

Use granted via the [Microsoft Public License](https://opensource.org/licenses/MS-PL)

------

