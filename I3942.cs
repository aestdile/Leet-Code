public class Solution {
    public int MinOperations(int[] nums) {
        int n = nums.Length;
        if (n == 1) {
            return 0;
        }

        int start = Array.IndexOf(nums, 0);
        bool asc = true;
        bool desc = true;
        for (int i = 1; i < n; i++) {
            int value = nums[(start + i) % n];

            if (value != i) {
                asc = false;
            }
            if (value != n - i) {
                desc = false;
            }
            if (!asc && !desc) {
                return -1;
            }
        }

        if (asc) {
            return Math.Min(start, n - start + 2);
        }

        return Math.Min(n - start, start + 2);
    }
}
