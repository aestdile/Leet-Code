public class Solution {
    public int ThirdMax(int[] nums) {
        var distinctNums = nums.Distinct().OrderByDescending(x => x).ToList();
        return distinctNums.Count >= 3 ? distinctNums[2] : distinctNums[0];
    }
}
