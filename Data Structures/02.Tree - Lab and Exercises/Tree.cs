namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;
        private List<T> path;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this._children = new List<Tree<T>>();

            foreach (var child in children)
            {
                AddChild(child);
                child.AddParent(this);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this._children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this._children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString()
        {
            return GetAsString("");
        }

        public string GetAsString(string result, int depth = 0)
        {
            result += new string(' ', depth) + Key + Environment.NewLine;

            foreach (var item in Children)
            {
                result = item.GetAsString(result, depth + 2);
            }

            return result;
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            throw new NotImplementedException();
        }

        public List<T> GetLeafKeys()
        {
            return GetLeafNodes().Select(n => n.Key).ToList();
        }

        private List<Tree<T>> GetLeafNodes()
        {
            var nodes = new List<Tree<T>>();

            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node.Children.Count == 0)
                {
                    nodes.Add(node);
                }

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return nodes;
        }

        public List<T> GetMiddleKeys()
        {
            var keys = new List<T>();

            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node.Children.Count > 0 && node.Parent != null)
                {
                    keys.Add(node.Key);
                }

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }
            return keys;
        }

        public List<T> GetLongestPath()
        {
            throw new NotImplementedException();
        }

        private List<T> GetLongestPath(int sum)
        {
            throw new NotImplementedException();
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            var leafNodes = GetLeafNodes();
            var allPaths = new List<List<T>>();

            foreach (var node in leafNodes)
            {
                var path = new List<T>();
                var currentNode = node;
                int currentSum = 0;

                while (currentNode.Parent != null)
                {
                    currentSum += int.Parse(currentNode.Key.ToString());
                    path.Add(currentNode.Key);
                    currentNode = currentNode.Parent;
                }

                path.Add(currentNode.Key);

                if (currentSum + int.Parse(currentNode.Key.ToString()) == sum)
                {
                    path.Reverse();
                    allPaths.Add(path);
                }
            }

            return allPaths;
        }

        public List<List<T>> PathsWithGivenSumDFS(Tree<T> node, ref int currentSum, int targetSum, List<List<T>> allPaths, List<T> currentPathValues)
        {
            currentSum += int.Parse(node.Key.ToString());
            currentPathValues.Add(node.Key);

            foreach (var child in node.Children)
            {
                PathsWithGivenSumDFS(child, ref currentSum, targetSum, allPaths, currentPathValues);
            }

            if (currentSum == targetSum)
            {
                allPaths.Add(new List<T>(currentPathValues));
            }

            currentSum -= int.Parse(node.Key.ToString());
            currentPathValues.RemoveAt(currentPathValues.Count - 1);

            return allPaths;
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            throw new NotImplementedException();
        }
    }
}
