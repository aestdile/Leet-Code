public class Solution {
    public int MinMoves(int[] nums, int limit) {
        int n = nums.Length;
        int[] memo = new int[2*limit+2];
        int min = int.MaxValue;

        for(int i=0; i<=(n-1)/2; ++i){
            int l = nums[i];
            int r = nums[n-1-i];

            memo[Math.Min(l,r)+1]--;
            memo[l+r]--;
            memo[l+r+1]++;
            memo[Math.Max(l,r)+limit+1]++;
        }

        int val = n;
        for(int i=2; i<=2*limit; ++i){
            val += memo[i];
            min = Math.Min(val, min);
        }

        return min;
    }
}
