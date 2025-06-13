public class Solution {
    public int MinimizeMax(int[] nums, int p) {
        Array.Sort(nums);

        int left = 0, right = nums[^1] - nums[0];
        while (left < right) {
            int mid = (left + right) / 2;
            if (CanFormPairs(nums, p, mid)) {
                right = mid;
            } else {
                left = mid + 1;
            }
        }
        return left;
    }
    private bool CanFormPairs(int[] nums, int p, int maxDiff) {
        int count = 0;
        for (int i = 0; i < nums.Length - 1; ) {
            if (Math.Abs(nums[i] - nums[i + 1]) <= maxDiff) {
                count++;
                i += 2; 
            } else {
                i++; 
            }

            if (count >= p)
                return true;
        }
        return false;
    }
}
