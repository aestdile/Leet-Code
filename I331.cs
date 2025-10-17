public class Solution {
    public int MaxPartitionsAfterOperations(string s, int k) {
        int n = s.Length;
        int[][] left = new int [n][];
        int[][] right = new int [n][];

        for (int i = 0; i < n; i++) {
            left[i] = new int[3];
            right[i] = new int[3];
        }

        int num = 0, mask = 0, count = 0;
        for (int i = 0; i < n - 1; i++) {
            int binary = 1 << (s[i] - 'a');
            if ((mask & binary) == 0) {
                count++;
                if (count <= k) {
                    mask |= binary;
                } else {
                    num++;
                    mask = binary;
                    count = 1;
                }
            }
            left[i + 1][0] = num;
            left[i + 1][1] = mask;
            left[i + 1][2] = count;
        }

        num = 0;
        mask = 0;
        count = 0;
        for (int i = n - 1; i > 0; i--) {
            int binary = 1 << (s[i] - 'a');
            if ((mask & binary) == 0) {
                count++;
                if (count <= k) {
                    mask |= binary;
                } else {
                    num++;
                    mask = binary;
                    count = 1;
                }
            }
            right[i - 1][0] = num;
            right[i - 1][1] = mask;
            right[i - 1][2] = count;
        }

        int max = 0;
        for (int i = 0; i < n; i++) {
            int seg = left[i][0] + right[i][0] + 2;
            int totMask = left[i][1] | right[i][1];
            int totCount = 0;
            while (totMask != 0) {
                totMask = totMask & (totMask - 1);
                totCount++;
            }
            if (left[i][2] == k && right[i][2] == k && totCount < 26) {
                seg++;
            } else if (Math.Min(totCount + 1, 26) <= k) {
                seg--;
            }
            max = Math.Max(max, seg);
        }
        return max;
    }
}
