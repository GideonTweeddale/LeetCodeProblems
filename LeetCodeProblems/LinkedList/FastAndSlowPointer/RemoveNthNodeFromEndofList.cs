namespace LeetCodeProblems.FastAndSlowPointer;

using LeetCodeProblems.Nodes;

public class RemoveNthNodeFromEndofList
{
    // we need two things to make the update
    // 1. the node before the nth node
    // 2. the node after the nth node
    // when we have both we can update the nth-1 node.next pointer to the nth+1 node pointer
    // thereby removing the nth node and then return the head
    // to do this we need to iterate through the linked list until we reach the node n+1 or the end of the list (in the case where the nth node is the last node)
    // while doing this, we need to save a pointer to the nth-1 node
    // in the case where we reach n+1, make the change. If we reach the end of the list, simply set the n-1 next to null
    // this should take O(n) time and O(1) space

    // [1,2,3,4,5] n = 2
    // n-1 == 1, n+1 == 3
    // 1. 0(i) != 1, current != null and 0(i) != 3
    // 2. 1 == 1 (set prev), current != null and 1 != 3
    // 3. 2 != 1, current != null and 2 != 3
    // 3. 3 != 1, current != null and 3 == 3 (set prev.next to current)

    public ListNode RemoveNthFromEndA(ListNode head, int n)
    {
        ListNode? current = head;
        ListNode? prev = null;

        for (int i = 0; i <= n + 1; i++)
        {
            if (i == n - 1)
            {
                prev = current;
            }

            if (current == null || i == n + 1)
            {
                prev.next = current;
                return head;
            }

            current = current.next;
        }

        return head;
    }

    // we could make this even fast by setting prev.next to prev.next.next immediately after setting prev
    // we could even get rid of the prev variable and just set current.next to current.next.next when we reach n-1

    public ListNode RemoveNthFromEndB(ListNode head, int n)
    {
        if (head == null || head.next == null)
        {
            return null;
        }

        ListNode? current = head;

        for (int i = 0; i < n; i++)
        {
            if (i == n)
            {
                current.next = current.next.next;
                return head;
            }

            current = current.next;
        }

        return head;
    }

    // damn. I'm an idiot. It's not remove the nth node, from the end of the list. It's remove the nth node from the end of the list (I.E. working backwards). 
    // that's why this is a fast and slow pointer problem
    // the fast pointer goes to the end of the list, while the slow pointer follows behind it by n places
    // which means that when the fast pointer reaches the end of the list, the slow pointer will have the node before the nth node

    public ListNode? RemoveNthFromEnd(ListNode head, int n)
    {
        if (head == null || head.next == null)
        {
            return null;
        }

        ListNode? dummy = new ListNode(0, head);
        ListNode? slow = dummy;
        ListNode? fast = head;

        while (n > 0 && fast != null)
        {
            fast = fast.next;
            n--;
        }

        while (fast != null)
        {
            slow = slow.next;
            fast = fast.next;
        }

        slow.next = slow.next.next;

        return dummy.next;
    }
}

