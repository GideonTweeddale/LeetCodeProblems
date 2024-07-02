namespace LeetCodeProblems.BinaryTree;
public class AverageOfLevelsInABinaryTree
{

    public static IList<double> AverageOfLevels(TreeNode root)
    {
        // bfs is required here - which should be O(N) time complexity and space complexity of roughly O(N) 

        // handle null or childless root
        if (root == null)
        {
            return new List<double>() { 0 };
        }

        if (root.left == null && root.right == null)
        {
            return new List<double>() { root.val };
        }

        Queue<TreeNode> queue = new();
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
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }

            averages.Add(sum / count);
        }

        return averages;
    }
}

