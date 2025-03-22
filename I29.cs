public class Solution {
    public int NumIdenticalPairs(int[] nums) {
        int c=0;
        for (int i=0; i<nums.Length; i++)
        {
            for (int j=i+1; j<nums.Length; j++)
            {
                if (nums[i]==nums[j])
                {
                    c++;
                }
            }
        }
        return c;
    }
}
