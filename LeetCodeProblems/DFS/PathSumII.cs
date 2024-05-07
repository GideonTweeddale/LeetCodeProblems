namespace LeetCodeProblems.DFS;
public class PathSumII
{
    // intuition
    // DFS with an output list
    // for each recursion, add the value to the working list and the sum
    // call the right and left subtrees
    // remove the value from the list and the sum
    // when we reach a leaf node (a node with no children) if the sum equals the targetSum add the working list to the output list

    // this will visit each node once taking O(n) time
    // the working list will be max O(n) space assuming that the tree is basically a linked list and the output will be max O(n + log n * n) assuming that every leaf node matches the targetSum
    // giving us O(n) time and O(n*log n) space

    public IList<IList<int>> PathSum(TreeNode root, int targetSum)
    {
        List<IList<int>> output = [];

        DFS([], 0, root);

        return output;

        // helper dfs function
        void DFS(List<int> workingList, int sum, TreeNode node)
        {
            // if the node is null return
            if (node == null) return;

            workingList.Add(node.val);
            sum += node.val;

            // if the node is a leaf node and the sum equals the targetSum add the working list to the output list
            if (node.left == null && node.right == null && sum == targetSum)
            {
                output.Add(new List<int>(workingList));
            }

            DFS(workingList, sum, node.left);
            DFS(workingList, sum, node.right);

            // remove the last element from the working list
            workingList.RemoveAt(workingList.Count - 1);
        }
    }
}

