namespace LeetCodeProblems.Backtracking;
public class PermutationsII
{
    public static IList<IList<int>> PermuteUnique(int[] nums)
    {
        Array.Sort(nums);
        List<int> input = nums.ToList();
        IList<IList<int>> result = new List<IList<int>>();
        BackTrack(input, new List<int>());
        return result;

        void BackTrack(List<int> input, List<int> tempResult)
        {
            int count = input.Count();
            if (count == 0)
            {
                result.Add(tempResult);
                return;
            }

            for (int i = 0; i < count; i++)
            {
                if (i > 0 && input[i - 1] == input[i])
                {
                    continue;
                }

                List<int>? tempPermResult = new (tempResult);
                List<int>? tempPermInput = new (input);

                tempPermResult.Add(input[i]);
                tempPermInput.RemoveAt(i);
                BackTrack(tempPermInput, tempPermResult);
            }
        }
    }
}