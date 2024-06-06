namespace LeetCodeProblems.ArraysAndStrings;
public class ReverseWordsInAString
{
    // intuition
    // we iterate from the end of the string until we reach a char index and we store the index
    // then we continue iterating until we reach a space index
    // then we take the substring from that index to the first index we saved
    // and add that to the new string
    // if the new string is already greater than length 0, we also add a space
    // we continue this process until we reach the beginning of the string

    // this should be O(n) time because we will visit each char in the string once
    // and O(n) space including the new string 

    public string ReverseWords(string s)
    {
        int end = int.MaxValue;
        string output = string.Empty;
        
        for (int i = s.Length - 1; i >= 0; i--)
        {
            // if we are at the first index or the char is not a space and the first index has not been set: set the end index
            if (s[i] != ' ' && end == int.MaxValue) end = i + 1;

            // if the next char is a space or the first index and the end index has been set: append the new word and reset end index 
            if ((i == 0 || s[i - 1] == ' ') && end != int.MaxValue)
            {
                // handle adding a space
                if (output.Length > 0) output += ' ';

                output += s[i..end];
                end = int.MaxValue;
            }
        }

        return output;
    }

    // another way to solve this is to split the string into an array on the spaces
    // the iterate through it and append the words

    // this will have a O(n) time complexity because string Split is an O(n) operation and we then loop through the strings which will be worst case O(n) length where all characters are spaces
    // and an O(n) space complexity because we create the strings array

    // however, in practice is uses both far less memory and far less time than the first solution

    public string ReverseWordsSplit(string s)
    {
        string output = string.Empty;

        string[] strings = s.Split(' ');

        for (int i = 0; i < strings.Length; i++)
        {
            string str = strings[i];

            if (output.Length > 0 && str.Length > 0)
                str += ' ';

            output = str + output;
        }

        return output;
    }
}
