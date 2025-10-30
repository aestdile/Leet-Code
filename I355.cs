public class Solution{
    public int MinNumberOperations(int[] target){
        int n = target.Length;
        int ans = target[0];

        for (int i = 1; i < n; ++i)
            ans += Math.Max(target[i] - target[i - 1], 0);

        return ans;
    }
}
