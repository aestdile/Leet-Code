public class Solution {
    public int CountCoveredBuildings(int n, int[][] buildings) {
        Dictionary<int, (int minY, int maxY)> rowInfo = new Dictionary<int, (int, int)>();
        Dictionary<int, (int minX, int maxX)> colInfo = new Dictionary<int, (int, int)>();

        foreach (var b in buildings) {
            int x = b[0];
            int y = b[1];

            if (!rowInfo.ContainsKey(x))
                rowInfo[x] = (y, y);
            else
                rowInfo[x] = (Math.Min(rowInfo[x].minY, y),
                              Math.Max(rowInfo[x].maxY, y));

            if (!colInfo.ContainsKey(y))
                colInfo[y] = (x, x);
            else
                colInfo[y] = (Math.Min(colInfo[y].minX, x),
                              Math.Max(colInfo[y].maxX, x));
        }

        int count = 0;

        foreach (var b in buildings) {
            int x = b[0];
            int y = b[1];

            var row = rowInfo[x];
            var col = colInfo[y];

            bool hasLeft  = row.minY < y;
            bool hasRight = row.maxY > y;
            bool hasAbove = col.minX < x;
            bool hasBelow = col.maxX > x;

            if (hasLeft && hasRight && hasAbove && hasBelow)
                count++;
        }

        return count;
    }
}