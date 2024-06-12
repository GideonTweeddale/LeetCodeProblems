namespace LeetCodeProblems.SlidingWindow;
public class ValidParentheses
{
    // intuition
    // we can use a stack here
    // we iterate through the indexes in s
    // if we encounter an openening (, {, or [ we push it to the stack
    // if we encounter a closing ), }, or ] we pop from the stack
    // if the the element we don't have an element to pop or it is not the matching bracket
    // our string is not valid and we return false
    // if we reach the end of our string without encountering an invalid bracket and our stack is empty
    // our string is valid and we can return true

    // this will run in O(n) time where n is the length of s 
    // and this will use O(n) space in the worst case where every index in s is some kind of opening bracket, etc.

    private static Dictionary<char, char> pairs = new() { { '(', ')' }, { '[', ']' }, { '{', '}' } };

    public bool IsValid(string s)
    {
        Stack<char> parentheses = new();

        foreach (char c in s) 
        { 
            if (c == '(' || c == '[' || c == '{') 
                parentheses.Push(c);

            else if (c ==  ')' || c == ']' || c == '}')
            {
                if (parentheses.Count == 0 || pairs[parentheses.Pop()] != c) 
                    return false;
            }
        }

        return parentheses.Count == 0;
    }
}
