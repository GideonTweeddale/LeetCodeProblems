namespace LeetCodeProblems.TwoPointer;

using LeetCodeProblems.Nodes;

public class RotateList
{
    // intuition
    // save a reference to the first node
    // iterate over the list until we reach the kth node - this becomes the new last node in the list
    // save a reference to k and then set k.next o null
    // continue iterating until we find the final node
    // set the final node.next to the first node
    // return k.next as the head

    // Time complexity: O(n) space complexity: O(1)

    // question: what if k is greater than the length of the list?
    // if k is greater than the length of the list, we can just take the remainder of k / length of the list
    // because if we rotate the list by the length of the list, we will get the same list

    public static ListNode RotateRight(ListNode head, int k)
    {
        // edge case - head is null or head.next is null || k is zero
        if (head == null || head.next == null || k == 0)
        {
            return head;
        }

        ListNode dummy = new ListNode(0, head);

        // we need to find the length of the list
        int length = 0;
        ListNode current = head;
        while(current != null)
        {
            length++;
            current = current.next;
        }

        // deal with k being greater than the length of the list by dividing by the length of the list and taking the remainder as k
        if (k > length)
        {
            k = k % length;
        }

        // edge case - k == the length of the list or is a multiple of the length of the list
        if (k == 0)
        {
            return head;
        }

        ListNode nodeK = dummy;
        current = dummy;

        // find the kth node - and find the final node in the list
        for (int i = 0; i < length; i++) 
        {
            if (i == length - k)
            {
                nodeK = current;
            }

            current = current.next;
        } 

        // save a reference to the new head
        ListNode newHead = nodeK.next;

        // set the kth node.next to null making it the new end node
        nodeK.next = null;

        // set the final node.next to the original head, attaching it to the beginning of the list
        current.next = head;

        return newHead;
    }
}

