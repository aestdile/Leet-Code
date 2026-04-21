public class Solution
{
    int[] parent;
    public int MinimumHammingDistance(int[] source, int[] target, int[][] allowedSwaps)
    {
        var minimumHammingDistance = 0;
        parent = new int[source.Length];
        var map = new Dictionary<int, List<int>>();

        Array.Fill(parent, -1);

        foreach (var allowedSwap in allowedSwaps)
        {
            var parentA = Find(allowedSwap[0]);
            var parentB = Find(allowedSwap[1]);
            if(parentA != parentB)
                parent[parentB] = parentA;
        }

        for (int idx = 0; idx < source.Length; idx++)
        {
            var index = Find(idx);
            if(!map.ContainsKey(index))
                map[index] = new List<int>();
            map[index].Add(idx);
        }

        foreach (var kv in map)
        {
            var list = new List<int>();
            var set = new Dictionary<int, int>();
            
            foreach(var idx in kv.Value)
            {
                set[target[idx]] = 1 + set.GetValueOrDefault(target[idx], 0);
                list.Add(source[idx]);
            }

            foreach (var idx in kv.Value)
            {
                if (!set.ContainsKey(source[idx]) || set[source[idx]] == 0)
                    minimumHammingDistance++;
                else
                    set[source[idx]]--;
            }
        }

        return minimumHammingDistance;
    }

    private int Find(int idx)
    {
        if (parent[idx] == -1)
            return idx;

        parent[idx] = Find(parent[idx]);
        return parent[idx];
    }
}
