namespace LeetCodeProblems.DFS;

using LeetCodeProblems.Nodes;
public class LowestCommonAncestorOfABinaryTree
{
    // intuition
    // one way of looking at this problem is to think about what nodes cannot be the LCA
    // we know that our LCA must either be one of the two node, if one is a descendant of the other
    // or it must be the parent of both
    // this means that the LCA cannot be the descendant of one of our nodes

    // to solve this, we can DFS until we find one of our two nodes
    // then return that up the tree
    // if one of the children of a node returns a node, return that, otherwise return null
    // if at any point both the left and right subtrees return a node, we have found our LCA 
    // if we never get both, our LCA must be one of the two nodes and we can return that if we found it
    // if we never found either then there is no LCA, but this question specifies that there will always be one

    // this will run in O(n) worst case time, where our target nodes the right nodes on the bottom level of the tree and we are forced to check every node
    // this will run in O(n) space assuming we include the stack frames in the same worst case
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null) return null;

        // we have found one of the two nodes we are looking for
        // meaning that our LCA will either be this node or one of its parents
        // so there is no point searching any further; none of this nodes children can be the LCA
        if (root == p || root == q)
        {
            return root;
        }

        // DFS our children
        TreeNode left = LowestCommonAncestor(root.left, p, q);
        TreeNode right = LowestCommonAncestor(root.right, p, q);

        // if neither is null, then this the first ancestor of both
        // return this node instead of either one
        if (left != null && right != null)
        {
            return root;
        }

        // return the valid right node
        if (right != null)
        {
            return right;
        }
        
        // there must either be a valud left node or null - return it either way
        return left;
    }
}

