using System.Drawing;
public class Solution {
    public int CountTrapezoids(int[][] points) {
            var slopes = new Dictionary<double, List<double>>();
            var mid = new Dictionary<Point, List<double>>();

            for (var i = 0; i < points.Length; i++)
            {
                var x1 = points[i][0];
                var y1 = points[i][1];
                for (var j = 0; j < i; j++)
                {
                    var x2 = points[j][0];
                    var y2 = points[j][1];

                    var dx = x2 - x1;
                    var dy = y2 - y1;

                    var a = dx == 0 ? double.MaxValue : (double)dy / dx;
                    var b = dx == 0 ? x1 : (y1 * dx - x1 * dy) / (double)dx;

                    if (!slopes.ContainsKey(a))
                    {
                        slopes[a] = new List<double>();
                    }
                    slopes[a].Add(b);

                    var pt = new Point(x1 + x2, y1 + y2);
                    if (!mid.ContainsKey(pt))
                    {
                        mid[pt] = new List<double>();
                    }
                    mid[pt].Add(a);
                }
            }

            var result = 0;
            var slopeDic = new Dictionary<double, int>();
            foreach (var s in slopes)
            {
                if (s.Value.Count < 2)
                    continue;
                slopeDic.Clear();

                foreach (var b in s.Value)
                {
                    if (!slopeDic.ContainsKey(b))
                    {
                        slopeDic[b] = 0;
                    }
                    slopeDic[b]++;
                }

                var pre = 0;
                foreach (var val in slopeDic.Values)
                {
                    result += pre * val;
                    pre += val;
                }
            }

            foreach (var m in mid)
            {
                if (m.Value.Count < 2)
                    continue;
                slopeDic.Clear();

                foreach (var a in m.Value)
                {
                    if (!slopeDic.ContainsKey(a))
                    {
                        slopeDic[a] = 0;
                    }
                    slopeDic[a]++;
                }

                var pre = 0;
                foreach (var val in slopeDic.Values)
                {
                    result -= pre * val;
                    pre += val;
                }
            }

            return result;  
    }
}