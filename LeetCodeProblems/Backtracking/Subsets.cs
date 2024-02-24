using System;
using System.Text;

namespace LeetCodeProblems.Backtracking;
public class Subsets78
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        IList<IList<int>> subsets = [[]];

        DFSSubsets(subsets, new List<int>(), nums, 0);

        return subsets;
    }

    private void DFSSubsets(IList<IList<int>> subsets, IList<int> subset, int[] nums, int index)
    {
        subsets.Add(new List<int>(subset));

        for (int i = index; i < nums.Length; i++)
        {
            subset.Add(nums[i]); // Include the current element
            DFSSubsets(subsets, subset, nums, i + 1);
            subset.RemoveAt(subset.Count - 1); // Backtrack (remove the current element)
        }
    }
        
    public IList<IList<int>> SubsetsB(int[] nums)
    {
        // this is obiously a brute force backtracking solution
        // therefore it is O(N^2)

        IList<IList<int>> subsets = [];
        IList<int> subset = [];

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
            DFS(index + 1);
        }

        DFS(0);
        return subsets;
    }
}
