namespace LeetCodeProblems.TwoPointer;

using LeetCodeProblems.Nodes;

public class SwapNodesInPairs
{
    // intuition
    // iterate through the list two nodes at a time
    // make node1.next point to node 2.next
    // and node2.next point to node1
    // perform the swap before moving two places forward
    // stop if node1 or node2 are null
    // use a dummy node assigned to head.next and return dummy.next at the end to handle the first two nodes being swapped

    // edge cases
    // if head or head.next are null return head   

    // worst case complexity
    // O(N) time where N is the number of nodes in the list and O(1) space

    public static ListNode? SwapPairs(ListNode head)
    {
        // we don't need this check if we init dummy to head and perform a null check on head.next during node2 init
        // because the while check actually handles this condition
        // but this is cleaner (and actually signficantly faster too)
        if (head == null || head.next == null)
        {
            return head;
        }

        ListNode dummy = new(0);
        ListNode? node1 = head;
        ListNode? node2 = head.next;
        ListNode previous = dummy;

        while (node1 != null && node2 != null)
        {
            // swap the nodes
            node1.next = node2.next;
            node2.next = node1;
            previous.next = node2;

            // move two places forward
            previous = node1;
            node1 = node1.next; // node1 has moved one place forward by the swap so it only needs to move one place forward
            node2 = node2.next.next?.next; // has been moved one place back so it needs to move three places forward
        }

        return dummy.next;
    }
}

