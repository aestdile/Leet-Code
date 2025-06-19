public class Solution {
    public int PartitionArray(int[] nums, int k) {
        int ans = 1;
        Array.Sort(nums);
        int i =0;
        int n = nums.Length;
        if(n<2) return 1;
        int curr = nums[i];
        while(i<n){
            if(nums[i] - curr >k){
                ans++;
                curr = nums[i];
            }
            i++;
        }
        return ans;
    }
}
