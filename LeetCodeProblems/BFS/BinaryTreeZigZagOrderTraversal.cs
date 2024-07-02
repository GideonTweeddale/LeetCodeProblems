namespace LeetCodeProblems.BFS;

using LeetCodeProblems.Nodes;
public class BinaryTreeZigZagOrderTraversalII
{
    // intuition
    // we can solve this problem using BFS.
    // create a list of lists of nodes to store the output
    // create a queue to store the nodes
    // add the root node to the queue
    // while the queue is not empty 
    // get the length of the queue
    // create a list to store the nodes at this level
    // for each item in the queue
    // add the node to the level list
    // if the node has a left child, add it to the queue
    // if the node has a right child, add it to the queue
    // repeat for each item in the queue
    // when we reach the end of count, add the level list to the output list and if we have added more items to the queue, repeat the process
    // however, if the number of lists in the output list is odd, reverse the list before adding it to the output list
    // return the output

    // we should only see each node once during BFS and once during reversal
    // so this will complete in O(n) time and we will have a function call in the stack for each node so our memory will be O(n) as well
    
    public static IList<IList<int>> ZigzagLevelOrder(TreeNode root)
    {
        if (root == null)
        {
            return [];
        }

        List<IList<int>> output = [];
        Queue<TreeNode> q = [];

        q.Enqueue(root);

        while(q.Any())
        {
            int length = q.Count;
            List<int> level = [];

            // for each item in the queue
            for (int i = 0; i < length; i++)
            {
                TreeNode node = q.Dequeue();
                level.Add(node.val);

                if (node.left != null)
                {
                    q.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    q.Enqueue(node.right);
                }
            }
            
            if (output.Count % 2 == 1)
            {
                level.Reverse();
            }

            output.Add(level);
        }

        return output;
    }

    // huh. I just realised that this recursion (obviusly) isn't truly BFS it is actually DFS
    // because we care about the order of the elements at this level, it isn't (as far as I can see) simple to use DFS to solve this problem
    public static IList<IList<int>> ZigzagLevelOrderDFS(TreeNode root)
    {
        if (root == null)
        {
            return [];
        }

        List<IList<int>> output = [];

        return BFS(root, 0, true);

        // helper BFS function
        List<IList<int>> BFS(TreeNode node, int depth, bool zag)
        {
            if (node == null)
            {
                return output;
            }

            if (output.Count <= depth)
            {
                output.Add([]);
            }

            output[depth].Add(node.val);

            if (zag)
            {
                BFS(node.right, depth + 1, !zag);
                BFS(node.left, depth + 1, !zag);
            } 
            else
            {
                BFS(node.left, depth + 1, !zag);
                BFS(node.right, depth + 1, !zag);
            }

            return output;
        }
    }
}

