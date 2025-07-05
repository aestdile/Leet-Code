public class Solution {
    public void NextPermutation(int[] nums) {
        int n = nums.Length, i = n-2;
        while(i >= 0 && nums[i] >= nums[i+1]) {
            i--;
        }
        if(i > -1) {
            int j=i;
            while(j < n-1 && nums[i] < nums[j+1]) {
                j++;
            }
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
        int l=i+1, r=n-1;
        while(l < r) {
            int t = nums[l];
            nums[l++] = nums[r];
            nums[r--] = t;
        }
    }
}
