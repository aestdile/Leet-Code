public class Solution {
    public int Divide(int dividend, int divisor) {
        if (dividend == int.MinValue && divisor == -1) return int.MaxValue;
        bool sign = (dividend < 0) ^ (divisor < 0);
        long a = Math.Abs((long)dividend), b = Math.Abs((long)divisor), res = 0;
        while (a >= b) {
            long temp = b, multiple = 1;
            while (a >= (temp << 1)) {
                temp <<= 1;
                multiple <<= 1;
            }
            a -= temp;
            res += multiple;
        }
        return sign ? (int)-res : (int)res;
    }
}



