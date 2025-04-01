public class Solution {
    public int LongestPalindrome(string s) {
        var counts = new int[128];
        int length = 0;

        foreach (char c in s) counts[c]++;

        foreach (int count in counts) {
            length += count / 2 * 2;
            if (length % 2 == 0 && count % 2 == 1) length++;
        }
        return length;
    }
}
