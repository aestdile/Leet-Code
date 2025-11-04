public class Solution {
    public int[] FindXSum(int[] nums, int k, int x) {
        return Enumerable.Range(0, nums.Length - k + 1).Select(i => nums.Skip(i).Take(k).GroupBy(v => v).OrderBy(v => -v.Count()).ThenBy(v => -v.Key).Take(x).Sum(v => v.Key * v.Count())).ToArray();
    }
}
