namespace LeetCodeProblems.BFS;

using LeetCodeProblems.Nodes;

public class BinaryTreeLevelOrderTraversalI
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

    // huh. I just realised that this recursion (obviusly) isn't truly BFS it is actually DFS
    // Howver, we can actually use DFS to solve this problem because we don't care about the order of the nodes at each level
    public static IList<IList<int>> LevelOrder(TreeNode root)
    {
        if (root == null)
        {
            return [];
        }

        List<IList<int>> output  = [];

        return BFS(root, 0);

        // helper BFS function
        List<IList<int>> BFS(TreeNode? node, int depth)
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

    public static IList<IList<int>> LevelOrderQueue(TreeNode root)
    {
        if (root == null)
        {
            return [];
        }

        List<IList<int>> output = [];
        Queue<TreeNode> queue = [];

        queue.Enqueue(root);

        while(queue.Count != 0)
        {
            int length = queue.Count;
            List<int> level = [];

            for (int i = 0; i < length; i++)
            {
                TreeNode node = queue.Dequeue();
                level.Add(node.val);

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
            
            output.Add(level);
        }

        return output;
    }
}

