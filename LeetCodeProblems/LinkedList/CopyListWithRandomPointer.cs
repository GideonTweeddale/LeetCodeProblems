namespace LeetCodeProblems.LinkedList;
public class CopyListWithRandomPointer
{
    // intuition
    // we can solve this by creating a list to hold the linked list nodes
    // then we iterate through the linked list and for each node
    //       create a new node for the next node and assign it to the index in the list
    //       create a new node for the random node and assign it to the index in the list
    //       the twist is that we may have already created a given node, so we check the index in the list first
    //       and update the existing node when it exists

    // this way, we can solve the problem in a single pass
    // making this O(n) time and O(2n) or O(n) space
    // because we iterate through the nodes once
    // and we create a list of the nodes
    // and we create the new nodes structure

    // damn it. This doesn't work because the question gives us a refence to the actual node for the random node not its index
    // why is the question written literally specifying that we have an index reference!?

    // we are going to need a completely different solution
    // we will need to make two passes
    // in the first pass we will create all the deep copies of the nodes, but without any links
    // and add them to a hashmap with the original node as the key
    // then on the second pass through the nodes, we will assign the links for each of the value nodes in the hashmap
    // to the value nodes from the linked nodes 

    // this will be O(2n) or just O(n) time and space
    // because we will iterate over the nodes twice
    // and we will create both a hashmap of the length of the linked list and a new linked list

    // handle empty linked list, edgecase

    public static Node CopyRandomList(Node head)
    {
        if (head == null)
        {
            return null;
        }

        Dictionary<Node, Node> nodeToCopy = [];

        Node current = head;

        while (current != null) 
        {
            nodeToCopy.Add(current, new(current.val));
            current = current.next;
        }

        current = head;

        while (current != null)
        {
            Node copy = nodeToCopy[current];

            // the random and next pointers may point to null
            if (current.next != null)
            {
                copy.next = nodeToCopy[current.next];
            }

            if (current.random != null)
            {
                copy.random = nodeToCopy[current.random];
            }

            current = current.next;
        }

        return nodeToCopy[head];
    }

    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }
}


