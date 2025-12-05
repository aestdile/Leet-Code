public class Solution {
    public int CountPartitions(int[] nums) {
        return nums.Sum() % 2 == 0 ? nums.Length - 1 : 0;
    }
}