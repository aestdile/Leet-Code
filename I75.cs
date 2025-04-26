public class Solution
{
    public long CountSubarrays(int[] nums, int minK, int maxK)
    {
        long res = 0;
        int minI = -1, maxI = -1, bad = -1;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] < minK || nums[i] > maxK) bad = i;
            if (nums[i] == minK) minI = i;
            if (nums[i] == maxK) maxI = i;
            res += Math.Max(0, Math.Min(minI, maxI) - bad);
        }
        return res;
    }
}
