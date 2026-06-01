public class Solution {
    public int MinimumCost(int[] cost) => cost
        .OrderByDescending(m => m)
        .Select((m,i) => new { Index = i + 1, Value = m } )
        .Where(m => m.Index % 3 != 0)
        .Sum(m => m.Value);
}
