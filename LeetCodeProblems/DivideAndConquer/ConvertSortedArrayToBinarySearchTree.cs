namespace LeetCodeProblems.DivideAndConquer;
public class ConvertSortedArrayToBinarySearchTree

{    
    // intuition
    // we start at the midpoint
    // we call a recursive function that 
    // creates a node out of the midpoint of the array
    // and then calls itself on the left and right sublists
    // and then assigns its left and right children to the node that the calls return

    // this should complete in O(n) time

    public TreeNode SortedArrayToBSTA(int[] nums)
    {
        if (nums == null || nums.Length == 0) return null;

        // get midpoint
        // integer division in C# means that this will default 
        int midIndex = nums.Length/2;
        TreeNode mid = new(nums[midIndex]);

        mid.right = SortedArrayToBST(nums[(midIndex+1)..]);
        mid.left = SortedArrayToBST(nums[..midIndex]);

        return mid;
    }

    // without array slicing for more speed, maybe
    // it doesn't seem any different

    public TreeNode SortedArrayToBSTB(int[] nums)
    {
        if (nums == null || nums.Length == 0) return null;

        return GetBSTFromSortedArray(0, nums.Length - 1);

        // helper
        TreeNode GetBSTFromSortedArray(int left, int right)
        {
            if (left > right) return null;

            int mid = left + (right - left) / 2;
            TreeNode node = new();
            node.val = nums[mid];
            node.left = GetBSTFromSortedArray(left, mid - 1);
            node.right = GetBSTFromSortedArray(mid + 1, right);
            
            return node;
        }
    }    

    // more concise version
    public TreeNode SortedArrayToBST(int[] nums)
    {
        if (nums == null || nums.Length == 0) return null;

        return Helper(0, nums.Length - 1);

        // helper
        TreeNode Helper(int left, int right)
        {
            if (left > right) return null;

            int mid = left + (right - left) / 2;
            
            return new TreeNode(nums[mid], Helper(left, mid - 1), Helper(mid + 1, right));;
        }
    } 
}

// Definition for a binary tree node.
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}


