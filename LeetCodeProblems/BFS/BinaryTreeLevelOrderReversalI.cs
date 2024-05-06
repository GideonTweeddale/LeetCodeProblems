namespace LeetCodeProblems.BFS;
public class BinaryTreeLevelOrderReversalI
{
    // intuition
    // we can solve this problem using BFS.
    // create a list of lists of nodes to store the output
    // Starting with the root node,
    // add the node to the output list at the index matching the depth
    // recursively call BFS on each child node, until we reach a leaf node
    // with each call increment and pass the depth
    // return the output

    // we should only see each node once, so this will complete in O(n) time and we will have a function call in the stack for each node so our memory will be O(n) as well
    public IList<IList<int>> LevelOrderBottom(TreeNode root)
    {
        List<IList<int>> output  = new List<IList<int>>();

        output = BFS(root, 0);
        output.Reverse();

        return output;

        // helper BFS function
        List<IList<int>> BFS(TreeNode node, int depth)
        {
            if (node == null)
            {
                return output;
            }

            if (output.Count == depth)
            {
                output.Add([]);
            }

            BFS(node.left, depth + 1);
            BFS(node.right, depth + 1);

            output[depth].Add(node.val);

            return output;
        }
    }
}

