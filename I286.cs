public class Solution {
    public void DuplicateZeros(int[] arr) {
        int[] nums = (int [])arr.Clone();
        for(int i =0 , j = 0 ; j<arr.Length; i++ , j++){
            if(nums[i] == 0 && j != arr.Length -1 ){
                arr[j] = 0;
                arr[j+1] =0;
                j++;
            }
            else{
                arr[j] = nums[i];
            }
        }
    }
}
