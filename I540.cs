public class Solution {
    public int MinimumDistance(int[] nums) => nums.Select((num, i) => (num, i)).GroupBy(p => p.Item1).Select(g => g.Select(p => p.Item2).ToArray()).Where(a => a.Length > 2).Select(a => a.Select((num, i) => i < 2 ? int.MaxValue : 2 * (a[i] - a[i - 2])).Min()).OrderBy(_ => _).FirstOrDefault(-1);
}
