namespace LeetCodeProblems.BFS;
public class PopulatingNextRightPointersInEachNodeII
{
    // intution
    // do BFS
    // on each level enqueue the next levels nodes
    // peek the next node in the queue and if it is not null make it the next pointer for the current node
    // except for the last count where we make it null

    // this should be O(n) time and O(n) space because we will iterate through each node once
    // and our queue will have at most n/2 nodes in it because it will never have nodes from more than two levels at a time

    public TreeNode Connect(TreeNode root)
    {
        if (root == null)
        {
            return null;
        }

        Queue<TreeNode> q = [];
        q.Enqueue(root);

        while(q.Any())
        {
            int count = q.Count;

            for (int i = 0; i < count; i++)
            {
                TreeNode node = q.Dequeue();

                if (i < count - 1 && q.Peek() != null)
                {
                    node.next = q.Peek();
                }
                else
                {
                    node.next = null; // this probably isn't necessary, but it doesn't cost much to be explicit here
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

