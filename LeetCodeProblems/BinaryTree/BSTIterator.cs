namespace LeetCodeProblems.BinaryTree;
public class BSTIterator

{
    // if we could change the definition of TreeNode
    // to include a reference to the parent
    // then we could return Next and HasNext in O(1) time and O(1) space
    // then when next is called we can return the current node and navigate to the next smallest node
    // using the properties of a binary search tree
    // if we don't have a node in our next node pointer, then hasnext returns false

    // I don't think we can though. So instead, we can have a list with the nodes in the current minimum path
    // if we use a stack, the management is even simpler
    // when next is called, pop the smallest node from the stack
    // and then add the right child and the left children of the right child to the stack, if they exists

    // this will be O(k) memory and will be average O(1) for both Next and HasNext

    private Stack<TreeNode> stack;

    public BSTIterator(TreeNode root) {
        stack = new();
        stack.Push(root);
        FillLeft(root);
    }
    
    public int Next() {
        if (stack.Count < 1) return -1; // we should throw an error because this violates the constraints

        TreeNode node = stack.Pop();

        if (node.right != null)
        {
            stack.Push(node.right);
            FillLeft(node.right);            
        }

        return node.val;
    }
    
    public bool HasNext() {
        return stack.Count > 0;
    }

    private void FillLeft(TreeNode node)
    {        
        while (node.left != null)
        {
            stack.Push(node.left);
            node = node.left;
        }
    }
}

