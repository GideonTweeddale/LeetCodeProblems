namespace LeetCodeProblems.BinaryTree;

using LeetCodeProblems.Nodes;

public class ConstructBinaryTreeFromInorderAndPostorderTraversal

{
    // the postorder array tells us that for any given node, the parent must come after it, making the last node our root node
    // the inorder array tells us which nodes are in the left and right subtrees for any given node
    // so, we can set the last node in the post order tree to be our root
    // and then call the same function recursively on the left and right subtrees, which are the elements to the left and right of our root value in inorder tree
    // then we assign the return values to our left and right nodes
    // and return the root node

    // this is big O(n^2) because of the index lookup within each node node
    // let's make it O(n) with a hashmap
    // there is an index error in here somewhere TODO
    public static TreeNode BuildTreeA(int[] inorder, int[] postorder) {
        Dictionary<int, int> map = []; // <value, index>

        for (int i = 0; i < inorder.Length; i++)
        {
            map.Add(inorder[i], i);
        }

        return Helper(inorder, postorder);

        TreeNode Helper(int[] inorder, int[] postorder)
        {
            if (inorder.Length == 1)
            {
                return new TreeNode(inorder[0]);
            }

            TreeNode root = new(postorder[^1]);
            int rootIndex = map[root.val];

            root.left = Helper(inorder[..rootIndex], postorder[..rootIndex]);
            root.right = Helper(inorder[(rootIndex+1)..], postorder[rootIndex..^1]);

            return root;
        }
    }

    // neetcode solution
    // O(n) time and space  

    public static TreeNode? BuildTree(int[] inorder, int[] postorder) {
        int fromEnd = 1;
        Dictionary<int, int> map = []; // <value, index>

        for (int i = 0; i < inorder.Length; i++)
        {
            map.Add(inorder[i], i);
        }

        return Helper(0, inorder.Length - 1);

        TreeNode? Helper(int left, int right)
        {
            if (left > right)
            {
                return null;
            }

            TreeNode root = new(postorder[^fromEnd++]);

            int rootIndex = map[root.val];

            root.right = Helper(rootIndex + 1, right);
            root.left = Helper(left, rootIndex - 1);

            return root;
        }
    }    
}

