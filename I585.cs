public class Solution {
    public int MinElement(int[] nums) 
        => nums.Select(num => num.ToString().Select(c => Convert.ToInt32(c.ToString())).Sum()).Min();
}
