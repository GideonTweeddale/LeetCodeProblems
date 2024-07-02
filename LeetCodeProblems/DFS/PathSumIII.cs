namespace LeetCodeProblems.DFS;

using LeetCodeProblems.Nodes;
public class PathSumIII
{
    // intuition
    // we can solve this in O(n log n) or O(n) time by calling our DFS recursion on the left and right children for each node both with the node added and without the node added
    // whenever our sum equals the target sum we add the path
    // when we reach a leaf node, we return
    // we call the DFS for left and right with a fresh sum  and call the DFS for left and right with the sum of the previous

    public static int PathSumA(TreeNode root, int targetSum)
    {
        if (root == null)
        {
            return 0;
        }

        int pathsCount = 0;

        DFS(root, 0);

        return pathsCount;

        // helper DFS function
        void DFS(TreeNode? node, int sum)
        {
            if (node == null)
            {
                return;
            }

            sum += node.val;

            if (sum == targetSum)
            {
                pathsCount++;
            }

            // DFS the children with the parent
            DFS(node.left, sum);
            DFS(node.right, sum);

            // DFS the children starting with a fresh sum
            DFS(node.left, 0);
            DFS(node.right, 0);
        }
    }

    // for each node, we get from our dictionary the number of paths to the current sum - the target sum
    // for each node, we add 1 to the value in our dictionary for key of the cummulative sum for it and all previous nodes
    // for example, for the right child of a root 10 with value 5, we add one to the value at key 15 in our dictionary
    // TODO come back to this problem. The solution doesn't really make sense to me.

    public static int PathSum(TreeNode root, int targetSum)
    {
        // the working number paths we can take to a given sum
        Dictionary<int, int> prefixSumCount = [];
        prefixSumCount[0] = 1;

        return CountPaths(root, 0); 
        
        int CountPaths(TreeNode? node, int lastSum)
        {
            if (node == null)
            {
                return 0;
            }

            int currentSum = lastSum + node.val;

            // check if currentSum has changed from - to + or + to -
            if ((lastSum ^ currentSum) < 0 && (node.val ^ currentSum) < 0)
            {
                return 0;
            }

            // get the number of ways that we can reach a given sum 
            int pathCount = prefixSumCount.GetValueOrDefault(currentSum - targetSum, 0);

            // increment the ways that we can reach the current sum - because we have just found another one
            prefixSumCount[currentSum] = prefixSumCount.GetValueOrDefault(currentSum, 0) + 1;

            // count the paths for the left and right subtrees
            int leftPaths = CountPaths(node.left, currentSum);
            int rightPaths = CountPaths(node.right, currentSum);

            // decrement the number paths to the current sum because any nodes reached higher up the tree won't have access to this path
            prefixSumCount[currentSum] -= 1;

            return pathCount + leftPaths + rightPaths;
        }
    }

    
}

