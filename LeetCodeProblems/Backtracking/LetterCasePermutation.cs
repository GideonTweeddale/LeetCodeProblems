using System.Text;

namespace LeetCodeProblems.Backtracking;
public class LetterCasePermutation784
{
    public static IList<string> LetterCasePermutation(string s)
    {
        // this is roughly O(N^2) time and space
        // I wonder what the performance difference would be from using StringBuilder

        IList<string> permuts = [];

        PermuteLetterCases(s.ToCharArray(), permuts, 0);

        return permuts;
    }

    private static void PermuteLetterCases(char[] s, IList<string> permuts, int i)
    {
        // check for the base case
        if (i == s.Length) 
        {
            permuts.Add(new string(s));
            return;
        }

        PermuteLetterCases(s, permuts, i + 1);

        if (char.IsLetter(s[i]))
        {
            if (char.IsLower(s[i]))
            {
                s[i] = char.ToUpper(s[i]);
            } else
            {
                s[i] = char.ToLower(s[i]);
            }

            PermuteLetterCases(s, permuts, i + 1);
        }
    }
}
