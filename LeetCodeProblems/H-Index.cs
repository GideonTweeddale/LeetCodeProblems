namespace LeetCodeProblems;
public static class HIndex11
{
    public static int HIndex(int[] citations)
    {
        int h = 0;
        Array.Sort(citations);

        for (int i = citations.Length - 1; i >= 0; i--)
        {
            if (citations[i] > h)
            {
                if (h < citations[i])
                {
                    h++;
                }
                else
                {
                    return h;
                }
            }
        }

        return h;
    }

    public static int HIndexB(int[] citations)
    {
        int start = 0;
        int end = citations.Length - 1;

        Array.Sort(citations);

        while (start <= end)
        {
            int mid = start + (end - start) / 2;

            int countOfElementsInRightIncludingCurrent = citations.Length - mid;
            
            if (citations[mid] == countOfElementsInRightIncludingCurrent)
            {
                return citations[mid];
            }
            else if (citations[mid] < countOfElementsInRightIncludingCurrent)
            {
                start = mid + 1;
            }
            else
            {
                end = mid - 1;
            }
        }

        return citations.Length - start;
    }
}
