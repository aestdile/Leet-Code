public class Solution {
    private static int[] _primes = [2, 3, 5, 7, 11, 13, 17, 19];
    public int CountPrimeSetBits(int left, int right) => Enumerable.Range(left, right - left + 1).
        Select(m => Convert.ToString(m, 2)).
        Select(m => m.ToCharArray().Count(m => m == '1')).
        Count(m => _primes.Contains(m));
}
