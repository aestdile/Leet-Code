public class Solution {
    public int CountPalindromicSubsequence(string s) {
        int count = 0;
        for (int i = 0; i < 26; ++i) {
            char currentChar = (char)(i + 97);
            int l = s.IndexOf(currentChar);
            int r = s.LastIndexOf(currentChar);
            if (l != -1 && r != -1 && l < r) {
                count += new HashSet<char>(s.Substring(l + 1, r - l - 1)).Count;
            }
        }
        return count;
    }
}