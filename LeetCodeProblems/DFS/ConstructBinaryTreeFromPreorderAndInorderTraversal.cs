namespace LeetCodeProblems.DFS;

using LeetCodeProblems.Nodes;
public class ConstructBinaryTreeFromPreorderAndInorderTraversal
{
    // intuition
    // we need to use the inorder tree to tell us when the grandchildren belong to the right or the left child
    // the first value of the preorder list is always the root of the tree
    // which means that if we can work out where to partition our preorder list into left and right, we can call the function recursively
    // adding the root as the left node, until we only have a single node, and we add it as the right node
    // we can tell which values go into our left subtree because they will come before our root value in the inorder subtree

    // this will be O(n^2) time complexity because we are iterating over our entire preorder array n and finding the index of our item in our array inorder n (where n is the length both arrays)
    // this is an O(n) operation inside of an O(n) operation or O(n^2)
    // the only additional space complexity is the stack frames from the recursive function, which is O(n)
    // because the array slices are implemented as views in C# taking only constant extra space
    public static TreeNode? BuildTree(int[]? preorder, int[]? inorder)
    {
        if (preorder == null || preorder.Length == 0 || inorder == null || inorder.Length == 0)
        {
            return null;
        }

        TreeNode root = new(preorder[0]);
        int mid = Array.IndexOf(inorder, root.val);
        root.left = BuildTree(preorder[1..(mid+1)], inorder[..mid]);
        root.right = BuildTree(preorder[(mid + 1)..], inorder[(mid + 1)..]);
        return root;
    }

    // we could solve this in O(n) time if we used a hashmap to store the indexes of the values in the inorder array
    // (if the values in the binary tree are unique - I am going to assume that they are)
    public static TreeNode? BuildTreeHashMap(int[] preorder, int[] inorder)
    {
        int preorderIndex = 0; // Initialize the starting index for preorder traversal
        Dictionary<int, int>  inorderIndexMap = [];
        
        // Build a map of each value to its index in the inorder array
        for (int i = 0; i < inorder.Length; i++)
        {
            inorderIndexMap[inorder[i]] = i;
        }

        return ArrayToTree(0, preorder.Length - 1);

        // DFS helper function
        TreeNode? ArrayToTree(int left, int right)
        {
            if (left > right)
            {
                return null;
            }

            // Select the current root's value from the preorder traversal
            int rootVal = preorder[preorderIndex++];
            TreeNode root = new(rootVal);

            // Build the left and right subtrees
            root.left = ArrayToTree(left, inorderIndexMap[rootVal] - 1);
            root.right = ArrayToTree(inorderIndexMap[rootVal] + 1, right);

            return root;
        }
    }
}

