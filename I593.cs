public class Solution
{
    public int[] LeftRightDifference(int[] nums)
    {
        var leftSum = 0;
        var rightSum = nums.Sum();

        for (var i = 0; i < nums.Length; i++)
        {
            var val = nums[i];
            rightSum -= val;

            nums[i] = Math.Abs(leftSum - rightSum);
            leftSum += val;
        }

        return nums;
    }
}
