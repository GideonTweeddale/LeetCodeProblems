namespace LeetCodeProblems.BinaryTree;
public class MergeTwoBinaryTrees
{
    public static TreeNode MergeTrees(TreeNode root1, TreeNode root2)
    {
        // traverse down the trees simultanuesly 
        // if either tree is has no further nodes, attach the next node (and so all subsequent nodes) of the other tree
        // set the value of the current node to the combined value of the two present nodes
        // this should complete in O(N) time and O(N) space, where N is the number of overlapping nodes in both trees
        if (root1 == null)
        {
            return root2;
        }

        if (root2 == null)
        {
            return root1;
        }

        root1.val += root2.val;

        root1.left = MergeTrees(root1.left, root2.left);
        root1.right = MergeTrees(root1.right, root2.right);

        return root1;
    }
    public TreeNode MergeTreesB(TreeNode root1, TreeNode root2)
    {
        // this solution should be really similar, but creates new nodes/a new tree instead of overwriting root1
        // this behaved exactly as I expected and ran in roughly the same time, while using slightly more memory
        // it shouldd be O(N) time and O(2N) space, because of the combination of the stack depth and the new tree
        if (root1 == null)
        {
            return root2;
        }

        if (root2 == null)
        {
            return root1;
        }

        TreeNode? result = new(root1.val + root2.val, MergeTrees(root1.left, root2.left), MergeTrees(root1.right, root2.right));

        return result;
    }
}

