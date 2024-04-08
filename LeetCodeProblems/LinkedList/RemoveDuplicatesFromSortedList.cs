namespace LeetCodeProblems.LinkedList;
public class RemoveDuplicatesFromSortedList
{
    public ListNode? ReverseList(ListNode head)
    {
        // traverse the list remove the next element if it matches the current element
        // this should be O(n) time and O(1) space complexity

        ListNode? current = head;

        while (current?.next != null)
        {
            if (current.val == current.next.val)
            {
                current.next = current.next.next;
            }
            else
            {
                current = current.next;
            }
        }

        return head;
    }
}


