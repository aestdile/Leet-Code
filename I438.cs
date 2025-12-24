public class Solution {
    public int MinimumBoxes(int[] apple, int[] capacity) => capacity.
        OrderByDescending(m => m).
        Aggregate((0, apple.Sum()), (acum, curr) =>
        (
            acum.Item1 + (acum.Item2 > 0 ? 1 : 0),
            acum.Item2 - curr
        ), 
        m => m.Item1);
}
