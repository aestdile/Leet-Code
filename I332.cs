public class Solution {
    public int MaxDistinctElements(int[] nums, int k) {
        Array.Sort(nums);
        HashSet<int> arr = new HashSet<int>();
        int target = nums[0] - k;
        arr.Add(target);
        for(int i = 1; i < nums.Length; i++)
        {
            int low = Math.Min(target + 1, nums[i] + k);
            target = Math.Max(low, nums[i] - k);
            if(target <= nums[i] + k)
            {
                arr.Add(target);
            }
        }
        return arr.Count;
    }
}
