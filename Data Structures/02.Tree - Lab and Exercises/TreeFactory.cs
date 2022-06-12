namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeFactory
    {
        private Dictionary<int, Tree<int>> nodesBykeys;

        public TreeFactory()
        {
            this.nodesBykeys = new Dictionary<int, Tree<int>>();
        }

        public Tree<int> CreateTreeFromStrings(string[] input)
        {
            foreach (var line in input)
            {
                var args = line.Split(' ').Select(int.Parse).ToArray();

                var parent = CreateNodeByKey(args[0]);
                var child = CreateNodeByKey(args[1]);

                AddEdge(parent.Key, child.Key);
            }

            return this.GetRoot();
        }

        public Tree<int> CreateNodeByKey(int key)
        {
            Tree<int> node = null;

            if (!nodesBykeys.ContainsKey(key))
            {
                nodesBykeys.Add(key, new Tree<int>(key));
            }

            return nodesBykeys[key];
        }

        public void AddEdge(int parent, int child)
        {
            var parentNode = nodesBykeys[parent];
            var childNode = nodesBykeys[child];

            parentNode.AddChild(childNode);
            childNode.AddParent(parentNode);

        }

        private Tree<int> GetRoot()
        {
            var node = this.nodesBykeys.FirstOrDefault().Value;

            while (node.Parent != null)
            {
                node = node.Parent;
            }

            return node;
        }
    }
}
