namespace LeetCodeProblems.Backtracking;
public class CombinationsSumII
{
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        Array.Sort(candidates);

        IList<IList<int>> output = new List<IList<int>>();

        void Backtrack(IList<int> combinations, int index)
        {
            // valid combination base case
            if (target == 0)
            {
                output.Add(new List<int>(combinations));
                return;
            }

            // invalid combination base case
            if (target < 0 || index == candidates.Length)
            {
                return;
            }

            // if we have a duplicate number, don't include it
            if (index > 0 && candidates[index - 1] == candidates[index])
            {
                return;
            }

            // call for the next candidate index and the current
            target -= candidates[index];
            combinations.Add(candidates[index]);
            Backtrack(combinations, index + 1);

            // call for the next candidate without the current (backtrack)
            target += candidates[index];
            combinations.RemoveAt(combinations.Count - 1);

            // skip duplicates
            while ((index + 1) < candidates.Length && candidates[index] == candidates[index + 1])
            {
                index += 1;
            }

            Backtrack(combinations, index + 1);
        }

        Backtrack(new List<int>(), 0);

        return output;
    }
}
