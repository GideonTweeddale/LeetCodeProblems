namespace LeetCodeProblems.LinkedList;
public class LinkedListCycleII
{
    // intuition
    // we need to track the nodes we've visited and when we find a node we've visited before we know we've found the start of the cycle

    // aparently there is math that proves that if we use the tortoise and the hare approach
    // we can find the start of the cycle by resetting the slow pointer to the head once we've found a cycle
    // and then moving both pointers at the same speed until they meet again - which will be the start of the cycle\
    // the advantage of this approach is that we use only O(1) extra space

    public ListNode? DetectCycle(ListNode head)
    {
        // with hashset - each time we visit a node we add it to the hashset
        // if a node is every already in the hashset we've visited it already
        // this should be O(n) time and space
        HashSet<ListNode> visitedNodes = new();
        ListNode currentNode = head;

        while (currentNode != null)
        {
            if (visitedNodes.Contains(currentNode))
            {
                return currentNode;
            }

            visitedNodes.Add(currentNode);
            currentNode = currentNode.next;
        }

        return null;
    }

    public ListNode? DetectCycleB(ListNode head)
    {
        // with fast and slow pointer - I wouldn't have thought of this on my own
        // this approach uses less memory O(1) space (it is also O(n) time)
        ListNode slowPointer = head, fastPointer = head;

        while (fastPointer != null && fastPointer.next != null)
        {
            slowPointer = slowPointer.next;
            fastPointer = fastPointer.next.next;

            if (slowPointer == fastPointer) break;
        }
        
        // this means we didn't find a loop
        if (fastPointer == null || fastPointer.next == null) return null;

        slowPointer = head;

        while (slowPointer.next != null)
        {
            if (slowPointer == fastPointer) return slowPointer;

            slowPointer = slowPointer.next;
            fastPointer = fastPointer.next;
        }

        return null;
    }
}