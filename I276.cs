public class Solution {
    public int[] GetNoZeroIntegers(int n) {
        int[] res = new int[] {0, 0};

        while (IsZero(res[0]) || IsZero(res[1]))
        {
            res[0]++;
            res[1] = n - res[0];
        }

        return res;
    }

    bool IsZero(int x)
    {
        return x == 0 || x.ToString().Contains("0");
    }
}
