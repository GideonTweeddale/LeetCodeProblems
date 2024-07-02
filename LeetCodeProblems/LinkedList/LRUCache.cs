
namespace LeetCodeProblems.LinkedList;

// doubly linked list node
public class Node
{
    public int key;
    public int val;
    public Node next;
    public Node previous;

    public Node(int key, int val)
    {
        this.key = key;
        this.val = val;
    }
}

public class LRUCache
{
    // intuition
    // we can use a doubly linked list to hold our queue of most recently seen items
    // and a map to hold references to the nodes in our double linked list accessible by key
    // we maintain a pointer to the first and the last item in the doubly linked list

    // we add items by creating a node holding the key and value
    // then adding it to our double linked list by inserting them before the last item pointer
    // and then adding the node to our map with the key 

    // we remove items by assigning the pointers of the previous and next nodes in the double linked list to each other
    // and then removing the key-node pair from the map

    // when put is called, we remove our item if it exists, and then re-add it, therby insuring that it is the most recent

    // when get is called, we do the same, except that we return -1 if it is not in our map

    // the map holding the nodes means that we can find any node in O(1) time
    // and the nodes holding references to the next and previous node means that we can do our adds and deletes in O(1) time
    // therefore our put and get are both O(1)
    // the overall space complexity of our entire LRUCache is O(2n) or just O(n) in the worst case where n is the capacity
    // and n or more nodes were added to the cache

    private Node oldest;
    private Node newest;
    private Dictionary<int, Node> map = [];
    private int _capacity;

    // our LRUCache implementation uses O(2n) space
    // because we store our keys in both the map and the linked list
    public LRUCache(int capacity)
    {
        _capacity = capacity;
        oldest = new(0,0);
        newest = new(0,0);
        oldest.next = newest;
        newest.previous = oldest;
    }

    public int Get(int key)
    {
        if (!map.ContainsKey(key))
        {
            return -1;
        }

        Node node = map[key];

        RemoveFromLinkedList(node);
        AddToEndOfLinkedList(node);

        return node.val;
    }

    public void Put(int key, int value)
    {
        if (map.ContainsKey(key))
        {
            RemoveFromLinkedList(map[key]);
        }

        Node node = new(key, value);

        map[key] = node;
        AddToEndOfLinkedList(node);

        if (map.Count > _capacity)
        {
            map.Remove(oldest.next.key);
            RemoveFromLinkedList(oldest.next);
        }
    }

    // helper functions
    private static void RemoveFromLinkedList(Node node)
    {
        node.previous.next = node.next;
        node.next.previous = node.previous;
    }

    private void AddToEndOfLinkedList(Node node)
    {
        newest.previous.next = node;
        node.previous = newest.previous;

        node.next = newest;
        newest.previous = node;
    }
}


