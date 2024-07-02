namespace LeetCodeProblems.Backtracking;
public class PalindromePartitioning
{
    public static IList<IList<string>> Partition(string s)
    {
        // like most of the backtracking solutions, this would be O(N^2) time and space roughly
        
        IList<IList<string>> output = new List<IList<string>>();

        void Backtrack(int index, List<string> current)
        {
            // base cases
            // not a valid palindrome
            int oppositeIndex = current.Count - index - 1;
            if (index != 0 && s[index] != s[oppositeIndex])
            {
                return;
            }

            // end of the string
            if (index == s.Length)
            {
                output.Add(new List<string>(current));
                return;
            }

            // increment index, add to the current string, and call backtrack
            current[current.Count - 1] += s[index];
            Backtrack(index + 1, current);

            // backtrack
            current[current.Count - 1] = current[current.Count - 1].Substring(0, current[current.Count - 1].Length - 1);

            // increment index, add new string to the list, and call 
            current.Add(s[index].ToString());
            Backtrack(index + 1, current);
        }

        Backtrack(0, new List<string>());

        return output;
    }

    public static IList<IList<string>> PartitionB(string s)
    {
        List<IList<string>> output = new();

        void FindPartition(string str, List<string> partition)
        {
            if (string.IsNullOrEmpty(str))
            {
                output.Add(new List<string>(partition));
                return;
            }

            for (int i = 0; i < str.Length; i++)
            {
                string? substring = str[..(i + 1)];
                string? reversed = new string(substring.Reverse().ToArray());

                if (substring == reversed)
                {
                    partition.Add(substring);

                    FindPartition(str[(i + 1)..], partition);

                    partition.RemoveAt(partition.Count - 1);
                }
            }
        }

        FindPartition(s, new List<string>());
        
        return output;
    }    
 }
