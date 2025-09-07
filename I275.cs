public class Solution {
    public bool IsPalindrome(string s) {
        s = s.ToLower();
        s = new string(s.Where(c => char.IsLetterOrDigit(c)).ToArray());
        if (s.Length < 1) {
            return true;
        }
        return Rec(0, s);
    }

    private static bool Rec(int i, string s) {
        if (i >= s.Length / 2) {
            return true;
        }
        if (s[i] != s[s.Length - i - 1]) {
            return false;
        }
        return Rec(i + 1, s);
    }
}
