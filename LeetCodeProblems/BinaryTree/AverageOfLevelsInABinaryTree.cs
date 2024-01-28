namespace LeetCodeProblems.BinaryTree;
public class AverageOfLevelsInABinaryTree
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
    public IList<double> AverageOfLevels(TreeNode root)
    {
        // bfs is required here - which should be O(n) time complexity and space complexity of roughly O(n) 

        // handle null or childless root
        if (root == null)
            return new List<double>() { 0 };

        if (root.left == null && root.right == null)
            return new List<double>() { root.val };

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        List<double> averages = [];

        while (queue.Any())
        {
            int count = queue.Count;
            double sum = 0;

            for (int i = 0; i < count; i++)
            {
                TreeNode node = queue.Dequeue();
                sum += node.val;

                if (node.left != null)
                    queue.Enqueue(node.left);

                if (node.right != null)
                    queue.Enqueue(node.right);
            }

            averages.Add(sum / count);
        }

        return averages;
    }
}

