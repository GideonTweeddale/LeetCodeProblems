namespace LeetCodeProblems.BinaryTree;
public class FlattenBinaryTreeToLinkedList

{
    // preorder is node->leftsubstree->rightsubtree recursively
    // we can do this in O(n) time, visiting each node once
    // I don't think it is possible to do it faster because we need to change the pointers on every node
    // and we need to visit the last node to know that it is the last node
    // and the memory will be O(h) where h is the height of the tree

    // the trick is to recurse right first and find the final node
    // and the build the linkedlist up in reverse

    public void Flatten(TreeNode root) 
    {
        if (root == null)
        {
            return;
        }

        Flattener(root, null);
    } 

    private static void Flattener(TreeNode node, TreeNode tail)
    {
        if (node.left == null && node.right == null) {
            node.right = tail;
            return;
        }

        if (node.right != null) {
            Flattener(node.right, tail);
        }
        
        if (node.left != null) {
            Flattener(node.left, node.right ?? tail);
            node.right = node.left;
            node.left = null;    
        }
    }

    // to do this more intuitively - at least for me
    // we can go left to right
    public void FlattenB(TreeNode root) => DFS(root);
    private static TreeNode DFS(TreeNode node)
    {        
        if (node == null)
        {
            return null;
        }

        TreeNode leftTail = DFS(node.left);
        TreeNode rightTail = DFS(node.right);

        if (node.left != null)
        {
            leftTail.right = node.right;
            node.right = node.left;
            node.left = null;
        }

        if (rightTail != null)
        {
            return rightTail;
        }

        if (leftTail != null)
        {
            return leftTail;
        }

        return node;
    }
}

