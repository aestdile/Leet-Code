public class Solution {
    public bool HasIncreasingSubarrays(IList<int> nums, int k) {
        int inc = 1, part = 1;
        for (int i = 1; i < nums.Count; i++) {
            if (nums[i] > nums[i - 1]) inc++;
            else {
                if(inc >= k && part == 1){
                    inc = k + 1;
                    part = 2;
                } 
                else {
                    inc = 1;
                    part = 1;
                } 
            }
            if (inc == 2 * k) return true;
        }
        return false;
    }
}
