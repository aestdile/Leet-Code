public class Solution {
    public IList<IList<int>> FourSum(int[] nums, int target) {
        var results = new List<IList<int>>();
        if(nums == null || nums.Length < 4)
            return results;

        Array.Sort(nums);

        for(var i = 0; i < nums.Length - 3; i++)
        {
            if(i > 0 && nums[i] == nums[i-1]) continue;
            for(var j = i+1; j < nums.Length - 2; j++)
            {
                if(j > i+1 && nums[j] == nums[j-1]) continue;
                long sum = nums[i] + nums[j];
                var left = j+1;
                var right = nums.Length - 1;

                while(left < right)
                {
                    long total = sum + nums[left] + nums[right];

                    if(total == target)
                    {
                        results.Add(new List<int>{nums[i], nums[j], nums[left], nums[right]});
                        left++;
                        right--;
                        while(left < right && nums[left] == nums[left-1]) left++;
                        while(left < right && nums[right] == nums[right+1]) right--;
                    } 
                    else if (total < target)
                        left++;
                    else
                        right--;

                }
            }
        }

        return results;
    }
}
