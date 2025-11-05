public class Helper {
    private int x;
    private long result;

    private sealed class PairComparer : IComparer<(int cnt, int num)> {
        public int Compare((int cnt, int num)a, (int cnt, int num)b) {
            int c = a.cnt.CompareTo(b.cnt);
            if (c != 0)
                return c;
            c = a.num.CompareTo(b.num);
            return c;
        }
    }

    private SortedSet<(int cnt, int num)> large;
    private SortedSet<(int cnt, int num)> small;
    private Dictionary<int, int> occ;
    private HashSet<int> inLarge;

    public Helper(int x) {
        this.x = x;
        result = 0;
        var cmp = new PairComparer();
        large = new SortedSet<(int, int)>(cmp);
        small = new SortedSet<(int, int)>(cmp);
        occ = new Dictionary<int, int>();
        inLarge = new HashSet<int>();
    }

    public void Insert(int num) {
        if (occ.TryGetValue(num, out int oldCnt) && oldCnt > 0) {
            InternalRemove((oldCnt, num));
        }

        int newCnt = oldCnt + 1;
        occ[num] = newCnt;
        InternalInsert((newCnt, num));
    }

    public void Remove(int num) {
        int cnt = occ[num];
        InternalRemove((cnt, num));
        cnt--;
        if (cnt == 0)
            occ.Remove(num);
        else
            occ[num] = cnt;

        if (cnt > 0)
            InternalInsert((cnt, num));
    }

    public long Get() => result;

    private void InternalInsert((int cnt, int num)p) {
        if (large.Count < x) {
            large.Add(p);
            inLarge.Add(p.num);
            result += (long)p.cnt * p.num;
            return;
        }

        if (large.Count > 0 && Compare(p, GetMin(large)) > 0) {
            var minL = GetMin(large);
            large.Remove(minL);
            inLarge.Remove(minL.num);
            result -= (long)minL.cnt * minL.num;

            large.Add(p);
            inLarge.Add(p.num);
            result += (long)p.cnt * p.num;

            small.Add(minL);
        } else {
            small.Add(p);
        }
    }

    private void InternalRemove((int cnt, int num)p) {
        if (inLarge.Contains(p.num)) {
            if (large.Remove(p)) {
                inLarge.Remove(p.num);
                result -= (long)p.cnt * p.num;
            }

            if (small.Count > 0) {
                var maxS = GetMax(small);
                small.Remove(maxS);
                large.Add(maxS);
                inLarge.Add(maxS.num);
                result += (long)maxS.cnt * maxS.num;
            }
        } else {
            small.Remove(p);
        }
    }

    private static (int cnt, int num) GetMin(SortedSet<(int cnt, int num)> s) {
        foreach (var v in s) return v;
        throw new InvalidOperationException();
    }

    private static (int cnt, int num) GetMax(SortedSet<(int cnt, int num)> s) {
        var it = s.Max;
        return it;
    }

    private static int Compare((int cnt, int num)a, (int cnt, int num)b) {
        int c = a.cnt.CompareTo(b.cnt);
        if (c != 0)
            return c;
        return a.num.CompareTo(b.num);
    }
}

public class Solution {
    public long[] FindXSum(int[] nums, int k, int x) {
        var helper = new Helper(x);
        var ans = new List<long>(Math.Max(0, nums.Length - k + 1));

        for (int i = 0; i < nums.Length; i++) {
            helper.Insert(nums[i]);
            if (i >= k)
                helper.Remove(nums[i - k]);
            if (i >= k - 1)
                ans.Add(helper.Get());
        }
        return ans.ToArray();
    }
}