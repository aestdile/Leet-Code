public class Solution {
    public long MaxTotalValue(int[] nums, int k) {
        return ((long)nums.Max() - nums.Min()) * k;
    }
}
