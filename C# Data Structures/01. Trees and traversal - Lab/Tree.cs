namespace Trees
{
    public class Tree<T>
    {
        public Tree(Node<T> root)
        {
            this.Root = root;
        }

        public Node<T> Root { get; set; }

        public bool IsRootDeleted { get; private set; }

        public void BFS()
        {
            var queue = new Queue<Node<T>>();
            queue.Enqueue(this.Root);

            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();

                foreach (var child in subtree.Children)
                {
                    Console.WriteLine(child);
                    queue.Enqueue(child);
                }
            }
        }

        public void PrintDFS(Node<T> node, int depth)
        {
            Console.WriteLine(new string(' ', depth) + node);
            foreach (var child in node.Children)
            {
                PrintDFS(child, depth + 3);
            }
        }

        public Node<T> FindBFS(string parentKey)
        {
            var queue = new Queue<Node<T>>();
            queue.Enqueue(this.Root);

            while (queue.Count > 0)
            {
                var parent = queue.Dequeue();

                if (parent.Key == parentKey)
                {
                    return parent;
                }

                foreach (var child in parent.Children)
                {
                    queue.Enqueue(child);
                }
            }
            return null;
        }

        public void AddChild(string key, Node<T> child)
        {
            var parent = FindBFS(key);

            if (parent == null)
            {
                throw new ArgumentException("Indexistant node");
            }

            parent.Children.Add(child);
        }

        public void RemoveChild(string key)
        {
            var searchedNode = FindBFS(key);

            foreach (var child in searchedNode.Children)
            {
                child.Parent = null;
            }

            searchedNode.Children.Clear();

            var searchedParent = searchedNode.Parent;

            if (searchedParent == null)
            {
                this.IsRootDeleted = true;
            }

            else
            {
                searchedParent.Children.Remove(searchedNode);
            }

            searchedNode.Value = default(T);
        }
    }
}
