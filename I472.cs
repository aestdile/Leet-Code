public class Solution {
    private const long INF = long.MaxValue;
    public long MinimumCost(string source, string target, string[] original, string[] changed, int[] cost) {
        Dictionary<string, List<(string, int)>> graph = [];
        for (int i = 0; i < original.Length; i++) {
            string u = original[i],
                   v = changed[i];
            int c = cost[i];

            if (!graph.TryAdd(u, [(v, c)]))
                graph[u].Add((v, c));
        }

        HashSet<int> changeLengths = [..original.Select(x => x.Length)];
        long minCost = MinCost(source, target, 0, changeLengths, [], graph);
        return minCost == INF ? -1 : minCost;
    }

    private long MinCost(
        string source,
        string target,
        int index,
        HashSet<int> changeLengths,
        Dictionary<int, long> cache,
        Dictionary<string, List<(string, int)>> graph)
    {
        if (index >= source.Length)
            return 0;

        if (cache.TryGetValue(index, out long cost))
            return cost;

        cost = INF;
        if (source[index] == target[index])
            cost = MinCost(source, target, index + 1, changeLengths, cache, graph);

        // consider substrings of size 1, 2, 3.....
        foreach (int len in changeLengths) {
            var length = Math.Min(len, source.Length - index);
            var sourceSubstring = source.Substring(index, length);
            var targetSubstring = target.Substring(index, length);
            var minConversionCost = Dijekstras(graph, sourceSubstring, targetSubstring);
            if (minConversionCost == -1) // unable to convert
                continue;

            var minCost = MinCost(source, target, index + len, changeLengths, cache, graph);
            if (minCost != INF)
                // if remaining string can be converted
                cost = Math.Min(cost, minCost + minConversionCost);
        }

        cache[index] = cost;
        return cost;
    }

    // return min cost to convert source to target
    private int Dijekstras(Dictionary<string, List<(string, int)>> graph, string source, string target) {
        if (source == target)
            return 0;

        PriorityQueue<string, int> pq = new();
        Dictionary<string, int> cost = [];
        cost[source] = 0;

        pq.Enqueue(source, 0);

        while (pq.Count != 0) {
            string node = pq.Dequeue();
            int currentCost = cost[node];
            if (node == target) return currentCost;
            if (!graph.ContainsKey(node)) continue;

            foreach (var (child, c) in graph[node]) {
                if (!cost.ContainsKey(child) || currentCost + c < cost[child]) {
                    cost[child] = currentCost + c;
                    pq.Enqueue(child, cost[child]);
                }
            }
        }

        return -1;
    }
}
