using Heap;

var priorityQueue = new PriorityQueue<int>();

var list = new List<int>() { 10, 5, 3, 25, 95, 51, 2, 18, 27, 105, 85, 75, 50, 45, 39 };

foreach (var item in list)
{
    priorityQueue.Add(item);
}

while (priorityQueue.Size > 0)
{
    Console.WriteLine($"Max element is {priorityQueue.Dequeue()}");
}

var bst = new BST<int>();
var orderedList = new List<int>();

for (int i = 0; i < 50; i += 2)
{
    orderedList.Add(i);
}

Insert(bst, 0, orderedList.Count, orderedList);

void Insert(BST<int> tree, int start, int end, List<int> list)
{
    if (start >= end)
    {
        return;
    }

    var middleIndex = (start + end) / 2;
    tree.Insert(list[middleIndex], bst.Root);
    Insert(tree, start, middleIndex - 1, list);
    Insert(tree, middleIndex + 1, end, list);
}

Console.WriteLine(bst.InOrderDfs(bst.Root));