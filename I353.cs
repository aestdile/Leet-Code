public class Solution {
    public int CountValidSelections(int[] nums) {
        int numValidSelections = 0;

        int valLeft = 0;
        int valRight = nums.Sum();

        for (int i = 0; i < nums.Length; ++i)
        {
            if (nums[i] == 0)
            {
                if (valLeft == valRight)
                    numValidSelections += 2;
                else if (valLeft == valRight - 1 || valLeft == valRight + 1)
                    numValidSelections += 1;
            }
            else
            {
                valLeft += nums[i];
                valRight -= nums[i];
            }
        }

        return numValidSelections;
    }
}
