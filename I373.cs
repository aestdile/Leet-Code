public class Solution {
    public int MaxOperations(string s) {
        int countOne = 0;
        int ans = 0;
        int i = 0;
        while (i < s.Length) {
            if (s[i] == '0') {
                while (i + 1 < s.Length && s[i + 1] == '0') {
                    i++;
                }
                ans += countOne;
            } else {
                countOne++;
            }
            i++;
        }
        return ans;
    }
}