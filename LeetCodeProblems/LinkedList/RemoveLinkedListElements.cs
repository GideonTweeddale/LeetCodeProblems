namespace LeetCodeProblems.LinkedList;
public class RemoveLiknedListElements
{
    public ListNode? RemoveElements(ListNode head, int val)
    {
        // iterate through the nodes
        // if a node val equals the val set the next val of the previous node to the next node
        // return head
        // this should run in O(n) time and O(1) space

        if (head == null)
        {
            return null;
        }

        if (head.next == null && head.val != val)
        {
            return head;
        }

        ListNode? previous = head;
        ListNode? current = head.next;

        while (current != null)
        {

            if (current.val == val)
            {
                // cut the current element out
                previous.next = current.next;
            }
            else
            {
                previous = current;
            }

            current = current.next;
        }

        if (head.val == val)
        {
            head = head.next;
        }

        return head;
    }
}


