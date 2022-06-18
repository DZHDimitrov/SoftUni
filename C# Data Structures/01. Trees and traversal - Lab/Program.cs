using Trees;

//var root = new Node<int>(
//    10, "0",
//        new Node<int>(5, "1",
//            new Node<int>(-1, "2"),
//            new Node<int>(-2, "3"),
//            new Node<int>(-3, "4",
//                new Node<int>(10, "5"),
//                new Node<int>(20, "6")),
//        new Node<int>(6, "7",
//            new Node<int>(21, "8")),
//        new Node<int>(7, "9")
//    ));

var root = new Node<int>(
    10, "0",
        new Node<int>(5, "1",
            new Node<int>(6, "2"),
            new Node<int>(6, "3")),
        new Node<int>(7, "4")
        );

var tree = new Tree<int>(root);

//var child = new Node<int>(50, "10");
//var childTwo = new Node<int>(51, "11");

//tree.AddChild("3", child);
//tree.AddChild("10", childTwo);
tree.RemoveChild("2");
tree.PrintDFS(root, 0);