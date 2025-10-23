public class Solution {
    public bool IsPerfectSquare(int num) {
        long i = 0;
        for (; i * i < num; i++);
        return num == i * i;
    }
}
