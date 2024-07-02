namespace LeetCodeProblems.ArraysAndStrings;
public class TextJustification
{
    // intuition
    // I think this problem can be broken down into two sub problems
    // first we iterate through the words finding the words the can fit on the line and keeping track of the total length of those words
    // and then we iterate over that line, adding the number of spaces needed to complete the line/the number of words in the line
    // to all words except the last one
    // appending the line to a string variable as we go
    // finally putting the string into our output array
    // we continue this process until we reach the last line, where we just append the spaces to the end of the line

    // this solution will be O(2n) or O(n) time because we will visit each word twice
    // and O(n) space in the worst case where our output array is madeup of words that only fit one per line

    public IList<string> FullJustify(string[] words, int maxWidth)
    {
        List<string> paragraph = new();
        List<string> line = new();
        int lineLength = 0;

        foreach (string word in words)
        {
            if (word.Length + line.Count + lineLength > maxWidth)
            {
                for (int i = 0; i < maxWidth - lineLength; i++)
                {
                    if (line.Count - 1 > 0)
                    {
                        line[i % (line.Count - 1)] += " ";
                    }
                    else
                    {
                        line[i % 1] += " ";
                    }
                }

                paragraph.Add(string.Join("", line));
                line.Clear();
                lineLength = 0;
            }
            line.Add(word);
            lineLength += word.Length;
        }

        string lastLine = string.Join(" ", line);
        while (lastLine.Length < maxWidth)
        {
            lastLine += " ";
        }

        paragraph.Add(lastLine);

        return paragraph;
    }
}