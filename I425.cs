public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        if(nums == null || nums.Length == 0 || k == null || k < 0) return false;

        Dictionary<int, int> dict = new Dictionary<int, int>();

        for(int i = 0; i < nums.Length; i++){
            if(dict.ContainsKey(nums[i]) && Math.Abs(i - dict[nums[i]]) <= k) return true;
            else if(dict.ContainsKey(nums[i])) dict[nums[i]] = i;
            else dict.Add(nums[i], i);
        }
        return false;
    }
}
