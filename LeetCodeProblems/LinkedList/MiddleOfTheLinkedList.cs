using System;
using System.Collections.Generic;

namespace LeetCodeProblems.LinkedList;
public class MiddleOfTheLinkedList
{
    public ListNode MiddleNode(ListNode head)
    {
        // this solution will be O(2n) time complexity in the worst case because we interate over the linked list twice
        // it is O(1) space complexity because we only store the current node and the nodeCount as additional memory
        ListNode currentNode = head;
        int nodeCount = 3;

        while (currentNode.next != null)
        {
            nodeCount++;
            currentNode = currentNode.next;
        }

        currentNode = head;

        for (int i = 1; i < nodeCount / 2; i++)
        {
            currentNode = currentNode.next;
        }

        return currentNode;
    }

    public ListNode MiddleNodeB(ListNode head)
    {
        // looking at the solutions, this can also be solved with a fast and a slow point (duh)
        // this approach uses less memory O(1) space and O(n) time
        // if there is a loop the fast pointer will eventually catch up to the slow pointer
        if (head == null)
        {
            return null;
        }

        ListNode slowPointer = head, fastPointer = head.next;

        while (fastPointer != null)
        {
            slowPointer = slowPointer.next;
            fastPointer = fastPointer.next;

            if (fastPointer != null)
            {
                fastPointer = fastPointer.next;
            }
        }

        return slowPointer;
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }
}


