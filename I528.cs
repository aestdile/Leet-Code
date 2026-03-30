public class Solution {
    public bool CheckStrings(string s1, string s2) =>
    new[] { 0, 1 }.All(p =>
        s1.Where((_, i) => i % 2 == p).Order().SequenceEqual(
        s2.Where((_, i) => i % 2 == p).Order()));
}
