public class Solution {
    Dictionary<string, bool> memo = new();

    public bool IsScramble(string s1, string s2) {
        if (s1 == s2) return true;
        if (s1.Length != s2.Length) return false;

        string key = s1 + "#" + s2;
        if (memo.ContainsKey(key)) return memo[key];

        char[] a = s1.ToCharArray(), b = s2.ToCharArray();
        Array.Sort(a); Array.Sort(b);
        if (new string(a) != new string(b)) return memo[key] = false;

        for (int i = 1; i < s1.Length; i++) {
            if ((IsScramble(s1[..i], s2[..i]) && IsScramble(s1[i..], s2[i..])) ||
                (IsScramble(s1[..i], s2[^i..]) && IsScramble(s1[i..], s2[..^i])))
                return memo[key] = true;
        }
        return memo[key] = false;
    }
}
