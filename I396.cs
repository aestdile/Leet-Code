public class Solution {
    public int MinSubarray(int[] nums, int p) {
        int  n=nums.Length;
        int sum=0;
        foreach(int num in nums){
            sum=(sum%p+num%p);
        }
        int target=sum%p;
        
        if(target==0) return 0;
        
        Dictionary<int,int> mp=new Dictionary<int,int>();
        int curr=0;
        mp[0]=-1;
        int result=n;
        for(int j=0;j<n;j++){
            curr=(curr+nums[j])%p;
            int remain=(curr-target+p)%p;
            if(mp.ContainsKey(remain)){
                result=Math.Min(result,j-mp[remain]);
            }
            mp[curr]=j;
        }
        return result==n ? -1 : result;

    }
}