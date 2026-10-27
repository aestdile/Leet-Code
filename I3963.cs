public class Solution {
    public string[] CreateGrid(int m, int n) => Enumerable.Range(0, m).
        Select(x => new string(x == 0 ? '.' : '#', n - 1) + ".").
        ToArray();
}
