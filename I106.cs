public class Solution {
    public int DifferenceOfSums(int n, int m) {
        int totalSum = n * (n + 1) / 2;
        int count = n / m;
        int divisibleSum = m * count * (count + 1) / 2;
        return totalSum - 2 * divisibleSum;
    }
}
