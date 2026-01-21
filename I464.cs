public class Solution
{
    public int[] MinBitwiseArray(IList<int> nums)
    {
        int n = nums.Count;
        int[] res = new int[n];

        for (int i = 0; i < n; i++)
        {
            int val = nums[i];

            if ((val & 1) == 0)
            {
                res[i] = -1;
                continue;
            }

            int t = 0;
            int temp = val;
            while ((temp & 1) == 1)
            {
                t++;
                temp >>= 1;
            }

            long subtract = 1L << (t - 1);
            res[i] = (int)(val - subtract);
        }

        return res;
    }
}
