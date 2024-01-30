namespace LeetCodeProblems.BinaryTree;
public class DiameterOfABinaryTree
{

    // Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    int maxDiameter;
    public int DiameterOfBinaryTree(TreeNode root)
    {
        // dfs solution - should be O(N) time complexity and O(N) space complexity
        // for any pair of subtrees, the diameter is max depth of it's left and right subtrees combined
        // if we compare that against the max diameter we've found so far, we can solve this recursively in a single pass
        DiameterOfSubtree(root);

        return maxDiameter;
    }
    private int DiameterOfSubtree(TreeNode root)
    {
        if (root == null)
            return 0;

        int left = DiameterOfSubtree(root.left);
        int right = DiameterOfSubtree(root.right);

        maxDiameter = Math.Max(maxDiameter, left + right);

        return Math.Max(left, right) + 1;
    }
}

