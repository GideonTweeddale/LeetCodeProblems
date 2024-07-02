namespace LeetCodeProblems.BinaryTree;
public class  SumRootToLeafNumbers
{
    // we can solve this in O(n) time by recursively traversing the tree to all the leaf nodes
    // adding the value of the nodes along the way
    // then summing all the values of the paths up on the way back

    // this could be faster if we weren't adding strings together
    
    public int SumNumbers(TreeNode root) => SumPath(root, 0);

    private int SumPath(TreeNode? node, int pathSum)
    {
        if (node == null)
        {
            return 0;
        }

        pathSum = pathSum * 10 + node.val;

        if (node.left == null && node.right == null)
        {
            return pathSum;
        }

        return SumPath(node.left, pathSum) + SumPath(node.right, pathSum);
    }
}

