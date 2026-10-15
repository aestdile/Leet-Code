public class Solution {
    public int SumCounts(IList<int> nums) => Enumerable.Range(0, nums.Count).
        SelectMany(i => Enumerable.Range(i, nums.Count - i).
            Select(j => (int)Math.Pow(nums.Skip(i).
                Take(j - i + 1).
                Distinct().
                Count()
            , 2))).
        Sum();
}
