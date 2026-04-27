public class Solution {
    public bool HasValidPath(int[][] grid) {
        int rows = grid.Length, cols = grid[0].Length;

        var streets = new List<PathInfo>
        {
            null,
            new PathInfo(new[] { new[] {0, -1}, new[] {0, 1} }),
            new PathInfo(new[] { new[] {-1, 0}, new[] {1, 0} }),
            new PathInfo(new[] { new[] {0, -1}, new[] {1, 0} }),
            new PathInfo(new[] { new[] {0, 1}, new[] {1, 0} }),
            new PathInfo(new[] { new[] {0, -1}, new[] {-1, 0} }),
            new PathInfo(new[] { new[] {0, 1}, new[] {-1, 0} })
        };

        var visited = new HashSet<(int, int)>();

        bool IsValid(int r, int c) =>
            r >= 0 && r < rows && c >= 0 && c < cols;

        bool Dfs(int r, int c)
        {
            if (!IsValid(r, c) || visited.Contains((r, c)))
                return false;

            if (r == rows - 1 && c == cols - 1)
                return true;

            visited.Add((r, c));

            foreach (var dir in streets[grid[r][c]].Directions)
            {
                int nr = r + dir[0];
                int nc = c + dir[1];

                if (!IsValid(nr, nc))
                    continue;

                foreach (var back in streets[grid[nr][nc]].Directions)
                {
                    if (nr + back[0] == r && nc + back[1] == c)
                    {
                        if (Dfs(nr, nc))
                            return true;
                    }
                }
            }

            return false;
        }

        return Dfs(0, 0);
    }

    private class PathInfo
    {
        public int[][] Directions { get; }
        public PathInfo(int[][] directions) => Directions = directions;
    }
}
