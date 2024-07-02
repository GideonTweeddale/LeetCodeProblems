namespace LeetCodeProblems.LinkedList;
public class PartitionList
{
    // new intution
    // iterate through the linked list creating two new linked lists, left and right
    // attach the two lists together and return

    public static ListNode Partition(ListNode head, int x)
    {
        ListNode left = new(0);
        ListNode right = new(0);
        ListNode leftTail = left;
        ListNode rightTail = right;

        while (head != null)
        {
            if (head.val < x)
            {
                leftTail.next = head;
                leftTail = leftTail.next;
            }
            else
            {
                rightTail.next = head;
                rightTail = rightTail.next;
            }

            head = head.next;
        }

        leftTail.next = right.next;
        rightTail.next = null;

        return left.next;
    }

    // intuition
    // we can solve this using two pointers
    // one pointer for the current
    // one pointer for the elements that come before the val
    // iterate through the list for each node
    // if it is smaller than our val
    //      remove it from the linked list by making the previous node.next point to the next node
    //      then insert the node at the pointer for our prepartition 
    //      by making the node.next point to the prepartition.next 
    //      and then making the prepartition.next the node 
    //      and finally making the prepartition the node

    // this runs in O(n) time and O(1) space 
    // because it iterates through the linked list only once
    // and it uses no additional datastructures

    // handle head being null

    public static ListNode? PartitionB(ListNode head, int x)
    {
        if (head == null)
        {
            return null;
        }

        ListNode dummy = new(0, head);
        ListNode current = dummy;
        ListNode partition = dummy;

        while(current.next != null)
        {
            if (current.next != null && current.next.val < x)
            {
                ListNode node = current.next;

                // remove the node from the list
                current.next = current.next.next;

                // insert at the prepartition node
                node.next = partition.next;

                // attach the partition node to the node we are moving
                partition.next = node;

                // set our new partition node
                partition = node;
            }
            else
            {
                current = current.next;
            }
        }

        return dummy.next;
    }
}


