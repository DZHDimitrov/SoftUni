using System.Collections;

namespace SUHttpServer.HTTP
{
    public class HeaderCollection : IEnumerable<Header>
    {
        private readonly Dictionary<string, Header> headers = new Dictionary<string, Header>();

        public int Count => headers.Count;

        public void Add(string name, string value)
        {
            this.headers[name] = new Header(name, value);
        }

        public string this[string name] => this.headers[name].Value;

        public bool Contains(string name)
        {
            return this.headers.ContainsKey(name);
        }

        public IEnumerator<Header> GetEnumerator()
        {
            return this.headers.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
