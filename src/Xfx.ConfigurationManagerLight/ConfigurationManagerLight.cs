using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Xfx
{
    public class ConfigurationManagerLight
    {
        public static NameValueCollection AppSettings { get; private set; }

        public static ReadOnlyDictionary<string, ConnectionStringSettings> ConnectionStrings { get; private set; }

        protected static void InitInternal(List<KeyValuePair<string, string>> keys,
            Dictionary<string, ConnectionStringSettings> conStr)
        {
            AppSettings = new NameValueCollection(keys);
            if (conStr != null)
            {
                ConnectionStrings = new ReadOnlyDictionary<string, ConnectionStringSettings>(conStr);
            }
        }

        protected static void Init(StreamReader streamReader)
        {
            using (var reader = XmlReader.Create(streamReader))
            {
                var document = XDocument.Load(reader);
                var nodes = document.Nodes();
                var count = nodes.Count();
                switch (count)
                {
                    case 0:
                    case 1:
                        break;
                    default:
                        if (count > 1)
                        {
                            var appSettings = document.Descendants()
                                .Where(t => t.Name == "appSettings")
                                .Elements()
                                .ToList()
                                .Select(item => new KeyValuePair<string, string>(
                                    item.Attribute("key").Value,
                                    item.Attribute("value").Value))
                                .ToList();

                            var connectionStrings = document.Descendants()
                                .Where(t => t.Name == "connectionStrings")
                                .Elements()
                                .ToDictionary(t => t.Attribute("key").Value.ToString(),
                                    t =>
                                        new ConnectionStringSettings(t.Attribute("name").Value.ToString(),
                                            t.Attribute("providerName").Value.ToString(),
                                            t.Attribute("connectionString").Value.ToString()));

                            AppSettings = new NameValueCollection(appSettings);
                            ConnectionStrings = new ReadOnlyDictionary<string, ConnectionStringSettings>(connectionStrings);
                        }
                        break;
                }
            }
        }
    }
}