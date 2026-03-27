public class Solution {
    public bool AreSimilar(int[][] mat, int k) => mat.All(row => Enumerable.Range(0, row.Length).All(i => row[(i + k) % row.Length] == row[i]));
}
