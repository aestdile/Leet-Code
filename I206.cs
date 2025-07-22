public class Solution {
    public int MaximumUniqueSubarray(int[] nums) {
        int left = 0, right = 0, currentSum = 0, maxSum = 0;
        var set = new HashSet<int>();

        while (right < nums.Length)
        {
            if (!set.Contains(nums[right]))
            {
                set.Add(nums[right]);
                currentSum += nums[right];
                if (currentSum > maxSum) maxSum = currentSum;
                right++;
            }
            else
            {
                set.Remove(nums[left]);
                currentSum -= nums[left];
                left++;
            }
        }

        return maxSum;
    }
}
