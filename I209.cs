public class Solution
{
    public int MaximumGain(string s, int x, int y)
    {
        char a = 'a', b = 'b';
        if (x < y)
        {
            (x, y) = (y, x);
            (a, b) = (b, a);
        }

        int sum = 0, ab = 0, ba = 0;
        int len = s.Length;

        for (int i = 0; i < len; i++)
        {
            char temp = s[i];
            if (temp == a)
                ab++;
            else if (temp == b)
            {
                if (ab > 0)
                {
                    sum += x;
                    ab--;
                }
                else
                    ba++;
            }
            else
            {
                sum += Math.Min(ab, ba) * y;
                ab = 0;
                ba = 0;
            }
        }

        sum += Math.Min(ab, ba) * y;
        return sum;
    }
}
