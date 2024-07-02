namespace LeetCodeProblems.LinkedList;
public class RemoveDuplicatesFromSortedListII
{
    // intuition
    // we can solve this problem in a single traversal with no extra memory
    // start with a dummy node
    // if our currentNode.next.val != currentNode.next.next.val
    // move forward by setting current = current.next
    // else keep checking until we find a node whose value doesn't equal next.val
    // and set our current to that
    // return dummy.next

    // this will run in O(n) time because we visit each node once
    // and O(1) constant space because we use no additional data structures

    public static ListNode DeleteDuplicates(ListNode head)
    {
        ListNode dummy = new(0, head);
        ListNode current = dummy;
        ListNode next = null;

        while (current != null)
        {
            next = current.next;

            if (next != null && next.next != null && next.val == next.next.val)
            {
                while (next != null && next.next != null && next.val == next.next.val)
                {
                    next = next.next;
                }

                current.next = next.next;
            }
            else
            {
                current = next;
            }
        }

        return dummy.next;
    }
}


