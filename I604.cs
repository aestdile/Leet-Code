public class Solution
{
    public int MaximumSafenessFactor(IList<IList<int>> grid)
    {
        int n = grid.Count;
        if (grid[0][0] == 1 || grid[n - 1][n - 1] == 1) return 0;
        int total = n * n;
        int[] q = new int[total];
        int head = 0, tail = 0;
        for (int r = 0; r < n; r++)
        {
            var row = grid[r];
            for (int c = 0; c < n; c++)
            {
                if (row[c] == 1)
                {
                    row[c] = 0;
                    q[tail++] = r * n + c;
                }
                else
                {
                    row[c] = -1;
                }
            }
        }
        int[] dr = { 1, -1, 0, 0 };
        int[] dc = { 0, 0, 1, -1 };
        int maxSafeValue = 0;
        while (head < tail)
        {
            int id = q[head++];
            int r = id / n;
            int c = id % n;
            int nd = grid[r][c] + 1;
            for (int k = 0; k < 4; k++)
            {
                int nr = r + dr[k];
                int nc = c + dc[k];
                if (nr >= 0 && nr < n && nc >= 0 && nc < n && grid[nr][nc] == -1)
                {
                    grid[nr][nc] = nd;
                    if (nd > maxSafeValue) maxSafeValue = nd;
                    q[tail++] = nr * n + nc;
                }
            }
        }
        int[] bucketHead = new int[maxSafeValue + 1];
        Array.Fill(bucketHead, -1);
        int[] nextNode = new int[total];
        int startSafe = grid[0][0];
        bucketHead[startSafe] = 0;
        nextNode[0] = -1;
        grid[0][0] = -grid[0][0] - 2; 
        int currentBucket = maxSafeValue;
        while (currentBucket >= 0)
        {
            if (bucketHead[currentBucket] == -1)
            {
                currentBucket--;
                continue;
            }
            int id = bucketHead[currentBucket];
            bucketHead[currentBucket] = nextNode[id];
            int r = id / n;
            int c = id % n;
            if (r == n - 1 && c == n - 1)
            {
                return currentBucket;
            }
            for (int k = 0; k < 4; k++)
            {
                int nr = r + dr[k];
                int nc = c + dc[k];
                if (nr >= 0 && nr < n && nc >= 0 && nc < n)
                {
                    int val = grid[nr][nc];
                    if (val >= 0)
                    {
                        int nextSafe = val < currentBucket ? val : currentBucket;
                        grid[nr][nc] = -val - 2;
                        int nid = nr * n + nc;
                        nextNode[nid] = bucketHead[nextSafe];
                        bucketHead[nextSafe] = nid;
                    }
                }
            }
        }
        return 0;
    }
}
