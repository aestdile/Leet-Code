public class Solution {
    public int CountBinarySubstrings(string s) {
        int ans = 0,prev = 0, curr = 1;

        for(int i = 1;i<s.Length;i++)
        {
            if(s[i] != s[i-1])
            {
                ans += Math.Min(prev, curr);
                prev = curr;
                curr = 1;
            }
            else
            {
                curr++;
            }
        }

        return ans+Math.Min(curr, prev);
    }
}
