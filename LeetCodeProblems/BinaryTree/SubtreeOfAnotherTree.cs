namespace LeetCodeProblems.BinaryTree;
public class SubtreeOfAnotherTree
{
    public bool IsSubtree(TreeNode? root, TreeNode? subRoot)
    {
        // O(N+S) time and O(N) space in the worst case, where N is the number of nodes in the root tree and S is the number of nodes in the subtree
        // because items in binary trees are unique there should only be one match for the root of the subtree in the main tree
        // if there were multiple matches, this would be O(N) squared 
        // where we have a node with a value that matches the first node of the subroot try and match the rest of the tree
        // if not, check for a matching node in the right and left children 
        if (root == null)
            return root == subRoot;

        // if we have a node that matches the root of the subtree, try and match
        if (root.val == subRoot?.val && DFS(root, subRoot))
            return true;
        
        // else look for a match in both children
        return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
    }

    private bool DFS(TreeNode? root, TreeNode? subRoot)
    {
        if (root == null && subRoot == null)
            return true;

        if (root == null || subRoot == null || root.val != subRoot.val)
            return false;
        
        return DFS(root?.left, subRoot?.left) && DFS(root?.right, subRoot?.right);
    }
}

