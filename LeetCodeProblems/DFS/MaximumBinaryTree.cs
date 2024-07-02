namespace LeetCodeProblems.DFS;

using LeetCodeProblems.Nodes;
public class MaximumBinaryTree
{
    // intuition
    // this is weird
    // but I think we can solve this in O(2n) time using two pointers 
    // because we have enough information from comparing each node to the next next to decide how they should be attached to each other
    // climb the tree from the left and descend the right
    // if the next value is larger than the root, make it the root and append the current as it's left child
    // if the next value is smaller than the root and smaller than the current, make it the right child of the current
    // if the next value is smaller than the root and larger than the current value, make the current value it's left child and make it the right child of the previous value
    // return the root

    // this doesn't work - I still think it can. Come back and fix it.

    public static TreeNode ConstructMaximumBinaryTree(int[] nums)
    {
        if (nums == null)
        {
            return null;
        }

        if (nums.Length == 1)
        {
            return new TreeNode(nums[0]);
        }

        TreeNode root = new(nums[0]);
        TreeNode current = root;
        TreeNode previous = null;

        for(int i = 1; i < nums.Length; i++)
        {
            TreeNode next = new(nums[i]);

            // child
            if(next.val < root.val)
            {
                // right
                if (current.val > next.val)
                {
                    current.right = next;
                }
                // insert the node inbetween the previous and next nodes
                else if (current.val < next.val)
                {
                    previous.right = next;
                    next.left = current;
                }
            } 
            // new root
            else if (next.val > root.val)
            {
                next.left = root;
                root = next;
            }

            previous = current;
            current = next;
        }

        return root;
    }

    // recursive O(n^2) solution
    public static TreeNode ConstructMaximumBinaryTreeRecursive(int[] nums)
    {
        return Dfs(0, nums.Length - 1);

        // dfs helper function
        TreeNode Dfs(int start, int end)
        {
            if(start > end)
            {
                return null;
            }

            if (start >= end)
            {
                return new TreeNode(nums[start]);
            }

            int maxI = start;

            for (int i = start + 1; i <= end; i++)
            {
                if (nums[i] > nums[maxI])
                {
                    maxI = i;
                }
            }

            TreeNode? node = new(nums[maxI]);

            node.left = Dfs(start, maxI - 1);
            node.right = Dfs(maxI + 1, end);

            return node;
        }
    }
}

