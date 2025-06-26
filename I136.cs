public class Solution {
    public int LongestSubsequence(string s, int k) {
        int sm = 0;
        int cnt = 0;
        int bits = (int)(Math.Log(k, 2)) + 1;
        for (int i = 0; i < s.Length; i++)
        {
            char ch = s[s.Length - 1 - i];
            if (ch == '1')
            {
                if (i < bits && sm + (1 << i) <= k)
                {
                    sm += 1 << i;
                    cnt++;
                }
            }
            else
            {
                cnt++;
            }
        }
        return cnt;
    }
}
