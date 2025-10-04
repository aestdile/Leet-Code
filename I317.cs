public class Solution {
    public int ReverseBits(int n)
    {
        var revers = Convert.ToString(n, 2).PadLeft(32 , '0');
        var str = GetReverseString(revers);
        return Convert.ToInt32(str, 2);
    }

    static string GetReverseString(string revers)
    {
        var res = "";
        for(int i = revers.Length - 1; i >= 0; i--)
            res += revers[i];
        return res;
    }
}
