namespace LeetCodeProblems.SlidingWindow;

public class MinimumWindowSubstring
{    
    // intuition
    // I think that this is asking for the shortest possible substring of s that includes all the characters in t
    // I think we can solve this with a sliding window approach
    // starting with the first character in s as both of our pointers we iterate over the list
    // when we don't have a valid window we expand the window by moving the right pointer
    // when we do have a valid window we shrink the window by moving the left pointer
    
    // when we find a valid window
    // we check the subsring against the minimum substring we already have, if it is shorter, we update the minimum 

    // the trickiest part of this will be tracking which chars from t are in the current substring 
    // to do this, I will us a pair of maps both using the chars from t as the keys
    // in the first, we will count up all occurences of each char in t
    // and in the second, we will track how many occurences of each char we have found in our substring 
    // when we add a char to our substring, we increment the value in our second map
    // when we remove a char from our window we decrement the value in our second map

    // we could check the sum of all the chars in our map to know if our substring includes all the chars
    // but it will be simpler to also have an int variable that tracks how many valid characters are in our window

    // this solution will take O(m) time where m is the length of s
    // and O(n) space where n is the length of t - this would actually be O(2n) where n is the number of unique chars in t

    public static string MinWindow(string s, string t) {
        if (s.Length <= 0 || t.Length <= 0 || t.Length > s.Length) 
        {
            return string.Empty;
        }

        Dictionary<char, int> map = new();

        foreach (char c in t)
        {
            if (!map.ContainsKey(c))
            {
                map.Add(c, 0);
            }

            map[c]++;
        }

        int left = 0, right = 0;
        int minStart = 0;
        int minLength = int.MaxValue;
        int requiredChars = t.Length;

        while (right < s.Length)
        {            
            if (map.ContainsKey(s[right]) && map[s[right]]-- > 0) {
                requiredChars--;
            }

            right++;

            while (requiredChars == 0) {
                if (right - left < minLength) {
                    minLength = right - left;
                    minStart = left;
                }

                if (map.ContainsKey(s[left]) && map[s[left]]++ == 0) {
                    requiredChars++;
                }

                left++;
            }
        }

        if (minLength != int.MaxValue)
        {
            return s.Substring(minStart, minLength);
        }

        return string.Empty;
    }    

    public static string MinWindowA(string s, string t) {
        if (s.Length <= 0 && t.Length <= 0)
        {
            return string.Empty;
        }

        if (t.Length > s.Length)
        {
            return string.Empty;
        }

        Dictionary<char, int> charCounts = new();
        Dictionary<char, int> currentCharCounts = new();

        foreach (char c in t)
        {
            if (!charCounts.ContainsKey(c))
            {
                charCounts.Add(c, 0);
                currentCharCounts.Add(c, 0);
            }

            charCounts[c]++;
        }

        int left = 0;
        int right = 0;
        int minLeft = 0;
        int minRight = s.Length + 1;
        int foundChars = 0;

        while (right < s.Length || foundChars == t.Length)
        {
            // valid substring
            if (foundChars == t.Length)
            {
                if (right-left < minRight-minLeft)
                {
                    minRight = right;
                    minLeft = left;
                }

                // shift the left pointer
                if (charCounts.ContainsKey(s[left]))
                {
                    if (currentCharCounts[s[left]] <= charCounts[s[left]])
                    {
                        foundChars--;
                    }

                    currentCharCounts[s[left]]--;
                }

                left++;
            } 
            else // invalid substring - expand the window right
            {                
                if (charCounts.ContainsKey(s[right]))
                {
                    if (currentCharCounts[s[right]] < charCounts[s[right]])
                    {
                        foundChars++;
                    }
                    
                    currentCharCounts[s[right]]++;
                }

                right++;
            }         
        }

        if (minRight-minLeft < s.Length+1)
        {
            return s.Substring(minLeft, minRight-minLeft);
        }

        return string.Empty;
    }
}