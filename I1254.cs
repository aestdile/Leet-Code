public class Solution {
    public int ClosedIsland(int[][] grid) {
        // BFS:
        int m = grid.Length, n = grid[0].Length, cLand = 0, cnt = 2;
        if(m < 3 || n < 3) // not enough space to keep a closed island
            return 0;
        int[] dirs = [0, 1, 0, -1, 0];
        for(int i = 1; i < m-1; i++)
        {
            for(int j = 1; j < n-1; j++)
            {
                if(grid[i][j] == 0)
                {
                    bool isValid = true;
                    Queue<(int, int)> que = new();
                    que.Enqueue((i, j));
                    while(que.Count > 0)
                    {
                        (int x, int y) = que.Dequeue();
                        if(grid[x][y] != 0)
                            continue;

                        grid[x][y] = cnt;
                        for(int d = 0; d < 4; d++)
                        {
                            int newX = x + dirs[d], newY = y + dirs[d+1];
                            if(newX < 0|| newY < 0 || newX >= m || newY >= n)
                            {
                                isValid = false;
                                continue;
                            }

                            int nextV = grid[newX][newY];
                            if(nextV == 0)
                                que.Enqueue((newX, newY));
                            else if(nextV != 1 && nextV != cnt)
                                isValid = false;
                        }
                    }

                    if(isValid)
                        cLand++;

                    cnt++;
                }
            }
        }

        return cLand;
    }
}
