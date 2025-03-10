public class Solution {
    public int FirstMissingPositive(int[] nums)
    {
        int n = nums.Length;
 
        for (int i = 0; i < n; i++)
        {
            if (nums[i] <= 0 || nums[i] > n)
                nums[i] = n + 1;
        }

        for (int i = 0; i < n; i++)
        {
            int num = Math.Abs(nums[i]);
            if (num <= n)
                nums[num - 1] = -Math.Abs(nums[num - 1]);
        }

        for (int i = 0; i < n; i++)
        {
            if (nums[i] > 0)
                return i + 1;
        }
        
        return n + 1;
    }

}
