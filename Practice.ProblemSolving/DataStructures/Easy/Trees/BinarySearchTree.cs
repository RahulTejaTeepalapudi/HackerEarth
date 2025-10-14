namespace Practice.ProblemSolving.DataStructures.Easy.Trees;

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
}
