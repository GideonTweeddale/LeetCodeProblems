namespace LeetCodeProblems.BFS;

using LeetCodeProblems.Nodes;
public class LowestCommonAncestorOfABinarySearchTree
{
    // intuition
    // do two binary searches to find the nodes
    // record the nodes we must visit as we get there
    // iterate over the two lists of nodes together to find the last match
    // this will be the LCA
    // this approach will be O(2log n) for the binary searches and worst case O(n) for the matches giving us a O(n) worst case time complexity
    // it will be O(2n) or just O(n) worst case time complexity for the lists of nodes in the seach pattern

    // another approach would be to search for the last node that is both larger than the smaller value and smaller the the larger value
    // this node must be the closest parent of both nodes
    // with binary search this would be O(log n) time and O(1) constant space

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        while (root != null)
        {
            if (root.val > p.val && root.val > q.val)
            {
                root = root.left;
            }
            else if (root.val < p.val && root.val < q.val)
            {
                root = root.right;
            }
            else
            {
                return root;
            }
        }

        return null; // allegedly we should never reach this.
    }
}

