public class Solution {
    public char KthCharacter(long k, int[] operations) {
            var cnt = 0L;
            var leftBit = BitOperations.Log2((ulong)k);

            for (var i = leftBit; i >= 0; i--)
            {
                if (k > (1L << i))
                {
                    k -= (1L << i);
                    cnt += operations[i];
                }
            }

            return (char)('a' + cnt % 26);
    }
}
