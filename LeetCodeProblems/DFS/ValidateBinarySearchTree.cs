namespace LeetCodeProblems.DFS;
public class ValidateBinarySearchTree
{
    // intuition
    // a left node is valid if it is less than the node above it 
    // and a right node is valid if it is greater than the node above it
    // we can check this recursively by passing -infinity (or at least int.MinValue) and node.val to our left chidlren
    // and checking if their node.val is between those values
    // we can do the same for our right values by passing infinity (int.MaxValue) and node.val to our right children
    // and checking if their node.val is between those values

    // recursively call our function on each node and return its validity until we reach an invalid node 
    // there is no point searching the tree further once we know it is invalid
    // this will be O(n) time and space because we will iterate through our entire tree in the worst case

    public bool IsValidBSTA(TreeNode root)
    {
        if (root == null) return true;

        return DFS(root, double.MinValue, double.MaxValue);

        // DFS helper function
        bool DFS(TreeNode node, double left, double right)
        {
            if (node == null) return true;

            if (!(left < node.val && node.val < right))
            {
                return false;
            }

            return DFS(node.left, left, node.val) && DFS(node.right, node.val, right);
        }
    }

    // DFS using nullable int for bounds
    // this might be slightly quicker by avoiding doubles and the casting back and forth between them

    public bool IsValidBST(TreeNode root)
    {
        if (root == null) return true;

        return DFS(root, null, null);

        bool DFS(TreeNode node, int? left, int? right)
        {
            if (node == null) return true;

            // Validate current node's value
            if ((left != null && node.val <= left) || (right != null && node.val >= right))
            {
                return false;
            }

            // Recursively validate left and right subtrees
            return DFS(node.left, left, node.val) && DFS(node.right, node.val, right);
        }
    }

    // at least as far as the leetcode tests are concerned this is within the margin of error - some runs were quicker and some slower
    // none by much
    // it does arguably make the intent of the nulls easier to understand 
}

