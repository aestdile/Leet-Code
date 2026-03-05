public class Solution {
    public int MinOperations(string s) => s.
        Select((m, i) => (m, i)).
        Aggregate((0, 0), (acum, curr) =>
        (
            acum.Item1 + (char.GetNumericValue(curr.m) != curr.i % 2 ? 1 : 0),
            acum.Item2 + (char.GetNumericValue(curr.m) == curr.i % 2 ? 1 : 0)
        ), m => Math.Min(m.Item1, m.Item2));
}
