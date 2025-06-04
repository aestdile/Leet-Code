public class Solution {
    public string AnswerString(string word, int numFriends) {
        if (numFriends == 1) return word;
        int n = word.Length;
        string max = "";
        for (int i = 0; i < n; i++) {
            int maxLen = n - (numFriends - 1);
            if (i + maxLen > n) maxLen = n - i;
            if (maxLen > 0) {
                string sub = word.Substring(i, maxLen);
                if (string.Compare(sub, max, StringComparison.Ordinal) > 0) {
                    max = sub;
                }
            }
        }
        return max;
    }
}
