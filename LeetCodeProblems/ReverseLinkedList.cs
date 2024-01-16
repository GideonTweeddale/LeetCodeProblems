namespace LeetCodeProblems;
public class ReverseLinkedList
{
    public ListNode? ReverseList(ListNode head)
    {
        // My first thought is to traverse the list to the end changing the pointers around as we go
        // That solution would be O(n) time and O(1) space
        if (head?.next == null)
        {
            return head;
        }

        ListNode previousNode = head;
        ListNode currentNode = head.next;
        ListNode nextNode;

        // delete first link
        previousNode.next = null;

        while (currentNode.next != null)
        {
            // get next node
            nextNode = currentNode.next;

            // reverse the currentNode link by setting it to the previous node
            currentNode.next = previousNode;

            // set the previousNode
            previousNode = currentNode;

            // move to the next node
            currentNode = nextNode;
        }

        // reverse the last link
        currentNode.next = previousNode;

        return currentNode;
    }

    public class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }
}


