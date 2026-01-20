public class Solution {
    public int[] MinBitwiseArray(IList<int> nums) => nums.Select(num => num % 2 == 0 ? -1 : num - ((num + 1) & (-num - 1)) / 2).ToArray();
}
