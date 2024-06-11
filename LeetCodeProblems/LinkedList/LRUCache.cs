
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


    private Node oldest;
    private Node newest;
    private Dictionary<int, Node> map = new();
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
        if (!map.ContainsKey(key)) return -1;

        Node node = map[key];

        RemoveFromLinkedList(node);
        AddToEndOfLinkedList(node);

        return node.val;
    }

    public void Put(int key, int value)
    {
        if (map.ContainsKey(key))
            RemoveFromLinkedList(map[key]);

        Node node = new Node(key, value);

        map[key] = node;
        AddToEndOfLinkedList(node);

        if (map.Count > _capacity)
        {
            map.Remove(oldest.next.key);
            RemoveFromLinkedList(oldest.next);
        }
    }

    // helper functions
    private void RemoveFromLinkedList(Node node)
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


