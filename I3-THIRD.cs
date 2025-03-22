public class Solution {
    public int Reverse(int x) {
        int result = 0;
        while (x != 0)
        {
            int lastDigit = x % 10; 
            x /= 10;
            if (result > int.MaxValue / 10 || (result == int.MaxValue / 10 && lastDigit > 7)) 
                return 0;
            if (result < int.MinValue / 10 || (result == int.MinValue / 10 && lastDigit < -8)) 
                return 0;

            result = result * 10 + lastDigit; 
        }
        return result;
    }
}
