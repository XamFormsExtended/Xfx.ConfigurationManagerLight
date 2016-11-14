using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Xfx
{
    public class NameValueCollection : IReadOnlyList<KeyValuePair<string, string>>
    {
        public string this[string name]
        {
            get
            {
                return _source.SingleOrDefault(kv => kv.Key.Equals(name)).Value;
            }
        }
        
        public IEnumerable<string> AllKeys
        {
            get
            {
                return this.Select(pair => pair.Key);
            }
        }

        private readonly IList<KeyValuePair<string, string>> _source;

        public NameValueCollection(IList<KeyValuePair<string, string>> source)
        {
            _source = source;
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _source.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count => _source.Count;

        public KeyValuePair<string, string> this[int index] => _source[index];
    }
}