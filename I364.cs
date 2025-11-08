public class Solution {
    public int MinimumOneBitOperations(int n) {
        var sign = 1;
        var mask = 1 << 29;
        var ops = 0;

        for (int i = 0; i < 32; i++){
            if ((n & mask) == mask){
                ops += ((mask << 1) - 1) * sign;
                sign *= -1;
            }
            mask >>= 1;
        }
        return ops;
    }
}
