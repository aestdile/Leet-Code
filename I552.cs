public class Solution {
    public long[] Distance(int[] nums) 
    {
        int n = nums.Length;
        var totalCount = new Dictionary<int, long>();
        var data = new Dictionary<int, long>();
        var result = new long[n];

        for(int i = 0; i < n; ++i)
        {
            data.TryAdd(nums[i], 0);
            totalCount.TryAdd(nums[i], 0);

            result[i] = totalCount[nums[i]]*i - data[nums[i]];
            
            totalCount[nums[i]] += 1;
            data[nums[i]] += i;
        }

        data = new Dictionary<int, long>();
        totalCount = new Dictionary<int, long>();
        for(int i = n - 1; i >= 0; --i)
        {
            data.TryAdd(nums[i], 0);
            totalCount.TryAdd(nums[i], 0);

            result[i] += (-totalCount[nums[i]]*i + data[nums[i]]);
            
            totalCount[nums[i]] += 1;
            data[nums[i]] += i;
        }

        return result;
    }
}
