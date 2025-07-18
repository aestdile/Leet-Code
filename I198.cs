public class Solution {
    public long MinimumDifference(int[] nums) {
            var length = nums.Length;
            var n = length / 3;

            var pq = new PriorityQueue<int, int>();
            var backSum = 0L;

            for (var i = length - n; i < length; i++)
            {
                pq.Enqueue(nums[i], nums[i]);
                backSum += nums[i];
            }

            var rightSums = new long[length - n + 1];
            rightSums[length - n] = backSum;
            for (var i = length - n - 1; i >= n; i--)
            {
                pq.Enqueue(nums[i], nums[i]);
                backSum += nums[i] - pq.Dequeue();
                rightSums[i] = backSum;
            }
            pq.Clear();

            var preSum = 0L;

            for (var i = 0; i < n; i++)
            {
                pq.Enqueue(nums[i], -nums[i]);
                preSum += nums[i];
            }

            var result = preSum - rightSums[n];
            for (var i = n; i < length - n; i++)
            {
                pq.Enqueue(nums[i], -nums[i]);
                preSum += nums[i] - pq.Dequeue();
                result = Math.Min(result, preSum - rightSums[1 + i]);
            }

            return result;
    }
}
