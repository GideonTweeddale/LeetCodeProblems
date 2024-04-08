﻿namespace LeetCodeProblems.LinkedList;
public class LinkedListCycleII
{
    // intuition
    // we need to track the nodes we've visited and when we find a node we've visited before we know we've found the start of the cycle

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

    public bool HasCycleB(ListNode head)
    {
        // with fast and slow pointer - I wouldn't have thought of this on my own
        // this approach uses less memory O(1) space (it is also O(n) time)
        // if there is a loop the fast pointer will eventually catch up to the slow pointer
        ListNode slowPointer = head, fastPointer = head;

        while (fastPointer != null && fastPointer.next != null)
        {
            slowPointer = slowPointer.next;
            fastPointer = fastPointer.next.next;

            if (slowPointer == fastPointer)
            {
                return true;
            }
        }
        return false;
    }
}