public class Solution
{
    public int ConcatenatedBinary(int n)
    {
        const int MOD = 1_000_000_007; // module bcz the number's too large 

        long ans = 0;
        int bitLen = 0;

        for (int i = 1; i <= n; i++)
        {
            if ((i & (i - 1)) == 0)
                bitLen++;

            ans = ((ans << bitLen) + i) % MOD; // shifts the current result to the left by a few bits 
        }

        return (int)ans;
    }
}
