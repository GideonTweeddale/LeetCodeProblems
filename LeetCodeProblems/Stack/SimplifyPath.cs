namespace LeetCodeProblems.Stack;
public class SimplifyPath71
{
    // intuition
    // we can solve this using a stack
    // we split the path on '/'
    // we iterate through the split
    // if our string is not a '..' we push it to the stack
    // if our string is a '..' we pop and discard the last item in the stack
    // if our string is empty because there was a '//' we discard it

    // when we reach the end of the split if our stack is empty we return root '/'
    // otherwise we pop from our stack one by one and append to the beginning of our path like so '/' + poppedString + path
    // when our stack is empty, we return the path

    public string SimplifyPath(string path)
    {
        Stack<string> stack = new();

        string[] strs = path.Split('/');

        foreach (string str in strs)
        {
            if (string.IsNullOrWhiteSpace(str) || str == ".")
            {
                continue;
            }
            else if (str == "..")
            {
                stack.TryPop(out _);
            }
            else
            {
                stack.Push(str);
            }
        }

        if (stack.Count == 0)
        {
            return "/";
        }

        path = string.Empty;

        while (stack.Count > 0)
        {
            path = "/" + stack.Pop() + path;
        }

        return path;
    }
}
