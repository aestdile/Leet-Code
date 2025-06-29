public class Solution 
{
    public int ThreeSumClosest(int[] nums, int target)
    {
        Array.Sort(nums);
        int minDelta = int.MaxValue;
        int result = 0;
        var countI = nums.Length - 2;

        for (var i = 0; i < countI; i++)
        {
            var j = i + 1;
            var k = nums.Length - 1;
            while (j < k)
            {
                var sum = nums[i] + nums[j] + nums[k];
                if (sum == target)
                {
                    return sum;
                }
                var delta = Math.Abs(sum - target);
                if (delta < minDelta)
                {
                    minDelta = delta;
                    result = sum;
                }

                if (sum < target) {
                    j++;
                }
                else {
                    k--;
                }
            }
        }
        return result;
    }
}
