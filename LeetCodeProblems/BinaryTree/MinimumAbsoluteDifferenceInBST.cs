namespace LeetCodeProblems.BinaryTree;

public class MinimumAbsoluteDifferenceInBST
{
    // intuition
    // note - if duplicates are allowed, then the minimum possible difference is 0 and if not it is 1
    // meaning that if we find a difference that matches 0 or 1 depending, we can return early
    // otherwise we should do an in order traversal of the tree
    // to compare each node value with it's left and right children

    // to start with, in lieu of having someone to ask, I am going to assume that duplicates are not possible

    // this will run in O(n) time where n is the number of nodes in the tree because we will visit each node in the tree
    // and O(h) space where h is the depth of the tree
    // becuase we will recurse to the depth of the tree before returning if don't find the min value earlier
    // and that will use h stack frames

    public static int GetMinimumDifference(TreeNode root)
    {
        return GetSubtreeMinimumDifference(root, int.MaxValue, int.MaxValue).min;
    }

    private static (int min, int last) GetSubtreeMinimumDifference(TreeNode? node, int last, int min)
    {
        if (node == null || min == 1)
        {
            return (min, last);
        }

        (min, last) = GetSubtreeMinimumDifference(node.left, last, min);

        min = Math.Min(min, Math.Abs(last - node.val));
        last = node.val;

        (min, last) = GetSubtreeMinimumDifference(node.right, last, min);

        return (min, last);
    }
}