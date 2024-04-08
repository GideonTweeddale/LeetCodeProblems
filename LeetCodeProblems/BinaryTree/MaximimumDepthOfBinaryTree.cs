namespace LeetCodeProblems.BinaryTree;
public class MaximimumDepthOfBinaryTree
{
    public int MaxDepth(TreeNode? root)
    {
        // intuitevly dfs recursive solution makes sense to me here because we want to run down to the end of the tree
        // should be O(N) time complexity and O(N) space complexity in the worst case

        if (root == null)
            return 0;

        // this check is unnecesary and covered by the null check above and the Math.Max below
        // interestingly, removing it cut runtime by 25% going from the 33rd percentile to the 81st percentile
        // some or all of this might be down to random variation
        // testing would be required, but it would be interesting to know
        // if this is a case where most of the solutions are very similar
        // and the tiny amount of work in the if statement ends up being significant
        // if (root.left == null && root.right == null)
        //     return 1;

        return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
    }
}

