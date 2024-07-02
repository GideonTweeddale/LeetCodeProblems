namespace LeetCodeProblems.BinaryTree;
public class MinimumDepthOfBinaryTree
{
    public static int MinDepthBFS(TreeNode root)
    {
        // with a bfs implementation which should be O(n) time complexity and space complexity of roughly O(n) in the worst case
        // we can end early if we find a leaf node in the level we are currently searching
        // because we will have already checked all the nodes in the previous level
        // and would have already returned if one of them was a leaf

        if (root == null)
        {
            return 0;
        }

        // bfs search
        Queue<TreeNode> queue = new();
        queue.Enqueue(root);

        int level = 0;

        while (queue.Count != 0)
        {
            int count = queue.Count;
            level += 1;

            for (int i = 0; i < count; i++)
            {
                TreeNode node = queue.Dequeue();

                if (node.left == null && node.right == null) // this is a leaf node
                {
                    return level;
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
            }

        }

        return level;
    }

    public static int MinDepth(TreeNode? root)
    {
        // dfs solution - should be O(N) time complexity and O(1) space complexity
        // intuitively the bfs solution should be faster because the dfs solution only stops evaluating the local branch when it finds a leaf node
        // however, the dfs solution is faster in practice - maybe because it is inherently threadable or perhaps because of the small sizes of the test cases
        if (root == null)
        {
            return 0;
        }

        int leftMin = MinDepth(root.left);
        int rightMin = MinDepth(root.right);

        if (leftMin == 0 || rightMin == 0)
        {
            return Math.Max(leftMin, rightMin) + 1;
        }

        return Math.Min(leftMin, rightMin) + 1;
    }
}

