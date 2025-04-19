public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int maxLen = 0, left = 0;
        var map = new Dictionary<char, int>();

        for (int right = 0; right < s.Length; right++) {
            if (map.ContainsKey(s[right]) && map[s[right]] >= left)
                left = map[s[right]] + 1;

            map[s[right]] = right;
            maxLen = Math.Max(maxLen, right - left + 1);
        }
        return maxLen;
    }
}
