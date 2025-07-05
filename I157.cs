public class Solution {
    public int FindLucky(int[] arr) => arr.OrderBy(m => m).
        GroupBy(m => m).
        Where(m => m.Key == m.Count()).
        LastOrDefault()?.Key ?? -1;
}
