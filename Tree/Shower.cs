using BinaryTree;
using BinaryTree_Branch;
namespace ConcoleShower;

public static class Shower
{
    const int lenth = 10;
    private static void print2DUtil<T>(Branch<T> root, int space)
        where T : IComparable<T>
    {
        // Base case
        if (root == null)
            return;

        // Increase distance between levels
        space += lenth;

        // Process right child first
        print2DUtil(root.RightBranch, space);

        // Print current node after space
        // count
        Console.Write("\n");
        for (int i = lenth; i < space; i++)
            Console.Write(" ");
        Console.Write(root.Value + "\n");

        // Process left child
        print2DUtil(root.LeftBranch, space);
    }

    // Wrapper over print2DUtil()
    public static void Print2D<T>(Tree<T> root)
        where T : IComparable<T>
    {
        // Pass initial space count as 0
        print2DUtil(root._root, 0);
    }



    public static void Print<T>(Tree<T> root)
        where T : IComparable<T>
    {
        long counter;
        if (root._root == null)
        {
            return;
        }
        else
        {
            counter = Counter(root._root);

        }
        
    }

    private static long Counter<T>(Branch<T> currnetBranch)
    {
        if (currnetBranch.LeftBranch != null)
        {
            return 1 + Counter(currnetBranch.LeftBranch);
        }
        else
        {
            return 0;
        }
    }
}
