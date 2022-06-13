namespace Heap
{
    public class BST<T> where T : IComparable
    {
        public BST(Node<T> root = null)
        {
            this.Root = root;
        }

        public Node<T> Root { get; set; }


        public void Insert(T value, Node<T> node)
        {
            if (node == null)
            {
                var currentNode = new Node<T>(value);
                this.Root = currentNode;
                return;
            }

            var a = node.Value.CompareTo(value);

            if (node.Value.CompareTo(value) > 0)
            {
                if (node.LeftChild == null)
                {
                    node.LeftChild = new Node<T>(value);
                    return;
                }
                Insert(value, node.LeftChild);
            }

            else
            {
                if (node.RightChild == null)
                {
                    node.RightChild = new Node<T>(value);
                    return;
                }
                Insert(value, node.RightChild);
            }
        }

        public string InOrderDfs(Node<T> node, int indent = 0)
        {
            string result = "";

            if (node.LeftChild != null)
            {
                result += InOrderDfs(node.LeftChild, indent + 3);
            }

            result += $"{new string(' ',indent)}{node.Value}\r\n";

            if (node.RightChild != null)
            {
                result += InOrderDfs(node.RightChild, indent + 3);
            }

            return result;
        }
    }
}
