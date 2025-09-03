public class Solution {
    public int NumberOfPairs(int[][] points) {
        Array.Sort(points, (x, y) => {
            if (x[0] != y[0]) return x[0] - y[0];
            
            return y[1] - x[1];
        });
        
        var result = 0;
        for (var l = 0; l < points.Length; l++)
        {
            var y = int.MinValue;
            for (var r = l + 1; r < points.Length; r++)
            {
                if (points[l][1] >= points[r][1] && y < points[r][1])
                {
                    result += 1;
                    y = points[r][1];
                }
            }
        }
        return result;
    }
}
