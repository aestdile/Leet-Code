public class Solution {
    public int MinFlips(string s) {
        int n = s.Length;
        string doubled = s + s;

        // Build two alternating patterns of length 2n
        char[] alt1 = new char[2 * n];
        char[] alt2 = new char[2 * n];
        for (int i = 0; i < 2 * n; i++) {
            alt1[i] = (i % 2 == 0) ? '0' : '1';
            alt2[i] = (i % 2 == 0) ? '1' : '0';
        }

        int res = n; // upper bound
        int diff1 = 0, diff2 = 0;
        int left = 0;

        for (int right = 0; right < 2 * n; right++) {
            if (doubled[right] != alt1[right]) diff1++;
            if (doubled[right] != alt2[right]) diff2++;

            if (right - left + 1 > n) {
                if (doubled[left] != alt1[left]) diff1--;
                if (doubled[left] != alt2[left]) diff2--;
                left++;
            }

            if (right - left + 1 == n) {
                res = Math.Min(res, Math.Min(diff1, diff2));
            }
        }

        return res;
    }
}
