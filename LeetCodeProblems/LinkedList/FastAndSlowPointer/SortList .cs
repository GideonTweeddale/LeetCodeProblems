namespace LeetCodeProblems.FastAndSlowPointer;

using LeetCodeProblems.Nodes;

public class SortList148
{
    // intuition
    // we can solve this with merge sort
    // which would be O(n * logn) time complexity
            
    public ListNode SortList(ListNode head)
    {
        if (head == null || head.next == null)
        {
            return head;
        }

        ListNode left = head;
        ListNode mid = FindMiddle(head);
        ListNode right = mid.next;
        mid.next = null;

        left = SortList(left);
        right = SortList(right);

        return Merge(left, right);

        ListNode FindMiddle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head.next;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            return slow;
        }

        ListNode Merge(ListNode left, ListNode right)
        {
            ListNode dummy = new ListNode(0);
            ListNode tail = dummy;

            while (left != null && right != null)
            {
                if (left.val < right.val)
                {
                    tail.next = left;
                    left = left.next;
                }
                else
                {
                    tail.next = right;
                    right = right.next;
                }

                tail = tail.next;
            }

            if (left != null)
            {
                tail.next = left;
            }

            if (right != null)
            {
                tail.next = right;
            }

            return dummy.next;
        }
    }
}

