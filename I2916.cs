
public class Solution{
    private const long MOD = 1_000_000_007;

    private class SegmentTreeNode
    {
        private readonly int lo;
        private readonly int hi;

        public long val;
        private long lazy;

        private SegmentTreeNode left;
        private SegmentTreeNode right;

        public SegmentTreeNode(int lo, int hi)
        {
            this.lo = lo;
            this.hi = hi;

            if (lo + 1 < hi)
            {
                int mid = (lo + hi) / 2;
                left = new SegmentTreeNode(lo, mid);
                right = new SegmentTreeNode(mid, hi);
            }
        }

        public void Update(long value)
        {
            lazy += value;
            val += value * (hi - lo);
        }

        public long Query(int queryLo, int queryHi)
        {
            if (lo >= queryLo && hi <= queryHi)
            {
                long result = val;
                Update(1);
                return result;
            }

            int mid = (lo + hi) / 2;

            left.Update(lazy);
            right.Update(lazy);
            lazy = 0;

            long res = 0;

            if (queryLo < mid)
                res += left.Query(queryLo, queryHi);

            if (queryHi > mid)
                res += right.Query(queryLo, queryHi);

            val = left.val + right.val;

            return res;
        }
    }

    public int SumCounts(int[] nums)
    {
        var lastIndex = new Dictionary<int, int>();
        var segmentTree = new SegmentTreeNode(0, nums.Length);

        long res = 0;
        long currRes = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];

            int lastIdx = lastIndex.TryGetValue(num, out int previousIndex)
                ? previousIndex + 1
                : 0;

            currRes = (
                currRes
                + i - lastIdx + 1
                + 2 * segmentTree.Query(lastIdx, i + 1)
            ) % MOD;

            res = (res + currRes) % MOD;

            lastIndex[num] = i;
        }

        return (int)res;
    }
}
