public class Solution {
    public int MinSwaps(int[] nums) {
        int n = nums.Length;
        int[] digitSum = new int[n];
        for (int i = 0; i < n; i++) {
            int x = nums[i], sum = 0;
            while (x > 0) {
                sum += x % 10;
                x /= 10;
            }
            digitSum[i] = sum;
        }

        int[] indices = new int[n];
        for (int i = 0; i < n; i++) {
            indices[i] = i;
        }
        Array.Sort(indices, (a, b) => {
            if (digitSum[a] != digitSum[b]) {
                return digitSum[a].CompareTo(digitSum[b]);
            }
            return nums[a].CompareTo(nums[b]);
        });

        int[] targetPos = new int[n];
        for (int pos = 0; pos < n; pos++) {
            targetPos[indices[pos]] = pos;
        }

        bool[] visited = new bool[n];
        int cycles = 0;
        for (int i = 0; i < n; i++) {
            if (!visited[i]) {
                cycles++;
                int j = i;
                while (!visited[j]) {
                    visited[j] = true;
                    j = targetPos[j];
                }
            }
        }

        return n - cycles;
    }
}
