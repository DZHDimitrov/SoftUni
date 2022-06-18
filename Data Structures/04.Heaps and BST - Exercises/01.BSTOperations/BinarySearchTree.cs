namespace _01.BSTOperations
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree()
        {
        }

        public BinarySearchTree(Node<T> root)
        {
            this.CopyNode(root);
        }

        private void CopyNode(Node<T> node)
        {
            if (node != null)
            {
                this.Insert(node.Value);
                this.CopyNode(node.RightChild);
                this.CopyNode(node.LeftChild);
            }
        }

        public Node<T> Root { get; private set; }

        public int Count { get; private set; }

        public bool Contains(T element)
        {
            return Contains(element, this.Root);
        }

        private bool Contains(T Element, Node<T> node)
        {
            if (node == null)
            {
                return false;
            }

            if (node.Value.CompareTo(Element) == 0)
            {
                return true;
            }

            if (node.Value.CompareTo(Element) < 0)
            {
                return Contains(Element, node.LeftChild);
            }

            else
            {
                return Contains(Element, node.RightChild);
            }
        }

        public void Insert(T element)
        {
            Insert(element, this.Root);
        }

        private void Insert(T element, Node<T> node)
        {
            if (node == null)
            {
                var newNode = new Node<T>(element);
                this.Root = newNode;
                this.Count++;
                return;
            }

            if (node.Value.CompareTo(element) > 0)
            {
                if (node.LeftChild == null)
                {
                    node.LeftChild = new Node<T>(element);
                    this.Count++;
                    return;
                }
                Insert(element, node.LeftChild);
            }

            else
            {
                if (node.RightChild == null)
                {
                    node.RightChild = new Node<T>(element);
                    this.Count++;
                    return;
                }
                Insert(element, node.RightChild);
            }
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            var node = this.Root;

            while (node != null)
            {
                if (node.Value.CompareTo(element) > 0)
                {
                    node = node.LeftChild;
                }

                else if (node.Value.CompareTo(element) < 0)
                {
                    node = node.RightChild;
                }

                else
                {
                    break;
                }
            }

            return node == null ? null : new BinarySearchTree<T>(node);
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(action, this.Root);
        }

        private void EachInOrder(Action<T> action, Node<T> node)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(action, node.LeftChild);
            action.Invoke(node.Value);
            this.EachInOrder(action, node.RightChild);
        }

        public string InOrderDfs(Node<T> node, int indent = 0)
        {
            var result = "";

            if (node.LeftChild != null)
            {
                result += InOrderDfs(node.LeftChild, indent + 3);
            }

            result += $"{new string(' ', indent)}{node.Value}\r\n";

            if (node.RightChild != null)
            {
                result += InOrderDfs(node.RightChild, indent + 3);
            }

            return result;
        }

        public List<T> Range(T lower, T upper)
        {
            var result = new List<T>();
            Range(lower, upper, this.Root, result);
            return result;
        }

        private void Range(T startRange, T endRange, Node<T> node, List<T> result)
        {
            if (node == null)
            {
                return;
            }

            var inStartRange = startRange.CompareTo(node.Value);
            var inEndRange = endRange.CompareTo(node.Value);

            if (inStartRange < 0)
            {
                this.Range(startRange, endRange, node.LeftChild, result);
            }

            if (inStartRange <= 0 && inEndRange >= 0)
            {
                result.Add(node.Value);
            }

            if (inEndRange > 0)
            {
                this.Range(startRange, endRange, node.RightChild, result);
            }
        } 

        public void DeleteMin()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            this.Root.LeftChild = this.DeleteMin(this.Root.LeftChild);
        }

        private Node<T> DeleteMin(Node<T> node)
        {
            if (node.LeftChild == null)
            {
                this.Count--;
                return node.RightChild;
            }

            node.LeftChild = this.DeleteMin(node.LeftChild);
            return node;
        }

        public void DeleteMax()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            this.Root.RightChild = this.DeleteMax(this.Root.RightChild);
        }

        private Node<T> DeleteMax(Node<T> node)
        {
            if (node.RightChild == null)
            {
                this.Count--;
                return node.LeftChild;
            }

            node.RightChild = this.DeleteMax(node.RightChild);
            return node;
        }

        public int GetRank(T element)
        {
            throw new NotImplementedException();
        }
    }
}
