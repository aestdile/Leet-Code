public class Solution {
    public int TotalMoney(int n) {
        int weeks = n / 7;
        int days = n % 7;
        return (days + 1) * days / 2 + weeks * days + weeks * 28 + (weeks - 1) * weeks * 7 / 2;
    }
}
