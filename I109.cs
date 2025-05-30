public class Solution {
    public int ClosestMeetingNode(int[] edges, int node1, int node2) {
        int n = edges.Length;
        int[] dist1 = GetDistances(edges, node1);
        int[] dist2 = GetDistances(edges, node2);
        int minDistance = int.MaxValue;
        int answer = -1;
        for (int i = 0; i < n; i++) {
            if (dist1[i] != -1 && dist2[i] != -1) {
                int maxDist = Math.Max(dist1[i], dist2[i]);
                if (maxDist < minDistance) {
                    minDistance = maxDist;
                    answer = i;
                }
            }
        }
        return answer;
    }

    private int[] GetDistances(int[] edges, int start) {
        int n = edges.Length;
        int[] dist = new int[n];
        Array.Fill(dist, -1); // -1 means unreachable
        int current = start;
        int d = 0;
        while (current != -1 && dist[current] == -1) {
            dist[current] = d;
            d++;
            current = edges[current];
        }
        return dist;
    }
}
