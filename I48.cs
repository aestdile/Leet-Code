public class Solution {
    public string Multiply(string num1, string num2) {
        return ( BigInteger.Parse(num1) * BigInteger.Parse(num2)).ToString();
    }
}
