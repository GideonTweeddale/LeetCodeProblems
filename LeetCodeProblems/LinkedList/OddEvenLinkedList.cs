namespace LeetCodeProblems.LinkedList;
public class OddEvenLinkedList
{
    // intuition
    // iterate through the list with two pointers: one for odd and one for even
    // each time we find an od or an even index attach it to the correct pointer
    // this leaves us with two smaller linked lists
    // attach the even list to the end of the odd list and return the result
    // remember to clear the next pointer of the last node in the even list

    // this should have O(n) time complexity and O(1) complexity
    // because we iterate through the list only once
    // and we create only a constant number of new objects and pointers

    // questions
    // does it matter whether odd or even indices are at the end or the beginning of the new list so long as they are grouped?

    public ListNode OddEvenListA(ListNode head)
    {
        if (head == null || head.next == null)
        {
            return head;
        }

        ListNode dummy = new ListNode(0, head);

        // create odd and even pointers
        ListNode odd = head;
        ListNode even = head.next;
        ListNode evenHead = even; // save the head of the even list

        // move the head pointer to the next odd node
        head = head.next.next;

        bool oddTurn = true;

        // iterate through the list and attach nodes to the odd or even list
        while (head != null)
        {
            if (oddTurn)
            {
                odd.next = head;
                odd = odd.next;
            }
            else
            {
                even.next = head;
                even = even.next;
            }

            oddTurn = !oddTurn;
            head = head.next;
        }

        // clear the last pointer of the even list
        even.next = null;

        // reattach the even list to the end of the odd list
        odd.next = evenHead;

        return dummy.next; // the first node always stays in the same place
    }

    // this is a more concise version of the same solution
    public ListNode OddEvenList(ListNode head)
    {
        if (head == null || head.next == null)
        {
            return head;
        }

        ListNode odd = head;
        ListNode even = head.next;
        ListNode ehead = even;

        while (even != null && even.next != null)
        {
            odd.next = odd.next.next;
            even.next = even.next.next;
            odd = odd.next;
            even = even.next;
        }

        odd.next = ehead;

        return head;
    }
}


