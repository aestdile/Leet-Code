public class Solution {
    public int MaximumJumps(int[] nums, int target) {
        int len = nums.Length;
        int[] jumps = Enumerable.Repeat(-1, len).ToArray();
        jumps[0] = 0;

        for(int i = 0; i < len-1; i++)
        {
            if(jumps[i] < 0)
                continue;

            for(int j = i+1; j < len; j++)
            {
                if(Math.Abs(nums[i]-nums[j]) > target)
                    continue;

                jumps[j] = Math.Max(jumps[j], jumps[i]+1);
            }
        }

        return jumps[len-1];
    }
}
