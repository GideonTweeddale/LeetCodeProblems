namespace LeetCodeProblems.FastAndSlowPointer;

using LeetCodeProblems.Nodes;

public class PalindromeLinkedList
{
    public bool IsPalindrome(ListNode head)
    {
        // we find the midpoint of the list and reverse the second half
        // and then iterate through the two halves seeing if they match as we go
        // this solution should be roughly O(n) time and O(1) space

        if (head == null || head.next == null) return true;

        ListNode slow = head;
        ListNode fast = head;
        ListNode previous = null;

        while (fast != null && fast.next != null)
        {
            fast = fast.next.next;

            ListNode next = slow.next;
            slow.next = previous;
            previous = slow;
            slow = next;
        }

        // if list has odd number of elements skip middle element
        if (fast != null)
        {
            slow = slow.next;
        }

        // compare first and second half of the list
        while (slow != null)
        {
            if (slow.val != previous.val) return false;

            slow = slow.next;
            previous = previous.next;
        }

        return true;
    }
}


