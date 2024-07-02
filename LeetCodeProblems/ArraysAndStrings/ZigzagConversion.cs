using System.Text;

namespace LeetCodeProblems.ArraysAndStrings;
public class ZigzagConversion
{
    // intuition
    // in this instance, a snake pattern will output the same result as true zigzag
    // to do this, we need to down and up from index 0-numRows and back until we reach the last index in the string
    // while adding the chars to the string at the index in the array of strings 
    // then we need to iterate over the strings in the array of strings in order and append them together
    // then return that

    // this will take O(n) time and worst case O(n) space when the number of rows equals the length of the string

    public static string Convert(string s, int numRows)
    {
        if (numRows >= s.Length || numRows == 1)
        {
            return s;
        }

        List<StringBuilder> rows = [];

        for (int i = 0; i < numRows; i++)
        {
            rows.Add(new StringBuilder());
        }

        int rowIndex = 0;
        bool zig = true;

        // create the strings
        for (int i = 0; i < s.Length; i++)
        {
            rows[rowIndex].Append(s[i]);

            if (zig)
            {
                rowIndex++;
                zig = rowIndex < numRows - 1;
            }
            else // zag
            {
                rowIndex--;
                zig = rowIndex < 1;
            }

        }

        // combine the string and return the combination
        StringBuilder output = new();

        foreach (StringBuilder str in rows)
        {
            output.Append(str);
        }

        return output.ToString();
    }
}
