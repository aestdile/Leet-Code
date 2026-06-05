public class Solution
{
    private long[,,,,,] dp = new long[16, 2, 2, 10, 3, 16];

    private long Fun(int pos, int leadingZeros, int tight, int prev, int state, int total, List<int> digits)
    {
        if (pos >= digits.Count) return total;

        long res = dp[pos, leadingZeros, tight, prev, state, total];
        if (res != -1) return res;

        int limit = tight == 1 ? digits[pos] : 9;
        long ans = 0;

        for (int i = 0; i <= limit; i++)
        {
            int newTight = (tight == 1 && i == limit) ? 1 : 0;

            if (leadingZeros == 1 && i == 0)
            {
                ans += Fun(pos + 1, 1, newTight, prev, state, total, digits);
            }
            else if (leadingZeros == 1)
            {
                ans += Fun(pos + 1, 0, newTight, i, 0, 0, digits);
            }
            else
            {
                if (i < prev && state == 2)
                    ans += Fun(pos + 1, 0, newTight, i, 1, total + 1, digits);
                else if (i < prev)
                    ans += Fun(pos + 1, 0, newTight, i, 1, total, digits);
                else if (i > prev && state == 1)
                    ans += Fun(pos + 1, 0, newTight, i, 2, total + 1, digits);
                else if (i > prev)
                    ans += Fun(pos + 1, 0, newTight, i, 2, total, digits);
                else
                    ans += Fun(pos + 1, 0, newTight, i, 0, total, digits);
            }
        }

        return dp[pos, leadingZeros, tight, prev, state, total] = ans;
    }

    private void ResetDP()
    {
        for (int a = 0; a < 16; a++)
            for (int b = 0; b < 2; b++)
                for (int c = 0; c < 2; c++)
                    for (int d = 0; d < 10; d++)
                        for (int e = 0; e < 3; e++)
                            for (int f = 0; f < 16; f++)
                                dp[a, b, c, d, e, f] = -1;
    }

    public long TotalWaviness(long num1, long num2)
    {
        ResetDP();

        num1--;

        List<int> digits1 = new List<int>(new int[16]);
        List<int> digits2 = new List<int>(new int[16]);

        int i = 15;

        while (num1 > 0)
        {
            digits1[i] = (int)(num1 % 10);
            num1 /= 10;
            i--;
        }

        i = 15;

        while (num2 > 0)
        {
            digits2[i] = (int)(num2 % 10);
            num2 /= 10;
            i--;
        }

        long t1 = Fun(0, 1, 1, 0, 0, 0, digits1);

        ResetDP();

        long t2 = Fun(0, 1, 1, 0, 0, 0, digits2);

        return t2 - t1;
    }
}
