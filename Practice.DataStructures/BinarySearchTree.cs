namespace Practice.DataStructures
{
    public class BinarySearchTree
    {
        public class Node(int item)
        {
            public int Key = item;
            public Node? LeftChild = null;
            public Node? RightChild = null;
        }

        private Node? Root = null;

        public void Insert(int key)
        {
            Root = InsertRecursive(Root, key);
        }

        private static Node InsertRecursive(Node? root, int key)
        {
            if (root == null)
            {
                root = new Node(key);
                return root;
            }

            if (key < root.Key)
            {
                root.LeftChild = InsertRecursive(root.LeftChild, key);
            }
            else if (key > root.Key)
            {
                root.RightChild = InsertRecursive(root.RightChild, key);
            }

            return root;
        }

        public List<int> PreOrder()
        {
            List<int> list = [];
            PreOrderRecursive(Root, list);
            return list;
        }

        private static void PreOrderRecursive(Node? root, List<int> list)
        {
            if (root == null)
            {
                return;
            }

            list.Add(root.Key);
            PreOrderRecursive(root.LeftChild, list);
            PreOrderRecursive(root.RightChild, list);
        }

        public List<int> PostOrder()
        {
            List<int> list = [];
            PostOrderRecursive(Root, list);
            return list;
        }

        private static void PostOrderRecursive(Node? root, List<int> list)
        {
            if (root == null)
            {
                return;
            }

            list.Add(root.Key);
            PostOrderRecursive(root.LeftChild, list);
            PostOrderRecursive(root.RightChild, list);
        }

        public static int Height(Node? root)
        {
            if (root == null)
            {
                return 0;
            }
            int x = Height(root.LeftChild);
            int y = Height(root.RightChild);
            if (x > y)
            {
                return x + 1;
            }
            else
            {
                return y + 1;
            }
        }

        public static IList<IList<int>> VerticalOrderTraversal(Node? root)
        {
            List<List<int>> result = [];
            if (root == null)
            {
                return [];
            }
            SortedDictionary<int, SortedDictionary<int, List<int>>> verticalToLevelDataMap = new()
        {
            { 0, new SortedDictionary<int, List<int>>{ { 0, [root.Key] } } }
        };
            Queue<(Node node, int vertical, int level)> queue = new();
            queue.Enqueue((root, 0, 0));
            while (queue.Count > 0)
            {
                var (node, vertical, level) = queue.Dequeue();
                if (node.LeftChild != null)
                {
                    var v = vertical - 1;
                    var l = level + 1;
                    if (!verticalToLevelDataMap.TryGetValue(v, out var levelDataMap))
                    {
                        verticalToLevelDataMap[v] = new SortedDictionary<int, List<int>> { { l, [node.LeftChild.Key] } };
                    }
                    else
                    {
                        if (!levelDataMap.TryGetValue(l, out var list))
                        {
                            levelDataMap[l] = [node.LeftChild.Key];
                        }
                        else
                        {
                            list.Add(node.LeftChild.Key);
                        }
                    }
                    queue.Enqueue((node.LeftChild, v, l));
                }
                if (node.RightChild != null)
                {
                    var v = vertical + 1;
                    var l = level + 1;
                    if (!verticalToLevelDataMap.TryGetValue(v, out var levelDataMap))
                    {
                        verticalToLevelDataMap[v] = new SortedDictionary<int, List<int>> { { l, [node.RightChild.Key] } };
                    }
                    else
                    {
                        if (!levelDataMap.TryGetValue(l, out var list))
                        {
                            levelDataMap[l] = [node.RightChild.Key];
                        }
                        else
                        {
                            list.Add(node.RightChild.Key);
                        }
                    }
                    queue.Enqueue((node.RightChild, v, l));
                }
            }
            foreach (var (vertical, levelDataMap) in verticalToLevelDataMap)
            {
                foreach (var (level, dataList) in levelDataMap)
                {
                    dataList.Sort();
                }
                var dataListPerVertical = levelDataMap.Values.SelectMany(dataList => dataList).ToList();
                result.Add(dataListPerVertical);
            }
            return [.. result.Select(list => (IList<int>)[.. list])];
        }
    }
}
