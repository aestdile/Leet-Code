public class Solution {
    public string LongestPalindrome(string s) {
        int start = 0, len = 0;
        for (int i = 0; i < s.Length; i++) {
            Expand(i, i);
            Expand(i, i + 1);
        }
        return s.Substring(start, len);

        void Expand(int l, int r) {
            while (l >= 0 && r < s.Length && s[l] == s[r]) { l--; r++; }
            if (r - l - 1 > len) { start = l + 1; len = r - l - 1; }
        }
    }
}
