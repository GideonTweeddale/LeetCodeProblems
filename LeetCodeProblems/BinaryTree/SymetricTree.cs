namespace LeetCodeProblems.BinaryTree;
public class SymetricTree
{
    // we can solve this recursively, with two pointer
    // set the left pointer to the left subtree and the right to the right subtree
    // and then recurse through them
    // if we find any nodes that aren't equal, return false
    
    // this will run in O(n) worst case time where n is the number of nodes in the smaller of the two subtrees
    // this will use O(k) extra memory, including stack frames, where k is the height of the shorter subtree

    public bool IsSymmetric(TreeNode root) {
        return MatchingTrees(root.left, root.right);    
    }

    // helper
    private bool MatchingTrees(TreeNode left, TreeNode right)
    {
        if (left == null && right == null) return true;
        if (left == null || right == null) return false; // one of the trees must have a node where the other doesn't
        if (left.val != right.val) return false;

        return MatchingTrees(left.left, right.right) && MatchingTrees(left.right, right.left);
    } 
}

