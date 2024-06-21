namespace LeetCodeProblems.BinaryTree;
public class FlattenBinaryTreeToLinkedList

{
    // preorder is node->leftsubstree->rightsubtree recursively
    // we can do this in O(n) time, visiting each node once
    // I don't think it is possible to do it faster because we need to change the pointers on every node
    // and we need to visit the last node to know that it is the last node

    // the trick is to recurse right first and find the final node
    // and the build the linkedlist up in reverse

    public void Flatten(TreeNode root) 
    {
        if (root == null) return;
        Flattener(root, null);
    } 

    private void Flattener(TreeNode node, TreeNode tail)
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
}

