public class Solution {
    public int LongestBalanced(int[] nums) {
        int n = nums.Length;
        int ans = 0;

        for (int i = 0; i < n; i++) {
            HashSet<int> even = new HashSet<int>();
            HashSet<int> odd = new HashSet<int>();

            for (int j = i; j < n; j++) {
                if (nums[j] % 2 == 0)
                    even.Add(nums[j]);
                else
                    odd.Add(nums[j]);

                if (even.Count == odd.Count)
                    ans = Math.Max(ans, j - i + 1);
            }
        }

        return ans;
    }
}
