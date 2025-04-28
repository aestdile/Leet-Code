public class Solution
{
    public long CountSubarrays(int[] nums, long k)
    {
        int left = 0;
        long sum = 0, count = 0;
        for (int right = 0; right < nums.Length; right++)
        {
            sum += nums[right];
            while (sum * (right - left + 1) >= k)
                sum -= nums[left++];
            count += right - left + 1;
        }
        return count;
    }
}
