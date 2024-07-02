namespace LeetCodeProblems.BinaryTree;
public class BinaryTreeMaximumPathSum
{
    // we can discard any negative sum 
    // at each node, we compare the maximum left and right paths with the path from left to right with the max overall path
    // we save the largest to the maximum overall path
    // and return whichever is larger of the left and right sub path
    // do this recursively

    public static int MaxPathSumA(TreeNode root) {
        if (root == null)
        {
            return 0;
        }

        int pathSum = root.val;
        DFSA(root);

        return pathSum;

        // dfs helper
        int DFSA(TreeNode? node)
        {
            if (node == null)
            {
                return 0;
            }

            int leftSum = DFSA(node.left);
            int rightSum = DFSA(node.right);
            int uSum = leftSum + rightSum + node.val;
            int localPathSum = Math.Max(leftSum, rightSum) + node.val;
            localPathSum = Math.Max(localPathSum, node.val);

            pathSum = Math.Max(pathSum, localPathSum);
            pathSum = Math.Max(pathSum, uSum);

            // Console.WriteLine($"{node.val} {leftSum} {rightSum} {uSum} {localPathSum}");

            return localPathSum;   
        }
    }

    public static int MaxPathSum(TreeNode root) {
        if (root == null)
        {
            return 0;
        }

        int pathSum = root.val;
        DFS(root);

        return pathSum;

        // dfs helper
        int DFS(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            int leftSum = Math.Max(0, DFS(node.left));
            int rightSum = Math.Max(0, DFS(node.right));
            int uSum = leftSum + rightSum + node.val;
            pathSum = Math.Max(pathSum, uSum);

            return node.val + Math.Max(leftSum, rightSum);   
        }
    }
}

