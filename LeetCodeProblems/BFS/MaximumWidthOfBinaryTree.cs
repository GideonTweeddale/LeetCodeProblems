namespace LeetCodeProblems.BFS;

using LeetCodeProblems.Nodes;
public class MaximumWidthOfBinaryTree
{
    // note to the future - working this one out was a bit of a journey. If you want to skip that journey - hop to the last two solutions.
    // (of which the BFS solution is the better solution for speed and memory efficiency)
    // the BFS solution is O(n) time because it iterates through the entire tree
    // and O(n) space because the Queue could have the entire tree in it (although this would only be if the tree was very small)
    // the DFS solution is O(n) time becuase it also iterates through the entire tree, however, it is slower in practive
    // and O(n) space because of the stack frames, however it takes more memory in practice
    // note that the HashMap is O(n) space as well, when there is only one node in the tree, but in practice absolutely tiny with only one value for each level

    // intuition
    // the maximum width of a level of the binary tree is effectively double the number of levels
    // less any null nodes outside of actual nodes in the level

    // could any level other than the last level, be the maximum? 
    // yes. Imagine a tree [1,3,2,5,11,8,9,null,null,null,6,7] where on the last level the only valid nodes are next to each other
    // but on the level above the nodes are filled in across the width of the tree
    // in this case, the 4th level has a max width of 2, while the third level has a max width of 4.

    // this means that we need to count the width of all the nodes
    // we could do DFS or BFS, keeping track of the level, and counting the real nodes on the level, plus any null nodes inbetween real nodes
    // the problem here is that I'm not sure how you'd know if a node was between real nodes

    // this is a simple binary tree, not a binary search tree. Meaning that the values in the nodes hold no useful significance.

    // with BFS, we could count the descendants while iterating over the level before. 
    // we start counting into a temporary variable for the level once we find a left value
    // and we commit the temp count to our hashset for the levels once we have a right value, and reset the temp count
    // we do this until we finish dequeing the parent nodes and throw out any temp count that never matched a right value
    // we wouldn't even need a hashset, just a max level int. If the count for a level ever exceeded the max count, we would update it
    // at the end we just return the count
    // this would be O(n) time and O(1) space

    // to do the same thing with DFS we would need some kind of structure to store the left and right values for a level and the counts for a level
    // because we wouldn't be iterating over a given level all in one go
    // we could use a hashset with the level number as the key, to store the count, temp count, and if we have a left value
    // then we could do the calculation in essentially the same way

    // BFS solution - O(n) time O(1) space
    // this does not work - because we should be including inner null children of inner null children
    public int WidthOfBinaryTreeWrong(TreeNode root)
    {
        if (root == null) return 0;
        if (root.left == null && root.right == null) return 1;

        int maxWidth = 0;

        Queue<TreeNode> q = new();
        q.Enqueue(root);

        while (q.Any())
        {
            int qCount = q.Count;
            int levelCount = 0;
            int workingCount = 0;
            bool leftOuterNode = false;

            for (int i = 0; i < qCount; i++)
            {
                TreeNode node = q.Dequeue();

                if (node.left != null)
                {
                    q.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    q.Enqueue(node.right);
                }

                if (leftOuterNode || node.left != null)
                {
                    workingCount += 1;
                    leftOuterNode = true;
                }

                if (leftOuterNode || node.right != null)
                {
                    workingCount += 1;
                    leftOuterNode = true;
                }

                if (node.right != null || node.left != null)
                {
                    levelCount += workingCount;
                    workingCount = 0;
                }
            }

            maxWidth = Math.Max(maxWidth, levelCount);
        }

        return maxWidth;
    }

    // this makes me think that the solution to this problem is actually about finding the out left and right nodes at each level, and their position
    // we could do this with a DFS where we increment a count for each right child node we go down, and decrement it for each left child node we go down
    // we save these values to a Hashmap with a key of the level -- keeping the lowest number and the highest number for each level
    // at the end, we run through our hashmap and the count for each level would be the difference between the highest and lowest value
    // this would be O(2n) or (n) worst case time because we would be iterating through every node and then again through the hashmap of levels
    // and O(n) worst case space because our hashmap might include a value for every node if we only have one node at each level

    // DFS solution - this could also easily be BFS but I already did a BFS (incorrectly) above so let's practice DFS
    // that didn't work either
    public int WidthOfBinaryTreeAlsoWrong(TreeNode root)
    {
        Dictionary<int, (int, int)> levels = new();

        DFS(root.left, 1, -1);
        DFS(root.right, 1, 1);

        int maxWidth = 1;

        foreach (KeyValuePair<int, (int, int)> level in levels)
        {
            int count = Math.Abs(level.Value.Item2) + Math.Abs(level.Value.Item1);
            maxWidth = Math.Max(maxWidth, count);
        }

        return maxWidth;

        // dfs helper function
        void DFS(TreeNode node, int level, int count)
        {
            if (node == null) return;

            // update the level
            level += 1;

            if (!levels.ContainsKey(level)) levels.Add(level, (0, 0));

            // update the left value if lower or the right value if higher
            if (count < levels[level].Item1)
            {
                levels[level] = (count, levels[level].Item2);
            }
            else if (count > levels[level].Item2)
            {
                levels[level] = (levels[level].Item1, count);
            }

            DFS(node.left, level, count - 1);
            DFS(node.right, level, count + 1);
        }
    }

    // instead of counting steps, let's give each node a that matches it's relative position in the tree
    // we can do this by doubling the previous value for a left node and doubling the previous value plus one for a right node
    // then at the end, we simply subtract the lowest node from the highest node to get the difference (plus 1)
    // let's do this BFS style
    public int WidthOfBinaryTreeBFSCountingSteps(TreeNode root)
    {
        int maxWidth = 0;

        Queue <QueueVal> q = new();
        q.Enqueue(new QueueVal(root, 1, 0));

        int prevLevel = 0;
        int prevNum = 1;

        while (q.Any())
        {
            QueueVal val = q.Dequeue();

            if (val.level > prevLevel)
            {
                prevLevel = val.level;
                prevNum = val.num;
            }

            maxWidth = Math.Max(maxWidth, val.num - prevNum + 1);

            if (val.node.left != null)
            {
                q.Enqueue(new QueueVal(val.node.left, 2 * val.num, val.level + 1));
            }
            if (val.node.right != null)
            {
                q.Enqueue(new QueueVal(val.node.right, 2 * val.num  + 1, val.level + 1));
            }
        }

        return maxWidth;
    }

    private struct QueueVal
    {
        public QueueVal(TreeNode _node, int _num, int _level)
        {
            node = _node;
            num = _num;
            level = _level;
        }

        public TreeNode node;
        public int num;
        public int level;
    }

    // let's apply the counting steps idea to our DFS from above
    public int WidthOfBinaryTree(TreeNode root)
    {
        Dictionary<int, int> levels = new();

        int maxWidth = 0;

        DFS(root, 0, 0);

        return maxWidth;

        // dfs helper function
        void DFS(TreeNode node, int level, int count)
        {
            if (node == null) return;

            // update the level
            level += 1;

            // with DFS this will always happen on the leftmost node
            if (!levels.ContainsKey(level)) levels.Add(level, count);

            maxWidth = Math.Max(maxWidth, count - levels[level] + 1);

            DFS(node.left, level, count * 2);
            DFS(node.right, level, count * 2 + 1);
        }
    }

}

