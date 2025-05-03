public class Solution {
    public bool IsHappy(int n) {
        HashSet<int> seen = new HashSet<int>();

        while (n != 1) {
            if (seen.Contains(n)) return false;
            seen.Add(n);
            n = GetSumOfSquares(n);
        }

        return true;
    }

    private int GetSumOfSquares(int num) {
        int sum = 0;
        while (num > 0) {
            int digit = num % 10;
            sum += digit * digit;
            num /= 10;
        }
        return sum;
    }
}
