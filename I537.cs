public class Solution {
    public int XorAfterQueries(int[] nums, int[][] queries)
    {
        int mod = Convert.ToInt32(Math.Pow(10, 9) + 7);
        int xor = 0;
        var queue = new PriorityQueue<int, int>();
        for (int i = 0; i < queries.Length; i++)
        {
            queue.Enqueue(i, queries[i][0]);
        }

        for (int i = 0; i < nums.Length; i++)
        {
            while (queue.Count > 0 && queue.TryPeek(out int index, out int smallestIndex) && smallestIndex == i)
            {
                queue.Dequeue();
                int[] q = queries[index];
                int l = q[0], r = q[1], k = q[2], v = q[3];

                nums[i] = (int)((long)nums[i] * v % mod);
                if (i + k <= r)
                {
                    queue.Enqueue(index, i+k);
                }
            }
            xor = xor ^ nums[i];
        }

        return xor;
    }
}
