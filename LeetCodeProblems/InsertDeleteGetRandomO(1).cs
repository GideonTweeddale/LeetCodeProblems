namespace LeetCodeProblems;
public class RandomizedSet

{
    HashSet<int> hashSet = new();
    Random random = new();

    public bool Insert(int val) => hashSet.Add(val);

    public bool Remove(int val) => hashSet.Remove(val);

    public int GetRandom()
    {
        List<int> randomList = hashSet.ToList();
        int randomIndex = random.Next(0, randomList.Count);

        return randomList[randomIndex];
    }
}
