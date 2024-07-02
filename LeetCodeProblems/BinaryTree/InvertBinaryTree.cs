namespace LeetCodeProblems.BinaryTree;
public class InvertBinaryTree
{
    public static TreeNode? InvertTree(TreeNode? root)
    {
        // dfs recursive solution - should be O(N) time complexity and O(N) space complexity in the worst case
        // iterate down the tree swapping the left and right children
        if (root == null)
        {
            return null;
        }

        TreeNode? left = InvertTree(root.right);
        TreeNode? right = InvertTree(root.left);

        root.left = left;
        root.right = right;

        return root;
    }

    public static TreeNode? InvertTreeB(TreeNode? root)
    {
        // this should use less memory by not storing the inverted subtrees in intermediate variables
        // but in the leetcode test it actually uses more memoery and is slower
        // however, this could be down to runtime variations in the runtime environment (the differences are well within the margin of error)
        if (root == null)
        {
            return null;
        }

        InvertTreeB(root.left);
        InvertTreeB(root.right);

        (root.left, root.right) = (root.right, root.left);

        return root;
    }
}

