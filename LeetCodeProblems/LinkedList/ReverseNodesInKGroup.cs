
namespace LeetCodeProblems.LinkedList;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class ReverseNodesInKGroup
{
    // intuition
    // the naive solution would be to create an array of size k
    // iterate over the linked list assiging each node to indexes in k until k is full
    // and then to iterate back over k reassigning the pointers until is empty
    // then continuing further over the linked list, until we reach the end of the linked list

    // however, the question asks for a solution using O(1) extra memory
    // which means we need to do an in place linked list manipulation

    // [1,2,3,4,5]
    // 1: save 1 as the first node in the group
    // 2: set 2 to point to 1
    // 3: exceeded k, set first node 1 to point to 3, save 1 as previous group, set first node to 3
    // 4: set 4 to point 3
    // 5: exceeded k, set 

    // to do this, we need to think of the list as three sublists 
    // sublist one is group one
    // sublist two is group two
    // sublist three is the rest of the list

    // we iterate over the list, kth node
    // then we store a pointer to the start of the next group 
    // reverse our group
    // if we have a pointer to a previous group
    // set it to the new beginning of our group
    // and store a pointer to the end of our current group as the previous group

    // then repeat until we have less than k nodes remaining

    // k=3 [1,2,3,4,5,6,7,8]
    // [dummy,1,2,3,4,5,6,7,8] previous node = dummy, kth node = 3, next node = 4
    // [dummy,3,2,1,4,5,6,7,8] previous node = 1, kth node = 6, next = 7
    // [dummy,3,2,1,6,5,4,7,8] previous node = 4, kth node = null

    public ListNode ReverseKGroup(ListNode head, int k)
    {
        ListNode dummy = new(0);
        dummy.next = head;

        ListNode previousNode = dummy;

        while (true)
        {
            // find the kth node
            ListNode? kthNode = GetKthNode(previousNode, k);

            // if there isn't a kth node, we are done
            if (kthNode == null)
            {
                break;
            }

            // find the next node so that we can start our next group when we are done with this group
            ListNode nextNode = kthNode.next;

            // reverse from previous.next to next
            ReverseLinkdedList(previousNode.next, kthNode.next, nextNode);

            ListNode temp = previousNode.next;

            // set the next pointer of the previous node to the kth node, which is now the start of the group
            previousNode.next = kthNode;

            // set what was the first node in the group and is now the last to be our new previous node
            previousNode = temp;
        }

        return dummy.next;
    }

    private static void ReverseLinkdedList(ListNode current, ListNode previous, ListNode nextNode)
    {
        // until we reach the end of the group
        while (current != nextNode)
        {
            ListNode next = current.next;

            // set the current node to point to the previous
            current.next = previous;

            // set the previous to be the current
            previous = current;

            // set the current to be the next node
            current = next;
        }
    }

    private static ListNode? GetKthNode(ListNode node, int k)
    {
        while (node != null && k > 0)
        {
            node = node.next;
            k--;
        }

        return node;
    }
}


