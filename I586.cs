public class Solution {
    private int[] seg;

    private void Update(int idx, int val, int p, int l, int r) {
        if (l == r) {
            seg[p] = val;
            return;
        }
        int mid = (l + r) >> 1;
        if (idx <= mid) {
            Update(idx, val, p << 1, l, mid);
        } else {
            Update(idx, val, p << 1 | 1, mid + 1, r);
        }
        seg[p] = Math.Max(seg[p << 1], seg[p << 1 | 1]);
    }

    private int Query(int L, int R, int p, int l, int r) {
        if (L <= l && r <= R) {
            return seg[p];
        }
        int mid = (l + r) >> 1;
        int res = 0;
        if (L <= mid) {
            res = Math.Max(res, Query(L, R, p << 1, l, mid));
        }
        if (R > mid) {
            res = Math.Max(res, Query(L, R, p << 1 | 1, mid + 1, r));
        }
        return res;
    }

    public IList<bool> GetResults(int[][] queries) {
        int mx = 50000;
        seg = new int[mx << 2];
        SortedSet<int> st = new SortedSet<int> { 0, mx };
        Update(mx, mx, 1, 0, mx);
        List<bool> ans = new List<bool>();

        foreach (int[] q in queries) {
            if (q[0] == 1) {
                int x = q[1];
                int r = st.GetViewBetween(x + 1, int.MaxValue).Min;
                int l = st.GetViewBetween(int.MinValue, x - 1).Max;
                Update(x, x - l, 1, 0, mx);
                Update(r, r - x, 1, 0, mx);
                st.Add(x);
            } else {
                int x = q[1];
                int sz = q[2];
                int pre = st.GetViewBetween(int.MinValue, x).Max;
                int max_space = Query(0, pre, 1, 0, mx);
                max_space = Math.Max(max_space, x - pre);
                ans.Add(max_space >= sz);
            }
        }
        return ans;
    }
}
