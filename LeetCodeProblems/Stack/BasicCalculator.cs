using System.Text;

namespace LeetCodeProblems.Stack;
public class BasicCalculator
{
    // this solution will be O(n) time and space
    // because we will iterate through the input once
    // and we will store worst case O(n) simplified items in the stack

    public static int Calculate(string s)
    {
        Stack<int> stack = new();
        int result = 0;
        int i = 0;
        int num = 0;

        // if we multiply a number by -1 before adding it it is the same as subtraction
        // and if we multiply by 1 it is the same as addition
        int sign = 1; 

        while (i < s.Length)
        {
            switch (s[i])
            {
                case '+':
                    sign = 1;
                    break;

                case '-':
                    sign = -1;
                    break;

                case '(':
                    stack.Push(result);
                    stack.Push(sign);
                    result = 0;
                    sign = 1;
                    break;

                case ')':
                    int lastSign = stack.Pop();
                    result *= lastSign;
                    int lastNum = stack.Pop();
                    result += lastNum;

                    break;

                case ' ': // we want to ignore all spaces
                    break;

                default:
                    if (char.IsDigit(s[i]))
                    {
                        StringBuilder stringBuilder = new();
                        stringBuilder.Append(s[i]);

                        while (i + 1 < s.Length && char.IsDigit(s[i + 1]))
                        {
                            stringBuilder.Append(s[++i]);
                        }

                        num = int.Parse(stringBuilder.ToString());
                        num *= sign;
                        result += num;
                        sign = 1;
                    }
                    break;
            }
            i++;
        }

        return result;
    }
}






    //public int Calculate(string s)
    //{
    //    Stack<string> stack = new();

    //    bool open = true; // if open and ) do operations, else if closed and ) pop and do operations
    //    int j = 0;
    //    int sum = 0;

    //    for (int i = 0; i < s.Length; i++)
    //    {
    //        // open and ( = push to stack
    //        // open and ) = do operation
    //        // closed and ( = set open
    //        // closed and ) = pop from stack and do operation

    //        if (s[i] == '(')
    //        {
    //            if (open)
    //            {
    //                stack.Push(s[j..i]);
    //                j = i + 1;
    //            }
    //            else
    //            {
    //                open = true;
    //            }
    //        }
    //        else if (s[i] == ')' || i == s.Length - 1)
    //        {
    //            if (open)
    //            {
    //                sum = DoOperations(s[j..i]);
    //            }
    //            else
    //            {
    //                sum = DoOperations($"{stack.Pop()}{sum}{s[j..i]}");
    //            }
    //        }
    //    }

    //    return sum;
    //}

    //private int DoOperations(string s)
    //{
    //    int sum = 0;
    //    int operatorIndex = 0;

    //    for (int i = 0; i < s.Length; i++)
    //    {
    //        // if operator or end
    //        if (s[i] == '+' || s[i] == '-' || i == s.Length - 1)
    //        {
    //            if (operatorIndex != 0)
    //            {
    //                string subStr = s[(operatorIndex + 1)..i];
    //                int number = 0;
    //                if (!string.IsNullOrWhiteSpace(subStr)) number = int.Parse(s[(operatorIndex + 1)..i]);

    //                if (operatorIndex == '+') sum += number;
    //                else sum -= number;
    //            }

    //            operatorIndex = s[i];
    //        }
    //    }

    //    return sum;
    //}