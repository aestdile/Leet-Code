public sealed class Solution
{
    public int MostBooked(int n, int[][] meetings)
    {
        var t = new int[n];

        var r = new PriorityQueue<int, (long to, int n)>();

        var f = new PriorityQueue<int, int>(Enumerable.Range(0, n).Select(i => (i, i)));

        Array.Sort(meetings, (a, b) => a[0] - b[0]);

        for (int i = 0; i < meetings.Length; i++)
        {
            while (r.TryPeek(out var room, out var p) && p.to <= meetings[i][0])
            {
                f.Enqueue(room, room);
                r.Dequeue();
            }

            if (f.Count > 0)
            {
                var room = f.Dequeue();

                t[room]++;
                r.Enqueue(room, (meetings[i][1], room));
            }
            else
            {
                r.TryDequeue(out var room, out var pr);

                t[room]++;

                var from = meetings[i][0];
                var to = meetings[i][1];

                r.Enqueue(room, (pr.to + to - from, room));
            }
        }

        var max = 0;
        var ans = 0;
        for (int i = 0; i < n; i++)
        {
            if (max < t[i])
            {
                max = t[i];
                ans = i;
            }
        }

        return ans;
    }
}
