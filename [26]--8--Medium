public class Solution {
    public int MyAtoi(string s) {
        s = s.Trim(); 
        if (s.Length == 0) return 0;

        int sign = 1, i = 0, result = 0;
        if (s[i] == '-' || s[i] == '+') {
            sign = s[i] == '-' ? -1 : 1;
            i++;
        }

        while (i < s.Length && char.IsDigit(s[i])) {
            int digit = s[i] - '0';

            if (result > (int.MaxValue - digit) / 10) 
                return sign == 1 ? int.MaxValue : int.MinValue;

            result = result * 10 + digit;
            i++;
        }
        return result * sign;
    }
}
