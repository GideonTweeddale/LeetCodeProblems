namespace LeetCodeProblems.Graph.TopologicalSort;
public class CourseScheduleII
{
    // intuition
    // this is the same as courses, except that we need to store the courses as we clear their prequesites - which will give us a valid order to complete them
    // to do this we will create a Hashmap of the courses and their prerequistes
    // a visited hashset, to keep track of the courses we have visited in the DFS for a given origin node
    // and a schedule list, to which we will add each node the first time we see it without any uncompleted prereqs
    // and possibly a scheduled hashset to keep track of which nodes have already been added to the schedule
    // each of these structures will either be O(n) or O(p) giving us a memory complexity of O(n + p)

    // first we loop over the prerequisites adding them to the graph Hashmap - this will be O(p) time
    // then we iterate over the nodes calling DFS on each one of them - this will be O(n) 
    // because if a node has no prerequites it will return true immediately and if it has prerequistes they will be cleared after being visited once
    // in our DFS we will add the nodes to the schedule 
    // if we encounter a cycle, we will immediately return an empty list because there is no point wasting resources continuing to search
    // once we've run DFS on all our nodes, we will return the schedule

    public static int[] FindOrder(int numCourses, int[][] prerequisites)
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

        // keep track of the nodes we've visited in our current DFS
        HashSet<int> visited = new();

        // keep track of the nodes we've already added to the schedule
        HashSet<int> scheduled = new();

        // the schedule of courses
        List<int> schedule = new();

        // loop over all the nodes
        for (int i = 0; i < numCourses; i++)
        {
            if (!DFS(i))
            {
                return [];
            }
        }

        // return the schedule
        return schedule.ToArray();

        // DFS helper function
        bool DFS(int node)
        {
            // if we've already visited this node, then we have a cycle
            if (visited.Contains(node))
            {
                return false;
            }

            // if we've already added this node to the schedule, then we can skip it
            if (scheduled.Contains(node))
            {
                return true;
            }

            // if the node has no prerequisites, then we can finish the course
            if (!graph.ContainsKey(node))
            {
                schedule.Add(node);
                scheduled.Add(node);
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

            // the prerequisites have been satisfied - clear them
            graph[node] = [];

            // add the node to the schedule
            schedule.Add(node);

            // mark the node as scheduled
            scheduled.Add(node);

            return true;
        }
    }
}
