namespace LeetCodeProblems.TopologicalSort;
public class CourseSchedule
{
    // intuition
    // this is basically a cycle problem
    // would could find the cycle with dfs and a hashset of prerequisites
    // the dfs would be O(n) and the hashset would O(p), giving us O(n + p)
    // for space the hashset would take O(p) and we'd have to keep track of the nodes we've visited which would be O(n) giving us the same memory complexity of O(n + p)
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        // create the graph and add the prerequisites
        Dictionary<int, List<int>> graph = new ();

        foreach (int[] prereq in prerequisites)
        {
            if (!graph.ContainsKey(prereq[0]))
            {
                graph[prereq[0]] = [];
            }

            graph[prereq[0]].Add(prereq[1]);
        }

        // keep track of the nodes we've visited
        HashSet<int> visited = new ();

        // visit all the nodes
        for (int node = 0; node < numCourses; node++)
        {
            if (!DFS(node))
            {
                return false;
            }
        }

        return true;

        // dfs helper function
        bool DFS(int node) 
        { 
            // if we've already visited this node, then we have a cycle
            if (visited.Contains(node))
            {
                return false;
            }

            // if the node has no prerequisites, then we can finish the course
            if (!graph.ContainsKey(node))
            {
                return true;
            }

            // mark the node as visited
            visited.Add(node);

            // visit all the prerequisites
            foreach (int prerequisite in graph[node])
            {
                if (!DFS(prerequisite))
                {
                    return false;
                }
            }

            // remove the node from the visited set
            visited.Remove(node);

            // clear the prerequisites that have been satisfied
            graph[node] = [];

            return true;
        }
    }
}
