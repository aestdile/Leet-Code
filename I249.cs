public class Solution {
    public string LargestGoodInteger(string num) {
        var res = '\0';
        for (var i = 2; i < num.Length; ++i)
        {
            if (num[i] == num[i - 1] && num[i] == num[i - 2] && res < num[i])
            {
                res = num[i];
            }
        }
        return res == '\0' ? "" : new string(res, 3);
    }
}
