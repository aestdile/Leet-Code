public class Solution {
    public int[] SortByBits(int[] arr) => arr.
        OrderBy(m => Convert.ToString(m, 2).Count(m => m == '1')).
        ThenBy(m => m).
        ToArray();
}
