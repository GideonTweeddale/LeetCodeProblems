namespace LeetCodeProblems.BFS;
public class AllNodesDistanceKInBinaryTree
{
    // intuition
    // this is really two problems
    // first, finding the target
    // second, finding all the nodes that are k distant from the target
    // there are also two kinds of k distant node
    // first, nodes that are children of the target
    // second nodes that are children are in a different part of the tree

    // do we always have the target in the tree? What do we do if we don't?

    // what if we transform the data structure - like for example into a graph making all the links two way
    // then we can find out target and traverse n steps from it in every direction, add the values there to our output and return

    // This will be O(n) time and O(n) space complexity
    // because the DFS to build the graph will visit every node once taking O(n) time
    // and the BFS to traverse the graph will visit every node at most once taking O(n) time giving us combined O(2n) or just O(n) time complexity
    // the graph will take O(n) space, the Queue, Visited HashSet, and output list will take max O(n) space, giving a worst case of O(4n) or just O(n) space complexity

    public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
    {
        if (root == null || target == null) return [];

        Dictionary<TreeNode, List<TreeNode>> graph = [];

        // build the graph with DFS
        BuildGraph(root, null);

        // if the graph doesn't contain the target, return empty
        if (!graph.ContainsKey(target)) return [];

        // if the target doesn't have any neighbours, return empty
        if (graph[target].Count == 0) return [];

        foreach (KeyValuePair<TreeNode, List<TreeNode>> item in graph)
        {
            string str = $"Item {item.Key} links";

            foreach (TreeNode link in item.Value) str = str + " " + link.val;

            Console.WriteLine(str);
        }

        // BFS/traverse the graph to find all the nodes that are k distant from the target
        Queue<TreeNode> q = [];
        q.Enqueue(target);

        List<int> output = [];
        HashSet<TreeNode> visited = [target];

        while(q.Any())
        {
            int count = q.Count;

            for (int i = 0; i < count; i++)
            {
                TreeNode node = q.Dequeue();

                if (k == 0) // when we reach the kth level, add the value to the output and don't queue the children
                {
                    output.Add(node.val);
                }
                else 
                {
                    foreach (var neighbor in graph[node])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            q.Enqueue(neighbor);
                            visited.Add(neighbor);
                        }
                    }
                }
            }

            k--;
        }

        return output;

        // helper functions
        void BuildGraph(TreeNode node, TreeNode parent)
        {
            if (node == null) return;

            if (!graph.ContainsKey(node)) 
            {
                graph[node] = [];
            }

            if (parent != null)
            {
                graph[node].Add(parent);
                graph[parent].Add(node);
            }

            BuildGraph(node.left, node);
            BuildGraph(node.right, node);
        }
    }
}

