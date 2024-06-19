namespace LeetCodeProblems.DivideAndConquer;
public class MergeKSortedLists
{
    // intution
    // we can break this down into a merge two linked lists problem
    // we divide our list of lists into pairs
    // merge the pairs and collect all the new pairs as a new lsit of linked lists
    // then we repeat until we have only one linked list left
    
    // this solution will be O(n log k) where n is the number of nodes in each list and k is the number of lists
    // because we will iterate through the nodes of each list each time we merge two lists
    // and we divide the number of lists in half with each iteration 

    // in practice, it is possible to speed this up significantly by using arrays instead of lists
    // to do this we need to calculate the length of the array up front
    // which will be half of the length of the original array, rounding up
    // so a array of length 5 needs an merged array of length 3
    // like below:
    
    // int length = lists.Length;
    // int halfLength = length % 2 == 1 ? length / 2 + 1 : length / 2;
    // ListNode[] temp = new ListNode[halfLength];

    // for (int i = 0; i < length / 2; i++) {
    //     temp[i] = MergeLinkedLists(lists[2 * i], lists[2 * i + 1]);
    // }
    
    // if (length % 2 == 1) {
    //     temp[halfLength - 1] = lists[length - 1];
    // }
    
    // lists = temp;

    public ListNode MergeKLists(ListNode[] lists) {
        if (lists == null || lists.Length == 0) return null;

        while (lists.Length > 1)
        {
            List<ListNode> mergedLists = [];

            for (int i = 0; i < lists.Length; i += 2)
            {
                ListNode l1 = lists[i];
                ListNode? l2 = i + 1 < lists.Length ? lists[i + 1] : null;

                mergedLists.Add(MergeLinkedLists(l1, l2));
            }

            lists = mergedLists.ToArray();
            
        }

        return lists[0];
    }

    private ListNode MergeLinkedLists(ListNode l1, ListNode? l2) 
    {
        ListNode dummy = new(0);
        ListNode tail = dummy;

        while (l1 != null && l2 != null)
        {
            if (l1.val < l2.val)
            {
                tail.next = l1;
                l1 = l1.next;
            }
            else
            {
                tail.next = l2;
                l2 = l2.next;
            }

            tail = tail.next;
        }

        if (l1 != null) tail.next = l1;
        if (l2 != null) tail.next = l2;

        return dummy.next;
    }
}


// Definition for singly-linked list.
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
