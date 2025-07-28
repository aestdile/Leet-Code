public class Solution {
    private int count = 0;
    private int maxOr = 0;

    public int CountMaxOrSubsets(int[] nums) {
        foreach (int num in nums) {
            maxOr |= num;
        }

        Dfs(nums, 0, 0);
        return count;
    }

    private void Dfs(int[] nums, int index, int currentOr) {
        if (index == nums.Length) {
            if (currentOr == maxOr) {
                count++;
            }
            return;
        }

        Dfs(nums, index + 1, currentOr | nums[index]);
        Dfs(nums, index + 1, currentOr);
    }
}
