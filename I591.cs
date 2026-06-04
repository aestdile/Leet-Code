public class Solution {
    public int TotalWaviness(int num1, int num2) {
        int res = 0;
        num1 = Math.Max(num1, 100);
        if(num2 < num1)
            return res;

        long[] freq = new long[num2+1];

        for(int i = 100; i <= num2; i++)
        {
            freq[i] = freq[i/10];
            int cur = i;
            int p1 = cur%10;
            cur /= 10;
            int p2 = cur %10;
            int p3 = (cur%100)/10;
            
            if(p2 > p1 && p2 > p3 || p2 < p1 && p2 < p3)
                freq[i]++;
        }

        for(int i = 100; i <= num2; i++)
        {
            freq[i] += freq[i-1];
        }

        res = (int)(freq[num2] - freq[num1-1]);
        return res;
    }
}
