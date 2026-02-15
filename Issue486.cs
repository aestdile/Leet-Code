public class Solution {
    public string AddBinary(string a, string b) {
        var sum = new List<int>();
        for (int i = a.Length - 1, j = b.Length - 1, carry = 0; i >= 0 || j >= 0 || carry > 0;)
        {
            var firstDigit = i >= 0 ? a[i--] - '0' : 0;
            var secondDigit = j >= 0 ? b[j--] - '0' : 0;
            var sumDigit = firstDigit + secondDigit + carry;
            carry = sumDigit / 2;
            sum.Add(sumDigit % 2);
        }
        sum.Reverse();
        return String.Concat(sum);
    }
}
