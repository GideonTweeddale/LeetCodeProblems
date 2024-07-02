namespace LeetCodeProblems.DFS;

using LeetCodeProblems.Nodes;
public class KthSmallestElementInABST
{
    // intuition
    // if we traverse the tree and add all of its elements to an array, we can return the kth element
    // we can do this in linear time and space with DFS because we know that the left element is always smaller and the right element larger
    // so for each element, we can add the return array from a recursive call on the left element + our current array + recursive call on the right element

    // if the bst had a property on each node for the number of children of that node (including children of children)
    // we could navigate to the kth element in O(log n) time, because for each node we would know to go right or left based on the number of children in the right and left nodes

    // our dfs approach has a time complexity of O(n) and a space complexity of O(n)
    public static int KthSmallest(TreeNode root, int k)
    {
        return DFS(root)[k-1].val;

        // helper functions
        // dfs
        TreeNode[] DFS(TreeNode node) 
        {
            if (node == null)
            {
                return [];
            }

            return [.. DFS(node.left), node, ..DFS(node.right)];
        }
    }
}

