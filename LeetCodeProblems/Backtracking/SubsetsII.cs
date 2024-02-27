using System;
using System.Text;

namespace LeetCodeProblems.Backtracking;
public class SubsetsII
{        
    public IList<IList<int>> SubsetsWithDup(int[] nums)
    {
        // this is obiously a brute force backtracking solution
        // the time complexity is O(2^n) and the space complexity is O(2^n)

        IList<IList<int>> subsets = [];
        IList<int> subset = [];

        // sort nums so that duplicate elements appear together
        Array.Sort(nums);

        void DFS(int index)
        {
            if (index >= nums.Length)
            {
                subsets.Add(new List<int>(subset));
                return;
            }

            subset.Add(nums[index]);
            DFS(index + 1);

            subset.Remove(nums[index]);

            // skip any duplicates
            while (index + 1 < nums.Length && nums[index] == nums[index + 1])
            {
                index++;
            }

            DFS(index + 1);
        }

        DFS(0);
        return subsets;
    }
}
