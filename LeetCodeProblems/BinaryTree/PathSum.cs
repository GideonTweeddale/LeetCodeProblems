namespace LeetCodeProblems.BinaryTree;
public class PathSum
{

    public bool HasPathSum(TreeNode? root, int targetSum)
    {
        // dfs recursive solution is required here - should be O(N) time complexity and O(N) space complexity in the worst case
        // we should recursively evaluate each path, passing down the sum until the end of the path is reached

        if (root == null)
            return false;

        if (root.left == null && root.right == null && root.val == targetSum)
            return true;

        return HasPathSum(root.left, targetSum, root.val) || HasPathSum(root.right, targetSum, root.val);
    }

    private bool HasPathSum(TreeNode? node, int targetSum, int currentSum)
    {
        if (node == null)
            return false;

        currentSum += node.val;

        // is leaf and path adds up
        if (node.left == null && node.right == null && targetSum == currentSum)
            return true;

        return HasPathSum(node.left, targetSum, currentSum) || HasPathSum(node.right, targetSum, currentSum);
    }

    public bool HasPathSumB(TreeNode? root, int targetSum)
    {
        // dfs recursive solution is required here - should be O(N) time complexity and O(N) space complexity in the worst case
        // we should recursively evaluate each path, passing down the sum until the end of the path is reached

        // it is possible to combine these functions by subtracting the val from the target sum instead of passing the current sum
        // I don't think I would have thought of this by myself 

        if (root == null)
            return false;

        if (root.left == null && root.right == null && root.val == targetSum)
            return true;

        targetSum -= root.val;

        return HasPathSumB(root.left, targetSum) || HasPathSumB(root.right, targetSum);
    }

    // there was a surprisingly big difference in performance between these two approaches
    // according to leetcode, the first was in the 24th percentile and the second was in the 88th percentile
    // this might just be a result of random runtime variations - I can't see any obvious reason why they would perform differently
}

