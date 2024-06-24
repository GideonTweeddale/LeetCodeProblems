namespace LeetCodeProblems.BinaryTree;
public class ConstructBinaryTreeFromInorderAndPostorderTraversal

{
    // the postorder array tells us that for any given node, the parent must come after it, making the last node our root node
    // the inorder array tells us which nodes are in the left and right subtrees for any given node
    // so, we can set the last node in the post order tree to be our root
    // and then call the same function recursively on the left and right subtrees, which are the elements to the left and right of our root value in inorder tree
    // then we assign the return values to our left and right nodes
    // and return the root node

    public TreeNode BuildTree(int[] inorder, int[] postorder) {
        if (inorder.Length != postorder.Length || inorder.Length == 0) return null;

        if (inorder.Length == 1) return new TreeNode(inorder[0]);

        TreeNode root = new TreeNode(postorder[^1]);

        // find the root index
        int rootIndex = Array.IndexOf(inorder, postorder[^1]);
        // int rootIndex = int.MaxValue;

        // for (int i = 0; i < inorder.Length; i++)
        // {
        //     if (inorder[i] == root.val)
        //     {
        //         rootIndex = i;
        //         break;
        //     }
        // }

        root.left = BuildTree(inorder[..rootIndex], postorder[..rootIndex]);
        root.right = BuildTree(inorder[(rootIndex+1)..], postorder[rootIndex..^1]);

        return root;
    }
}

