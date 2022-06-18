namespace Trees
{
    public class Node<T>
    {
        public Node(T value, string key)
        {
            this.Value = value;
            this.Key = key;
        }

        public Node(T value,string key, params Node<T>[] children) : this(value,key)
        {
            foreach (var child in children)
            {
                child.Parent = this;
                this.Children.Add(child);
            }
        }

        public string Key { get; set; }

        public T Value { get; set; }

        public Node<T> Parent { get; set; }

        public List<Node<T>> Children { get; set; } = new List<Node<T>>();

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
