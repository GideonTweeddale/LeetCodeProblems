namespace LeetCodeProblems.BFS;
public class PopulationNextRightPointersInEachNode
{
    // intution
    // do BFS
    // on each level enqueue the next levels nodes
    // and peek the next node in the queue and make it the next pointer for the current node
    // except for the last count where we make it null

    // this should be O(n) time and O(n) space because we will iterate through each node once
    // and our queue will have at most n/2 nodes in it because it will never have nodes from more than two levels at a time

    public PerfectNode Connect(PerfectNode root)
    {
        if (root == null)
        {
            return null;
        }

        Queue<PerfectNode> q = [];
        q.Enqueue(root);

        while(q.Any())
        {
            int count = q.Count;

            for (int i = 0; i < count; i++)
            {
                PerfectNode node = q.Dequeue();

                if (i < count - 1)
                {
                    node.next = q.Peek();
                }

                if (node.left != null)
                {
                    q.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    q.Enqueue(node.right);
                }
            }
        }

        return root;
    }
}

