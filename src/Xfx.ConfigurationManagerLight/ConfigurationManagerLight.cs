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
        // ReSharper disable InconsistentNaming
        private const string APP_SETTINGS = "appSettings";
        private const string CONNECTION_STRING = "connectionString";
        private const string CONNECTION_STRINGS = "connectionStrings";
        private const string KEY = "key";
        private const string NAME = "name";
        private const string PROVIDER_NAME = "providerName";

        private const string VALUE = "value";
        // ReSharper enable InconsistentNaming

        public static NameValueCollection AppSettings { get; private set; }

        public static ReadOnlyDictionary<string, ConnectionStringSettings> ConnectionStrings { get; private set; }

        protected static void Init(StreamReader streamReader)
        {
            using (var reader = XmlReader.Create(streamReader))
            {
                var xDocument = XDocument.Load(reader);
                var xNodes = xDocument.Nodes();
                if (xNodes.Count() <= 1) return;
                var appSettings = xDocument.Descendants()
                    .Where(t => t.Name == APP_SETTINGS)
                    .Elements()
                    .ToList()
                    .Select(GenerateKeyValueFromItem)
                    .Where(i => !string.IsNullOrWhiteSpace(i.Key))
                    .ToList();

                var connectionStrings = xDocument.Descendants()
                    .Where(t => t.Name == CONNECTION_STRINGS)
                    .Elements()
                    .ToDictionary(xElement => xElement.Attribute(KEY)?.Value.ToString(), GenerateConnetionStringSettingsFromItem);

                AppSettings = new NameValueCollection(appSettings);
                ConnectionStrings = new ReadOnlyDictionary<string, ConnectionStringSettings>(connectionStrings);
            }
        }

        private static ConnectionStringSettings GenerateConnetionStringSettingsFromItem(XElement xElement) => new ConnectionStringSettings(xElement.Attribute(NAME)?.Value,
            xElement.Attribute(PROVIDER_NAME)?.Value,
            xElement.Attribute(CONNECTION_STRING)?.Value);

        private static KeyValuePair<string, string> GenerateKeyValueFromItem(XElement item) => new KeyValuePair<string, string>(
            item?.Attribute(KEY)?.Value,
            item?.Attribute(VALUE)?.Value);

        protected static void InitInternal(List<KeyValuePair<string, string>> keys, Dictionary<string, ConnectionStringSettings> conStr)
        {
            AppSettings = new NameValueCollection(keys);
            ConnectionStrings = conStr != null
                ? new ReadOnlyDictionary<string, ConnectionStringSettings>(conStr)
                : new ReadOnlyDictionary<string, ConnectionStringSettings>(new Dictionary<string, ConnectionStringSettings>());
        }
    }
}