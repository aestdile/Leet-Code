public class Solution {
    public int MissingNumber(int[] nums) {
        int[] newNums = new int[nums.Length + 1];
        for (var i = 0; i < nums.Length; i++)
        {
            newNums[nums[i]] = 1;
        }
        return Array.IndexOf(newNums, 0);
    }
}
