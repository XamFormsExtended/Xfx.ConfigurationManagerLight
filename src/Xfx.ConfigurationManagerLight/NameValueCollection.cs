using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Xfx
{
    public class NameValueCollection : IReadOnlyList<KeyValuePair<string, string>>
    {
        private readonly IList<KeyValuePair<string, string>> _source;

        public NameValueCollection(IList<KeyValuePair<string, string>> source)
        {
            _source = source;
        }

        public IEnumerable<string> AllKeys => this.Select(pair => pair.Key);

        public string this[string name] => _source.SingleOrDefault(kv => kv. Key.Equals(name)).Value;

        public int Count => _source.Count;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator() => _source.GetEnumerator();

        public KeyValuePair<string, string> this[int index] => _source[index];
    }
}