namespace LeetCodeProblems.Graph.TopologicalSort;
public class MinimumHeightTrees
{
    // intuition
    // starting with every node as the root we'd need to check the height of all the subtrees in order
    // we could do this with DFS or BFS 
    // there can only ever be one or two nodes with the minimum height trees depending on whether there is one longest path or multiple equivalent longest paths
    // interestingly, leaf nodes (nodes with only a single edge) can never be the root of a minimum height tree unless the the tree has a max height of 1 or only two nodes
    // we can treat this as our base case and remove all the leaf nodes from the graph iteratively until we are left with one or two nodes
    // the number of iterations will be the depth of the tree - 1 and the remaining one or two nodes will be the roots of the minimum height trees
    // the time complexity of this approach is O(n) because we will visit each node once and the space complexity is O(n) because we will need to store the graph

    // we can use a dictionary to store the graph and a queue to store the leaf nodes
    public static IList<int> FindMinHeightTrees(int n, int[][] edges)
    {
        Dictionary<int, List<int>> graph = [];

        foreach (int[] edge in edges)
        {
            if (!graph.ContainsKey(edge[0]))
            {
                graph[edge[0]] = [];
            }

            if (!graph.ContainsKey(edge[1]))
            {
                graph[edge[1]] = [];
            }

            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }

        // store the leaf nodes
        Queue<int> leaves = new();

        // store the number of untrimmed leaves for each node
        Dictionary<int, int> edgeCounts = [];

        // init the queue and edgeCounts
        foreach (int node in graph.Keys)
        {
            if (graph[node].Count == 1)
            {
                leaves.Enqueue(node);
            }
            edgeCounts[node] = graph[node].Count;
        }

        // remove the leaves with only one edge decrementing the edge count of their neighbors
        // and then repeat until we have two or less nodes 
        while(leaves.Count > 0)
        {
            if (n <= 2)
            {
                return leaves.ToList();
            }

            int count = leaves.Count;

            for (int i = 0; i < count; i++)
            {
                int leaf = leaves.Dequeue();
                n--;

                foreach (int neighbor in graph[leaf])
                {
                    edgeCounts[neighbor]--;

                    if (edgeCounts[neighbor] == 1)
                    {
                        leaves.Enqueue(neighbor);
                    }
                }
            }
        }

        return [0];
    }
}
