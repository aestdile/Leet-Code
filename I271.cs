public class Solution {
    public bool CheckPerfectNumber(int num) {
        if (num <= 1)
            return false;

        var sqrt = (int)Math.Sqrt(num);
        var sum = 0;

        for (var i = 1; i <= sqrt; i++)
        {
            if (num % i == 0)
            {
                sum += i + num / i;
            }
        }

        return sum - num == num;
    }
}
