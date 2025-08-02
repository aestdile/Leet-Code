public class Solution {
    public long MinCost(int[] basket1, int[] basket2) {
        var freq = new Dictionary<int, int>();
        int m = int.MaxValue;

        foreach (var b in basket1)
        {
            if (!freq.ContainsKey(b))
                freq[b] = 0;
            freq[b]++;
            m = Math.Min(m, b);
        }
        foreach (var b in basket2)
        {
            if (!freq.ContainsKey(b))
                freq[b] = 0;
            freq[b]--;
            m = Math.Min(m, b);
        }

        var merge = new List<int>();
        foreach (var kv in freq)
        {
            int c = kv.Value;
            if (c % 2 != 0)
                return -1;
            for (int i = 0; i < Math.Abs(c) / 2; i++)
            {
                merge.Add(kv.Key);
            }
        }

        merge.Sort();
        long res = 0;
        for (int i = 0; i < merge.Count / 2; i++)
        {
            res += Math.Min(2 * m, merge[i]);
        }
        return res;
    }
}
