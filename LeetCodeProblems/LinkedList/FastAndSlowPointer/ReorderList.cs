namespace LeetCodeProblems.FastAndSlowPointer;

using LeetCodeProblems.Nodes;

public class ReorderList143
{
    // intuition
    // split the list in two
    // reverse the second half of the list
    // merge the two lists like a zipper

    public void ReorderList(ListNode head)
    {
        ListNode mid = FindMidle(head);
        ListNode right = Reverse(mid.next);
        mid.next = null;

        head = Merge(head, right);
    }

    private ListNode FindMidle(ListNode head)
    {
        ListNode slow = head;
        ListNode fast = head.next;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        return slow;
    }

    private ListNode Reverse(ListNode head)
    {
        ListNode prev = null;
        ListNode current = head;

        while (current != null)
        {
            ListNode next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }

        return prev;
    }

    private ListNode Merge(ListNode left, ListNode right)
    {
        ListNode dummy = new ListNode(0);
        ListNode current = dummy;

        while (left != null && right != null)
        {
            current.next = left;
            left = left.next;

            current.next.next = right;
            right = right.next;

            current = current.next.next;
        }

        if (left != null)
        {
            current.next = left;
        }

        if (right != null)
        {
            current.next = right;
        }

        return dummy.next;
    }
}

