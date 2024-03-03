namespace LeetCodeProblems.Backtracking;
public class CombinationsII
{
    public IList<IList<int>> CombinationSumB(int[] candidates, int target)
    {
        IList<IList<int>> output = new List<IList<int>>();

        void Backtrack(IList<int> combinations, int index)
        {
            if (target == 0)
            {
                output.Add(new List<int>(combinations));
                return;
            }

            if (target < 0 || index == candidates.Length)
            {
                return;
            }

            target -= candidates[index];
            combinations.Add(candidates[index]);
            Backtrack(combinations, index);

            target += candidates[index];
            combinations.RemoveAt(combinations.Count - 1);
            Backtrack(combinations, index + 1);
        }

        Backtrack(new List<int>(), 0);

        return output;
    }
}
