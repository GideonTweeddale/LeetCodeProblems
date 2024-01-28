namespace LeetCodeProblems.Array;
public class NumArray
{
    private int[] _nums;

    public NumArray(int[] nums)
    {
        _nums = nums;
    }

    public int SumRange(int left, int right)
    {
        int sum = 0;

        for (int i = left; i <= right; i++)
        {
            sum += _nums[i];
        }

        return sum;
    }
}

// using precalculated left sums to avoid needing to iterate over the index each time the SumRange is called
public class NumArrayB
{
    private int[] _nums;

    public NumArrayB(int[] nums)
    {
        _nums = new int[nums.Length + 1];

        for (int i = 0; i < nums.Length; i++)
        {
            _nums[i + 1] = _nums[i] + nums[i];
        }
    }

    public int SumRange(int left, int right)
    {
        return _nums[right + 1] - _nums[left];
    }
}

