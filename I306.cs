public class Solution {
    public double LargestTriangleArea(int[][] input) {
        var max = double.MinValue;
        var points = input.Select(p => new Point(p[0], p[1])).ToList();
        for(int i = 0; i <  points.Count; i++)
        {
            for(int j = 0; j < points.Count; j++)
            {
                for(int k = 0; k < points.Count; k++)
                {                    
                    var a = points[i].GetDistance(points[j]);
                    var b = points[i].GetDistance(points[k]);
                    var c = points[j].GetDistance(points[k]);
                    var area = CalculateArea(a, b, c);
                    if(area > max)
                    {
                        max = area;
                    }  
                }
            }
        }        
        return max;
    }



    private double CalculateArea(double a, double b, double c)
    {
        var p = (a + b + c) / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    private class Point
    {
        public double X;
        public double Y;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double GetDistance(Point v)
        {
            return Math.Sqrt(((this.X - v.X) * (this.X - v.X) + (this.Y - v.Y) * (this.Y - v.Y)));
        }
    }
}