using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Xfx
{
    public class ConfigurationManagerLight
    {
        public static NameValueCollection AppSettings { get; protected set; }

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
                            var dict = document.Descendants()
                                .Where(t => t.Name == "appSettings")
                                .Elements()
                                .ToList();
                            var collection = dict
                                .Select(item => new KeyValuePair<string, string>(
                                    item.Attribute("key").Value, 
                                    item.Attribute("value").Value))
                                .ToList();
                            AppSettings = new NameValueCollection(collection);
                        }
                        break;
                }
            }
        }
    }
}