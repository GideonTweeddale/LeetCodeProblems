namespace LeetCodeProblems.Graph;

public class CloneGraph133
{
    // intuition
    // we need to visit every node in the graph to add it to our new graph
    // we can do this with a BFS or DFS
    // to prevent us from visiting the same nodes multiple times, we can keep track of which nodes we have visited with a hashset
    // this means that we'll be able to clone the graph in O(n) time complexity and O(n) space complexity

    public Node CloneGraph(Node node)
    {
        if (node == null) return null;

        Dictionary<Node, Node> visited = new([]);

        return DFS(node);

        Node DFS(Node node)
        {
            if (visited.ContainsKey(node)) return visited[node];

            Node clone = new Node(node.val);
            visited.Add(node, clone);

            foreach (Node neighbor in node.neighbors)
            {
                clone.neighbors.Add(DFS(neighbor));
            }

            return clone;
        }
    }

    public Node CloneGraphA(Node node)
    {
        if (node == null) return null;

        Dictionary<Node, Node> visited = new([]);
        Queue<Node> queue = new([node]);

        Node clone = new Node(node.val);
        visited.Add(node, clone);

        while (queue.Any())
        {
            Node current = queue.Dequeue();

            foreach (Node neighbor in current.neighbors)
            {
                if (!visited.ContainsKey(neighbor))
                {
                    visited.Add(neighbor, new Node(neighbor.val));
                    queue.Enqueue(neighbor);
                }

                clone.neighbors.Add(visited[neighbor]);
            }
        }

        return clone;
    }
}

