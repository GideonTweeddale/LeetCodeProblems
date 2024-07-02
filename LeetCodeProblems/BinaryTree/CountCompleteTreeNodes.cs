namespace LeetCodeProblems.BinaryTree;
public class CountCompleteTreeNodes
{    
    // intuition
    // we can get the height by traversing the left subtree all the way to the bottom
    // then we traverse the right all the way too the bottom
    // if they are equal, it is a perfect binary tree
    // that tells us the number of nodes, which would be 2^(n+1) – 1 nodes
    // if not, we call count nodes on the subtrees

    // the time complexity of this will be O(log n^2)

    public static int CountNodes(TreeNode root) {
        if (root == null)
        {
            return 0;
        }

        int heightLeft = LeftHeight(root);
        int heightRight = RightHeight(root);

        if (heightLeft == heightRight)
        {
            return (int)Math.Pow(2, heightLeft) - 1;
        }       

        return 1 + CountNodes(root.left) + CountNodes(root.right); 
    }

    private static int LeftHeight(TreeNode node)
    {
        int height = 0;
        while (node != null)
        {
            height++;
            node = node.left;
        }
        return height;
    }

    private static int RightHeight(TreeNode node)
    {
        int height = 0;
        while (node != null)
        {
            height++;
            node = node.right;
        }
        return height;
    }
}

