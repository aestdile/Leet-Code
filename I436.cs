public class Solution {
    public int MinDeletionSize(string[] strs) {
        int m = strs.Length;
        int n = strs[0].Length;
        int[] dp = new int[n];
        for(int i = 0; i < n; i++)
            dp[i] = 1;

        int maxContinousSub = 1;
        for(int i = 0; i < n; i++){
            for(int j = 0; j < i; j++){
                if(IsGreaterInAllStrings(i, j, strs)){
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
            maxContinousSub = Math.Max(maxContinousSub, dp[i]);
        }

        return n - maxContinousSub;
    }

    bool IsGreaterInAllStrings(int i, int j, string[] strs){
        int m = strs.Length;
        for(int row = 0; row < m; row++){
            if(strs[row][j] > strs[row][i])
                return false;
        }
        return true;
    }
}
