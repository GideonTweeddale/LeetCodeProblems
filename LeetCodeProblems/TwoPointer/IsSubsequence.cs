namespace LeetCodeProblems.TwoPointer;
public class IsSubsequence392
{
    public static bool IsSubsequence(string s, string t)
    {
        // use two pointers to iterate over the two strings finding the next char from the substring 
        // if we reach the end of the t before we find all the chars in s return false
        // this solution is O(N) time and O(1) space where N = the length of t

        if (t.Length == 0 && s.Length != 0)
        {
            return false;
        }

        if (s.Length == 0)
        {
            return true;
        }

        for (int ti = 0, si = 0; ti < t.Length; ti++)
        {
            if (t[ti] == s[si])
            {
                si++;

                if (si == s.Length)
                {
                    return true;
                }
            }
        }

        return false;
    }
}

