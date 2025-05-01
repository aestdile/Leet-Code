public class Solution {
    public int ClimbStairs(int n) {
        int a = 1, b = 1;
        for (int i = 2; i <= n; i++)
            (a, b) = (b, a + b);
        return b;
    }
}
