namespace LeetCodeProblems.Stack;
public class MinStack
{
    // intuition
    // we can use a linked list to store the stack - if we needed to be able to popBottom we could use a doubly-linked list
    // I am assuming that getMin returns the minimum element without removing it from the stack - if we need to remove it, then we also need a doubly linked list

    // the minimum will change whenever we push or pop a value, but not when we actually get the min
    // if we push a value, the min becomes whichever is lower of the value we push and the previous min
    // when we pop a value, the min becomes whatever the min was before the value was pushed that we are popping
    // this means that the min will always be the same for an item when it is popped as it was when it was pushed
    // so we can track the min by setting it for each node

    // using linked list will allow us to complete all our operations in O(1) or constant time

    // the question states that we will never need to handle operations on an empty stack
    // I will return null when an int is expected because -1 is a valid value for the sake of completnes
    // in real code, I might throw an error if null wasn't an acceptable response

    Node? top;

    public MinStack()
    {
    }

    public void Push(int val)
    {
        Node node = new(val)
        {
            next = top
        };

        if (top != null && val > top.min)
        {
            node.min = top.min;
        }
        else
        {
            node.min = val;
        }

        top = node;
    }

    public void Pop()
    {
        Node temp = top.next;
        top.next = null; // so that garbage collection can be done
        top = temp;
    }

    // apparently top isn't supposed to pop
    public int Top()
    {
        return top.val;
    }

    public int GetMin()
    {
        return top.min;
    }
}

// linked list node
public class Node(int val)
{
    public int val = val;
    public int min;
    public Node? next;
}


/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */

// Interestingly this slightly simpler version is slightly quicker and slightly less memory efficient
// I do like how intuitive it is
public class MinStackB
{
    private Stack<int> _stack;
    private Stack<int> _minStack;

    public MinStackB()
    {
        _stack = new Stack<int>();
        _minStack = new Stack<int>();
    }

    public void Push(int val)
    {
        _stack.Push(val);

        if (_minStack.Count == 0)
        {
            _minStack.Push(val);
        }
        else
        {
            int minVal = _minStack.Peek();

            if (minVal > val)
            {
                _minStack.Push(val);
            }
            else
            {
                _minStack.Push(minVal);
            }
        }
    }

    public void Pop()
    {
        _stack.Pop();
        _minStack.Pop();
    }

    public int Top()
    {
        return _stack.Peek();
    }

    public int GetMin()
    {
        return _minStack.Peek();
    }
}