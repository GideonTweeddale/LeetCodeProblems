namespace LeetCodeProblems.BFS;
public class BinaryTreeRightSideView
{
    // intuition
    // can we not just return the right child of the right child until there are no right children left?
    // or is the question asking for the entire right subtree of the rooot?
    // or maybe all right children of all nodes in the right subtree?
    // based on the expected result from a test case with nodes that would satisfy all of those above coniditons
    // it looks like the question is simply asking for every right child until there are no right children left
    // meaning that we can solve this problem by creating a list and appending the root to it
    // then, while there is a right child, appending the node and looking at its right child
    // finally returning the list
    // this will take worst case O(n) time if the entire tree is made up of right children, but likely something closer to O(log n) time 
    // and worst case O(n) space including the output list which could contain all the nodes if the tree is entirely made up of right children

    // wow. The question was worded horribly. The question is actaully asking for the rightmost node of each level of the tree
    // so we need to do a level order traversal and return the rightmost node of each level
    // making this a BFS problem, not a DFS problem.
    // there may be a more efficient way to solve this,
    // but we can solve it in O(n) time by doing a normal BFS traversal

    public IList<int> RightSideView(TreeNode root)
    {
        if (root == null) return [];

        List<int> output = [];
        Queue<TreeNode> q = [];

        q.Enqueue(root);

        while (q.Any())
        {
            int length = q.Count;
            TreeNode rightMost = null; // we could use just one variable here, dequeue the node into it, and just add the last one to the list.

            for (int i = 0; i < length; i++)
            {
                TreeNode node = q.Dequeue(); 

                rightMost = node;

                if (node.left != null)
                {
                    q.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    q.Enqueue(node.right);
                }
            }

            output.Add(rightMost.val);
        }

        return output;
    }
}

