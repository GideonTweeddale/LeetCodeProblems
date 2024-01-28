namespace LeetCodeProblems.HashSet;
public class IntegerToRoman
{
    Dictionary<int, string> romanNumerals = new Dictionary<int, string>()
    {
        {1000, "M"},
        {900, "CM"},
        {500, "D"},
        {400, "CD"},
        {100, "C"},
        {90, "XC"},
        {50, "L"},
        {40, "XL"},
        {10, "X"},
        {9, "IX"},
        {5, "V"},
        {4, "IV"},
        {1, "I"},
    };

    public string IntToRoman(int num)
    {
        // subtract the largest roman numeral possible until we get to zero

        string romanNumeral = string.Empty;

        while (num > 0)
        {
            if (num >= 1000)
            {
                num -= 1000;
                romanNumeral += "M";
            }
            else if (num >= 900)
            {
                num -= 900;
                romanNumeral += "CM";
            }
            else if (num >= 500)
            {
                num -= 500;
                romanNumeral += "D";
            }
            else if (num >= 400)
            {
                num -= 400;
                romanNumeral += "CD";
            }
            else if (num >= 100)
            {
                num -= 100;
                romanNumeral += "C";
            }
            else if (num >= 90)
            {
                num -= 90;
                romanNumeral += "XC";
            }
            else if (num >= 50)
            {
                num -= 50;
                romanNumeral += "L";
            }
            else if (num >= 40)
            {
                num -= 40;
                romanNumeral += "XL";
            }
            else if (num >= 10)
            {
                num -= 10;
                romanNumeral += "X";
            }
            else if (num >= 9)
            {
                num -= 9;
                romanNumeral += "IX";
            }
            else if (num >= 5)
            {
                num -= 5;
                romanNumeral += "V";
            }
            else if (num >= 4)
            {
                num -= 4;
                romanNumeral += "IV";
            }
            else if (num >= 1)
            {
                num -= 1;
                romanNumeral += "I";
            }
        }

        return romanNumeral;
    }

    public string IntToRomanB(int num)
    {
        // subtract the largest roman numeral possible until we get to zero
        // this version is a lot more concise, but maybe slightly harder to understand
        // the performance is big O equivalent

        System.Text.StringBuilder romanNumeral = new();

        foreach (var kv in romanNumerals)
        {
            while (num >= kv.Key)
            {
                num -= kv.Key;
                romanNumeral.Append(kv.Value);
            }
        }

        return romanNumeral.ToString();
    }
}