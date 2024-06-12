namespace LeetCodeProblems.Stack;
public class EvaluateReversePolishNotation
{
    // intuition
    // because of the notes, this will be comparatively easy - many of the edge cases are excluded
    // we can solve this by iterating over the tokens from left to right 
    // if the token is an integer, push it to the stack
    // if it is an operand 
    //      pop two items from the stack 
    //      and perform the operation on the from left to right
    //      then push the resulting value to the stack
    // given the constraints, this should result in a single value in the stack when our tokens are finished
    // return that value

    // this will run in O(n) time and O(1) space where n is the number of tokens
    // because we will iterate though the tokens once and perform a fixed number of operations on them
    // and we will store a maximum of three items in our stack making it constant spaces

    public int EvalRPN(string[] tokens)
    {
        Stack<int> stack = new();

        foreach (string token in tokens)
        {
            // if operand
            if(token == "+")
            {
                int right = stack.Pop();
                int left = stack.Pop();

                stack.Push(left + right);
            }
            else if (token == "-")
            {
                int right = stack.Pop();
                int left = stack.Pop();

                stack.Push(left - right);
            }
            else if (token == "*")
            {
                int right = stack.Pop();
                int left = stack.Pop();

                stack.Push(left * right);
            }
            else if (token == "/")
            {
                int right = stack.Pop();
                int left = stack.Pop();

                stack.Push(left / right);
            }
            else
            {
                stack.Push(int.Parse(token));
            }
        }

        return stack.Pop(); // return what should be the only item in the stack
    }
}