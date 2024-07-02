
namespace LeetCodeProblems.Matrix;

using LeetCodeProblems.Nodes;

public class ReverseLinkedList
{
    // questions
    // are left and right indices or node values?
    // I assume indices
    // yep. Indices

    // intuition
    // there are a few ways we could solve this
    // we could create a reversed linked list in one pass
    // or an array with each of the nodes
    // and then in a second loop, swap the nodes for their opposites (excluding the other nodes)

    // but the question asks if it is possible to do this in one pass (which means that it likely is)
    // and the approach above involves two passes

    // the outer nodes almost don't matter
    // we know the length and relative possitions of the nodes we are swapping based on the difference in position between left and right
    // for example, left = 2 and right = 4 means that we have three positions - 2,3,4 - to rotate
    // with an odd number, we rotate around the center, and swap positions 2 and 4

    // using an array we can still do this in a single pass
    // we iterate through the linked list until we reach position left 
    // and then we add the nodes to an array 
    // until we reach the first position after the midpoint
    // we then reach back into the array and swap the node for it's opposite 
    // and keep iterating and doing this until we reach node at index right

    // the problem with this approach is that we won't have access to the node before the node we are swapping for
    // so we need to add all nodes before index right to the array as we go, including outer nodes before index left

    public ListNode ReverseBetweenA(ListNode head, int left, int right)
    {
        if (right == left) return head;

        ListNode current = head;
        List<ListNode> nodes = [];

        int midpoint = GetMidpoint(left, right);

        // left and right are 1 indexed
        for (int i = 1; i <= right; i++)
        {
            nodes.Add(current);
            current = current.next;

            if (i >= midpoint)
            {
                // the array is 0 indexed
                Swap(left - 1, i - 1);
                left++;
            }
        }

        return head;

        void Swap(int left, int right)
        {
            ListNode leftNode = nodes[left];
            ListNode leftPrev = nodes[left - 1];
            ListNode rightNode = nodes[right];
            ListNode rightPrev = nodes[right - 1];

            // swap the nodes in the linked list
            leftPrev.next = rightNode;
            rightPrev.next = leftNode;
            (leftNode.next, rightNode.next) = (rightNode.next, leftNode.next);

            // swap the nodes in the array
            nodes[left] = rightNode;
            nodes[right] = leftNode;
        }

        int GetMidpoint(int left, int right)
        {
            int midpoint = right - left;

            if (midpoint % 2 == 0) midpoint = midpoint / 2;
            else midpoint = (midpoint + 1) / 2;

            return midpoint + left;
        }   
    }

    // the easier approach is to just treat this a reverse linked list problem of the sub linked list
    // and then at the end just fix the first and last pointers

    public ListNode ReverseBetween(ListNode head, int left, int right)
    {
        if (right == left) return head;
        if (head.next == null) return head;

        ListNode dummy = new ListNode(0, head);

        ListNode first = dummy;
        ListNode current = head;

        // find the previous node and move current to the left node
        for (int i = 0; i < left - 1; i++)
        {
            first = current;
            current = current.next;
        }

        ListNode prev = null;

        for (int i = 0; i < right - left + 1; i++)
        {
            ListNode next = current.next;
            current.next = prev;

            prev = current;
            current = next;
        }

        first.next.next = current;
        first.next = prev;

        return dummy.next;
    }
}