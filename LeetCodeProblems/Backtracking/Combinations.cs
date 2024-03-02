namespace LeetCodeProblems.Backtracking;
public class Combinations
{
    public IList<IList<int>> Combine(int n, int k)
    {
        // initialise the result list
        IList<IList<int>> result = new List<IList<int>>();

        // define the backtracking function locally
        void Backtrack(int start, IList<int> combination)
        {
            // our base case is when our new lists are the max length
            if (combination.Count == k)
            {
                // add the list created
                result.Add(new List<int>(combination));
                // and backtrack
                return;
            }

            // for all valid integers
            for (int i = start; i <= n; i++)
            {
                // add the integer
                combination.Add(i);
                // follow it down to the base case
                Backtrack(i + 1, combination);
                // when we've backtracked, remove the item we added from the end of the list 
                combination.RemoveAt(combination.Count - 1);
                // and loop to add the next higher number
            }
        }

        // call backtrack with our first non zero int and a new list
        Backtrack(1, new List<int>());

        return result;
    }
}
