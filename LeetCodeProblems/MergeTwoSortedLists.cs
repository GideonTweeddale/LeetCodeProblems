using System.Xml.Linq;

namespace LeetCodeProblems;
public class MergeTwoSortedLists
{
    public ListNode? MergeTwoLists(ListNode list1, ListNode list2)
    {
        // Traverse through the lists adding the smaller item to the merged list each time
        // This should be O(n + n) time and O(1) space

        if (list1 == null) return list2;
        if (list2 == null) return list1;    

        // create a dummy head to make things easier to read
        ListNode head = new ListNode(0);
        ListNode current = head;

        while (list1 != null && list2 != null)
        {
            if (list1.val < list2.val)
            {
                current.next = list1;
                list1 = list1.next;
            } 
            else
            {
                current.next = list2;
                list2 = list2.next;
            }

            // mode current forward
            current = current.next;
        }

        // handle the final items
        if (list1 != null)
        {
            current.next = list1;
        } else
        {
            current.next = list2;
        }

        // skip the dummy head
        return head.next;
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


