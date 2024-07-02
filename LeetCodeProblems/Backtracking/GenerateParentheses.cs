using System.Text;

namespace LeetCodeProblems.Backtracking;
public class GenerateParentheses22
{
    public static IList<string> GenerateParenthesis(int n)
    {
        IList<string> output = new List<string>();

        void Backtrack(string str, int opened, int closed)
        {
            // we have reached the base case when we have added both the correct number of opening and closing parentheses
            if (opened == n && closed == n)
            {
                output.Add(str);
                return;
            }

            if (opened < n)
            {
                // add the opening parenthesis and increment the index

                Backtrack(str + "(", opened + 1, closed);
            }

            if (closed < opened)
            {
                // add the closing parenthesis and call backtrack
                Backtrack(str + ")", opened, closed + 1);
            }
        }

        Backtrack("(", 1, 0);

        return output;
    }
}
