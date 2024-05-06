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

    // the question asks for a costant space solution
    // we can do this by thinking of the tree in levels
    // for a given node, we connect its children 
    // starting with the left child node if it is not null 
    // if it is the first node in the level, we save it as the nextHead and as our previous node
    // if it is not then we set the previous node's next to the current node
    // then check the right child node and do the same
    // then the update the previous node with the current node 
    // and then move to the node in the level to the right and connect its children (we can do this because we will have already linked it in the previous iteration)
    // when our next node is null we know we have reached the end of the current level and we move to the next level by setting the current node to the nextHead 
    // and resetting the nextHead and previous node to null

    // this will run in O(n) time (seeing each node only once) and O(1) space because we are only storing three pointers to individual nodes at any given time

    public TreeNode ConnectConstantSpace(TreeNode root)
    {
        TreeNode nextHead = null; //head of the next level
        TreeNode prev = null; //the leading node on the next level
        TreeNode cur = root;  //current node of current level

        while (cur != null)
        {
            while (cur != null)
            { //iterate on the current level
                //left child
                if (cur.left != null)
                {
                    if (prev != null)
                    {
                        prev.next = cur.left;
                    }
                    else
                    {
                        nextHead = cur.left;
                    }
                    prev = cur.left;
                }
                //right child
                if (cur.right != null)
                {
                    if (prev != null)
                    {
                        prev.next = cur.right;
                    }
                    else
                    {
                        nextHead = cur.right;
                    }
                    prev = cur.right;
                }
                //move to next node
                cur = cur.next;
            }

            //move to next level
            cur = nextHead;
            nextHead = null;
            prev = null;
        }

        return root;
    }
}

