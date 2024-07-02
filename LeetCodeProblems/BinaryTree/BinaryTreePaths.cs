namespace LeetCodeProblems.BinaryTree;
public class BinaryTreePaths257
{
    
    public IList<string> BinaryTreePaths(TreeNode root)
    {
        // DFS the tree. Pass the current string path down, along with the paths list
        // When we reach a leaf, add the complete path and return
        // This should visit each node once, completing in O(N) time and the paths list etc. shouldn't take up more than O(N) space (max one path per leaf node)
        // But there is a lot of string manipulation which should be fairly slow
        // Also, I don't love passing so much state. It doesn't make for the clearest code
        // There must be a more elegant way, perhaps with some kind of backtracking

        List<string> paths = new();

        if (root == null)
        {
            return paths;
        }

        if (root.left != null)
        {
            BinaryTreePath(root.left, $"{root.val}", paths);
        } 
        
        if (root.right != null)
        {
            BinaryTreePath(root.right, $"{root.val}", paths);
        }

        if (root.left == null && root.right == null)
        {
            paths.Add($"{root.val}");
        }

        return paths;
    }

    private bool BinaryTreePath(TreeNode node, string path, List<string> paths)
    {
        if (node == null)
        {
            return false;
        }

        string newPath = $"{path}->{node.val}";

        if (node.left == null && node.right == null) // leaf node
        {
            paths.Add(newPath);
        }
        else
        {
            if (node.left != null)
            {
                BinaryTreePath(node.left, newPath, paths);
            }

            if (node.right != null)
            {
                BinaryTreePath(node.right, newPath, paths);
            }
        }

        return true;
    }

    public IList<string> BinaryTreePathsB(TreeNode? root)
    {
        // We can at least clean this up a little - for example the child node null checks are redundant
        // Woah. With the cleanup, this solution beats more than 86% of others.
        // I'd still like to rewrite it to use less variable passing for clarity though.

        List<string> paths = new();
        if (root == null)
        {
            return paths;
        }

        string path = $"{root.val}";

        BinaryTreePathB(root.left, path, paths);
        BinaryTreePathB(root.right, path, paths);

        if (root.left == null && root.right == null)
        {
            paths.Add(path);
        }

        return paths;
    }

    private void BinaryTreePathB(TreeNode? node, string path, List<string> paths)
    {
        if (node == null)
        {
            return;
        }

        string newPath = $"{path}->{node.val}";

        if (node.left == null && node.right == null) // leaf node
        {
            paths.Add(newPath);
        }
        else
        {
            BinaryTreePathB(node.left, newPath, paths);
            BinaryTreePathB(node.right, newPath, paths);
        }
    }
}

