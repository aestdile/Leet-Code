public class Solution {
    public int MinPairSum(int[] nums) {
      Array.Sort(nums);
      int maxPairSum=0;
      int i=0,j=nums.Length-1;

      while(i<j){
        //Creating pair of smallest and largest
        int currentSum= nums[i]+nums[j];
        
        //Keeping track of maximum Pair sum found so far.
        if(currentSum>maxPairSum) maxPairSum=currentSum;

        // moving pointers inward;
        i++;
        j--;
      }
      return maxPairSum;
    }
}
