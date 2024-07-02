namespace LeetCodeProblems.Graph.Matrix;

public static class EvaluateDivision
{    
    // Hm. This seems like a graph problem to me.

    // as I understand it, the equations and values are just solved divisions where values is the result
    // and queries are unsolved divisions where we need to get theresult

    // to solve this, we need to infer the values in of the solved divisions from the results
    // it looks to me like there may be many valid values for the variables in the equations
    // for example, with [["a","b"],["b","c"]], values = [2.0,3.0] 
    // we only have enough information to say that a must be double b and b must be triple c
    // but this leaves us with a huge range of possible values for c and therefore a and b that are valid

    // does this mean we can safely return any valid answer?

    // I see. My algebra wasn't up to scratch to solve this. I knew that this could be represented as a graph.
    // but I didn't remember that you could multiply divisions by each other to to substitute the common values out
    // making a/b * b/c = a/c and the inverse also true.
    // maybe I need to brush up on my algebra. It has been a long time.

    // we want to create an adjacency list where the nodes are the variables in the equations and the values are the edges that connect them
    // we also want to add the inverse edges

    // then we need to search the adjacency list for each of our queries, for the shortest path

    // the version using the dictionary seems a lot quicker than the version using the tuple
    public static double[] CalcEquationA(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {
        Dictionary<string, List<(string, double)>> adjacency = [];

        for (int i = 0; i < equations.Count; i++)
        {
            string a = equations[i][0];
            string b = equations[i][1];

            if (!adjacency.ContainsKey(a))
            {
                adjacency[a] = [];
            }

            adjacency[a].Add((b, values[i]));

            if (!adjacency.ContainsKey(b))
            {
                adjacency[b] = [];
            }

            adjacency[b].Add((a, 1 / values[i]));
        }

        double[] result = new double[queries.Count];

        for (int i = 0; i < queries.Count; i++)
        {
            result[i] = DFS(queries[i][0], queries[i][1]);
        }

        return result;

        double DFS(string source, string target)
        {
            // if either variable is unknown
            // the examples always return -1 even when dividing a variable by itself
            if (!adjacency.ContainsKey(source) || !adjacency.ContainsKey(target))
            {
                return -1;
            }

            Queue<(string, double)> q = [];
            HashSet<string> visited = [];
            q.Enqueue((source, 1));
            visited.Add(source);

            while (q.Count != 0)
            {
                (string neighbour, double weight) = q.Dequeue();
                
                // if the neighbour equals the target node, we can return the cummulative weight
                if (neighbour == target)
                {
                    return weight;
                }

                foreach ((string n, double w) in adjacency[neighbour])
                {
                    if (!visited.Contains(n))
                    {
                        // store the cummulative weight to make our returns easier
                        q.Enqueue((n, w * weight));
                        visited.Add(n);
                    }
                }
            }

            return -1; // if we never find a target
        }
    }

    public static double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {
        Dictionary<string, Dictionary<string, double>> map = [];

        for (int i = 0; i < equations.Count; i++)
        {
            string numerator = equations[i][0];
            string denominator = equations[i][1];

            if (!map.ContainsKey(numerator))
            {
                map[numerator] = [];
            }

            map[numerator][denominator] = values[i];

            if (!map.ContainsKey(denominator))
            {
                map[denominator] = [];
            }

            map[denominator][numerator] = 1 / values[i];
        }

        return queries.Select(q => DFS(q[0], q[1])).ToArray();

        double DFS(string source, string target)
        {
            // if either variable is unknown
            // the examples always return -1 even when dividing a variable by itself
            if (!map.ContainsKey(source) || !map.ContainsKey(target))
            {
                return -1;
            }

            Queue<(string, double)> q = [];
            HashSet<string> visited = [];
            q.Enqueue((source, 1));
            visited.Add(source);

            while (q.Count != 0)
            {
                (string neighbour, double weight) = q.Dequeue();
                
                // if the neighbour equals the target node, we can return the cummulative weight
                if (neighbour == target)
                {
                    return weight;
                }

                foreach ((string n, double w) in map[neighbour])
                {
                    if (!visited.Contains(n))
                    {
                        // store the cummulative weight to make our returns easier
                        q.Enqueue((n, w * weight));
                        visited.Add(n);
                    }
                }
            }

            return -1; // if we never find a target
        }
    }
}