public class Solution {
            public char FindKthBit(int n, int k)
            {
                if (k == 1) return '0';
                int mid = 1 << (n - 1);
                if (k == mid)
                {
                    return '1';
                }
                else if (k < mid)
                {
                    return FindKthBit(n - 1, k);
                }
                else
                {
                    return FindKthBit((n - 1), 2 * mid - k) == '0' ? '1' : '0';
                }
            }
}
