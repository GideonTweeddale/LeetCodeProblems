namespace LeetCodeProblems.FastAndSlowPointer;
public class AddTwoNumbers2
{
    // intuition
    // becuase the numbers are stored in reverse order, this makes for a really easy solution
    // we can iterate over the two linked lists
    // for each iteration
    // create a new node with the sum of the values
    // add it to the new linked list
    // carry the ten 
    // if one linked list ends before the other - simply use the values from the remaining one (plus any final carried value) until it also runs out

    // we could also iterate over the two lists, adding the values to an integer - while applying the correct multiple of ten -  and then split those values into a new linked list

    public ListNode? AddTwoNumbers(ListNode l1, ListNode l2)
    {
        bool carry = false;
        int value = 0; // we could move this inside the loop for better safety and readability or leave it here for marginally better performance
        ListNode? head = null;
        ListNode? current = null;

        while (l1 != null || l2 != null || carry)
        {
            // reset value
            value = 0;

            // if we are carrying a one
            if (carry)
            {
                value++;
                carry = false;
            }

            if (l1 != null)
            {
                value += l1.val;
                l1 = l1.next;
            }

            if (l2 != null)
            {
                value += l2.val;
                l2 = l2.next;
            }

            if (value >= 10)
            {
                value -= 10;
                carry = true;
            }

            if (head == null)
            {
                head = new ListNode(value);
                current = head;
            }
            else
            {
                current.next = new ListNode(value);
                current = current.next;
            }
        }

        return head;
    }
}