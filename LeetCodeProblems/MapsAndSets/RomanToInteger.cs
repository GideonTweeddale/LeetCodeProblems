namespace LeetCodeProblems.HashSet;
public class RomanToInteger
{
    Dictionary<char, int> romanNumerals = new()
    {
        {'I', 1},
        {'V', 5},
        {'X', 10},
        {'L', 50},
        {'C', 100},
        {'D', 500},
        {'M', 1000},
    };

    Dictionary<string, int> romanNumeralsB = new()
    {
        {"I", 1},
        {"V", 5},
        {"X", 10},
        {"L", 50},
        {"C", 100},
        {"D", 500},
        {"M", 1000},
        {"IV", 4},
        {"IX", 9},
        {"XL", 40},
        {"XC", 90},
        {"CD", 400},
        {"CM", 900},
    };

    // This solution is wrong because I misunderstood how roman numerals work
    public int RomanToInt(string s)
    {
        // Everything to the left of the largest numeral is subtracted from the final sum and everything to the right is added

        char[] chars = s.ToCharArray();
        int left = 0;
        int right = 0;
        int largest = romanNumerals[chars[0]];
        int largestIndex = 0;

        for (int i = 0; i < chars.Length; i++)
        {
            if (romanNumerals[chars[i]] > largest)
            {
                largestIndex = i;
                largest = romanNumerals[chars[i]];

            }

            if (i < largestIndex)
            {
                left += romanNumerals[chars[i]];
            }
            else if (i > largestIndex)
            {
                right += romanNumerals[chars[i]];
            }
        }

        return right + largest - left;
    }

    public int RomanToIntB(string s)
    {
        // test for each specialy pairing and add them to the total together then skip an index 
        char[] chars = s.ToCharArray();
        int sum = 0;

        for (int i = 0; i < chars.Length; i++)
        {
            char a = chars[i];

            if (i + 1 < chars.Length)
            {
                char b = chars[i + 1];
                if (a == 'I' && (b == 'V' || b == 'X'))
                {
                    sum += romanNumeralsB[string.Concat(a, b)];
                    i++;
                }
                else if (a == 'X' && (b == 'L' || b == 'C'))
                {
                    sum += romanNumeralsB[string.Concat(a, b)];
                    i++;
                }
                else if (a == 'C' && (b == 'D' || b == 'M'))
                {
                    sum += romanNumeralsB[string.Concat(a, b)];
                    i++;
                }
                else
                {
                    sum += romanNumeralsB[a.ToString()];
                }
            }
            else
            {
                sum += romanNumeralsB[a.ToString()];
            }
        }

        return sum;
    }


    public int RomanToIntC(string s)
    {
        // test for each specialy pairing and add them to the total together then skip an index 
        char[] chars = s.ToCharArray();
        int sum = 0;

        for (int i = 0; i < chars.Length; i++)
        {
            char a = chars[i];

            if (i + 1 < chars.Length)
            {
                string pair = string.Concat(a, chars[i + 1]);

                if (romanNumeralsB.ContainsKey(pair))
                {
                    sum += romanNumeralsB[pair];
                    i++;
                }
                else
                {
                    sum += romanNumeralsB[a.ToString()];
                }
            }
            else
            {
                sum += romanNumeralsB[a.ToString()];
            }
        }

        return sum;
    }
}