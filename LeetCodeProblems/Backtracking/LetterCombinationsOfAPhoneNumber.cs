using System.Text;

namespace LeetCodeProblems.Backtracking;
public class LetterCombinationsOfAPhoneNumber
{
    Dictionary<char, string> keypad = new()
        {
            {'2', "abc"},
            {'3', "def"},
            {'4', "ghi"},
            {'5', "jkl"},
            {'6', "mno"},
            {'7', "pqrs"},
            {'8', "tuv"},
            {'9', "wxyz"}
    };

    public IList<string> LetterCombinations(string digits)
    {
        if (digits.Length == 0)
            return new List<string>();

        IList<string> result = new List<string>();
        Backtrack(0, new StringBuilder());
        return result;

        void Backtrack(int index, StringBuilder sb)
        {
            if (index == digits.Length)
            {
                result.Add(sb.ToString());
                return;
            }

            char digit = digits[index];
            string letters = keypad[digit];

            for (int i = 0; i < letters.Length; i++)
            {
                sb.Append(letters[i]);
                Backtrack(index + 1, sb);
                sb.Remove(sb.Length - 1, 1);
            }
        }
    }
}