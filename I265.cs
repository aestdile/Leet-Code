public class Solution {
    public double MaxAverageRatio(int[][] classes, int extraStudents) {
        double Gain(double p, double t) {
            return (p + 1) / (t + 1) - p / t;
        }
        var pq = new PriorityQueue<(double g, double p, double t), double>();
        foreach (var c in classes) {
            double p = c[0], t = c[1];
            pq.Enqueue((Gain(p, t), p, t), -Gain(p, t));
        }
        while (extraStudents-- > 0) {
            var top = pq.Dequeue();
            double p = top.p + 1, t = top.t + 1;
            pq.Enqueue((Gain(p, t), p, t), -Gain(p, t));
        }
        double sum = 0;
        while (pq.Count > 0) {
            var c = pq.Dequeue();
            sum += c.p / c.t;
        }
        return sum / classes.Length;
    }
}
