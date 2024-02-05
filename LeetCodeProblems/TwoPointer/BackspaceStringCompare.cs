using System.Text;

namespace LeetCodeProblems.TwoPointer;
public class BackspaceStringCompare
{
    // this was a difficult one that I need to revisit
    // I didn't read the question properly and ended up running down some dead ends

  public bool BackspaceCompare(string S, string T) {
        char[] sChars = S.ToCharArray();
        char[] tChars = T.ToCharArray();
        
        int sProcessedLength = ProcessString(sChars);
        int tProcessedLength = ProcessString(tChars);

        if (sProcessedLength != tProcessedLength) 
            return false;

        for (int i = 0; i < sProcessedLength; i++) {
            if (sChars[i] != tChars[i]) 
                return false;
        }

        return true;
    }

    private int ProcessString(char[] chars) {
        int pointer = 0;

        foreach (char c in chars) {

            if (c != '#') {
                chars[pointer++] = c;

            } else if (pointer > 0) {
                pointer--;
            }
        }

        return pointer;
    }
    
    public bool BackspaceCompareB(string s, string t)
    {
        string leftSub, rightSub = string.Empty;

        for (int i = 0; i <= Math.Max(s.Length, t.Length) - 1; i++)
        {
            if (i < s.Length)
            {
                if (s[i] == '#')
                    leftSub = leftSub.Remove(leftSub.Length - 1, 1);
                else
                    leftSub = leftSub + s[i];
            }

            if (i < t.Length)
            {
                if (t[i] == '#')
                    rightSub = rightSub.Remove(rightSub.Length - 1, 1);
                else
                    rightSub = rightSub + t[i];
            }
        }

        return leftSub == rightSub;
    }

    public bool BackspaceCompareC(string s, string t)
    {
        return ReadString(s) == ReadString(t);
    }

    private string ReadString(string s)
    {
        StringBuilder sb = new();
        int len = 0;

        foreach (char c in s)
        {
            if (c == '#')
            {
                if (len > 0)
                {
                    sb.Length--;
                    len--;
                }
            }
            else
            {
                sb.Append(c);
                len++;
            }
        }

        return sb.ToString();
    }
}

