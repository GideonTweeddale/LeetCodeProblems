namespace LeetCodeProblems.BinaryTree;
public class SameTree
{

    // Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        // bfs (or level order traversal) iterate through booth trees at the same time, comparing the nodes
        // if we find any that don't match - exit with false
        // this should be O(N) time complexity and O(N) space complexity in the worst case where the two lists have only one level

        if (p == null && q == null)
            return true;
        
        if (p == null || q == null)
            return false;

        // bfs search
        Queue<TreeNode> pq = new();
        Queue<TreeNode> qq = new();
        pq.Enqueue(item: p);
        qq.Enqueue(item: q);

        while (pq.Any() && qq.Any())
        {
            int count = pq.Count;

            for (int i = 0; i < count; i++)
            {
                TreeNode pNode = pq.Dequeue();
                TreeNode qNode = qq.Dequeue();

                if ((pNode.val != qNode.val))
                    return false;

                if (pNode.right != null && qNode.right != null)
                {
                    pq.Enqueue(pNode.right);
                    qq.Enqueue(qNode.right);
                } 
                else if (pNode.right != null || qNode.right != null)
                {
                    return false; // one node has a child and the other doesn't
                }

                if (pNode.left != null && qNode.left != null)
                {
                    pq.Enqueue(pNode.left);
                    qq.Enqueue(qNode.left);
                }
                else if (pNode.left != null || qNode.left != null)
                {
                    return false; // one node has a child and the other doesn't
                }
            }

        }

        return true;
    }

    public bool IsSameTreeDFS(TreeNode p, TreeNode q)
    {
        // dfs recursive solution - should be O(N) time complexity and O(N) space complexity in the worst case
        // the code is much more concise - but should be a little slower

        if (p == null && q == null)
            return true;
        
        if (p == null || q == null)
            return false;

        if (p.val != q.val) 
            return false;

        return IsSameTreeDFS(p.left, q.left) && IsSameTreeDFS(p.right, q.right);
    }
}

