namespace LeetCodeProblems.Backtracking;
public class Permutations
{
    public static IList<IList<int>> Permute(int[] nums)
    {
        // this is obiously a brute force backtracking solution
        // the time complexity is O(2^n) and the space complexity is O(2^n)

        IList<IList<int>> permuts = [];

        void DFS(List<int> path)
        {
            if (path.Count == nums.Length)
            {
                permuts.Add(new List<int>(path));
                return;
            }

            foreach (int num in nums)
            {
                if (path.Contains(num))
                {
                    continue;
                }

                path.Add(num);

                DFS(path);

                path.RemoveAt(path.Count - 1);
            }
        }

        DFS([]);
        return permuts;
    }
    public static IList<IList<int>> PermuteB(int[] nums)
    {
        // this is obiously a brute force backtracking solution
        // the time complexity is O(2^n) and the space complexity is O(2^n)

        List<IList<int>>? result = [];
        Backtrack(0);
        return result;

        void Backtrack(int start)
        {
            if (start == nums.Length)
            {
                int[]? copy = new int[nums.Length];
                Array.Copy(nums, copy, nums.Length);
                result.Add(copy);
                return;
            }

            for (int i = start; i < nums.Length; i++)
            {
                (nums[i], nums[start]) = (nums[start], nums[i]);
                Backtrack(start + 1);
                (nums[i], nums[start]) = (nums[start], nums[i]);
            }
        }
    }
}
