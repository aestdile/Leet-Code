public class Solution {
    public int AreaOfMaxDiagonal(int[][] dimensions) {
        return dimensions.Max(d => (Diagonal: d[0] * d[0] + d[1] * d[1], Area: d[0] * d[1])).Area;
    }
}