public class Solution {
    public int MaximizeSquareArea(int m, int n, int[] hFences, int[] vFences) {
        var set0 = CreateSet2(m, hFences);
        var list = new List<int>(set0);
        list.Sort();
        var set1 = CreateSet2(n, vFences);
        var side = 0;
        for(int i = list.Count - 1; i >= 0; i--)
        {
            if (set1.Contains(list[i]))
            {
                side = list[i];
                break;
            }
        }
        if (side == 0) return -1;
        long sq = side * (long)side;
        var rs = (int)(sq % 1_000_000_007);
        return rs;
    }
    private HashSet<int> CreateSet2(int k, int[] arr)
    {
        var list = new List<int>(arr);
        list.Add(1);
        list.Add(k);
        list.Sort();
        var set = new HashSet<int>();
        for (int i = 0; i < list.Count - 1; i++)
        {
            for (int j = i + 1; j < list.Count; j++)
            {
                set.Add(list[j] - list[i]);
            }
        }
        return set;
    }
}
