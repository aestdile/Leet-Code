public class Solution {
    public int SingleNumber(int[] nums) {
        for (int i=0; i<nums.Length; i++)
        {
            int a=0;
            for (int j=0; j<nums.Length; j++)
            {
                if (nums[i]==nums[j])
                {
                    a++;
                }
            }
            if (a==1)
            {
                return nums[i];
            }
        }
        return -1;
    }
}
