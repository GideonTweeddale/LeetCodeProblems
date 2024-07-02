namespace LeetCodeProblems.LinkedList;
public class ReverseLinkedList
{
    public static ListNode? ReverseList(ListNode head)
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


    // the recursive apporach heavily inspired 
    private ListNode _reversedNode;

    public ListNode? ReverseListRecursive(ListNode head)
    {
        if (head == null)
        {
            return head;
        }

        ListNode last = ReverseNode(head);
        last.next = null;

        return _reversedNode;
    }

    public ListNode ReverseNode(ListNode node)
    {
        if (node.next == null)
        {
            _reversedNode = node;
            return node;
        }

        ListNode next = ReverseNode(node.next);
        next.next = node;
        return node;
    }
}


