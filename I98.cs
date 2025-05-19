public class Solution {
    public string TriangleType(int[] n) {
        Array.Sort(n);
        if (n[0] + n[1] <= n[2]) return "none";
        if (n[0] == n[2]) return "equilateral";
        if (n[0] == n[1] || n[1] == n[2]) return "isosceles";
        return "scalene";
    }
}
