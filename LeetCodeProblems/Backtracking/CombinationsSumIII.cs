namespace LeetCodeProblems.Backtracking;
public class CombinationsSumIII
{
    private int[] nums = [9,8,7,6,5,4,3,2,1];

    public IList<IList<int>> CombinationSum3(int k, int n)
    {
        IList<IList<int>> output = new List<IList<int>>();

        void Backtrack(List<int> combinations, int index)
        {
            if (combinations.Count == k)
            {
                if (n == 0) output.Add(new List<int>(combinations));
                return;
            }

            if (index == nums.Length) return;

            n -= nums[index];
            combinations.Add(nums[index]);
            Backtrack(combinations, index + 1);

            n += nums[index];
            combinations.RemoveAt(combinations.Count - 1);
            Backtrack(combinations, index + 1);
        }

        Backtrack(new List<int>(), 0);

        return output;
    }
}
