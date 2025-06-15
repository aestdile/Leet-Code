public class Solution {
    public int MaxDiff(int num) {
        string s = num.ToString();
        string a = s;
        foreach (char c in s) {
            if (c != '9') {
                a = s.Replace(c, '9');
                break;
            }
        }
        string b = s;
        if (s[0] != '1') {
            b = s.Replace(s[0], '1');
        } else {
            for (int i = 1; i < s.Length; i++) {
                if (s[i] != '0' && s[i] != '1') {
                    b = s.Replace(s[i], '0');
                    break;
                }
            }
        }
        return int.Parse(a) - int.Parse(b);
    }
}
