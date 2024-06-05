namespace LeetCodeProblems.ArraysAndStrings;
public class LengthOfLastWord58
{
    // intuition

    // this can easily be solved in O(n) time and O(1) space
    // we track the length the current word
    // we iterate through the string, incrementing the word length every time we loop
    // when we hit a space, if the next character is not also a space, we reset the worth length
    // when we reach the end, we return the word length

    // This is O(n) time where n is the length of the string because we visit each index in the string once
    // This is O(1) or constant time because the only additional memory we use is the variable to store the current word length

    public int LengthOfLastWord(string s)
    {
        int length = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != ' ')
                length++;

            if (s[i] == ' ' && i + 1 < s.Length && s[i + 1] != ' ')
                length = 0;
        }

        return length;
    }

    // this solution works but we could do this way faster, if we start from the end and go only until the first space

    public int LengthOfLastWordReverse(string s)
    {
        int length = 0;
        int n = s.Length - 1;

        for (int i = n; i >= 0; i--)
        {
            if (s[i] == ' ' && i + 1 <= n && s[i + 1] != ' ')
                return length;

            if (s[i] != ' ')
                length++;
        }

        return length;
    }
}
