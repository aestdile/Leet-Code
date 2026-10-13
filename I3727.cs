public class Solution {
    public long MaxAlternatingSum(int[] nums) {
        int n=nums.Length;
        long ans=0;
        for(int i=0;i<n;i++) if(nums[i]<0) nums[i]=nums[i]*(-1);
        Array.Sort(nums);
        for(int i=0;i<n/2;i++){
            if(i==(n-i-1)) ans+=(nums[i]*nums[i]);
            else
            ans+= ((nums[n-i-1]*nums[n-i-1])-(nums[i]*nums[i]));
        }
        if(n%2==1) ans+=(nums[n/2]*nums[n/2]);
        return ans;
    }
}
