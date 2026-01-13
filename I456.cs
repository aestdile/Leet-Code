public class Solution {
    const double precision = 1e-5;

    class Square {
        public Square(double start, double side) {
            Start = start;
            Side = side;

            End = start + side;
            Sqr = side * side;
        }

        public double Start { get; }
        public double Side { get; }
        public double End { get; }
        public double Sqr { get; }
    }
    
    public double SeparateSquares(int[][] squares) {
        int n = squares.Length;

        Array.Sort(squares, (a, b) => a[1].CompareTo(b[1]));

        Square[] ss = new Square[n];
        double total = 0;
        double end = 0;
        
        for (int i = 0; i < n; i++) {
            ss[i] = new(squares[i][1], squares[i][2]);
            if (ss[i].End > end) end = ss[i].End;
            total += ss[i].Sqr;
        }

        double half = total / 2;
        double start = ss[0].Start;
        
        while (Math.Abs(end - start) > precision) {
            double middle = (start + end) / 2;
            double sum = 0;
            
            for (int i = 0; i < n; i++) {
                Square s = ss[i];

                if (s.Start >= middle) break;
                
                if (s.End > middle) {
                    sum += s.Side * (middle - s.Start);
                } else {
                    sum += s.Sqr;
                }
            }

            if (sum >= half) {
                end = middle;
            } else {
                start = middle;
            }
        }
        
        return start;
    }
}
