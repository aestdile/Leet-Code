public class Solution {
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length) {
            return false;
        }

        var symbolFrequency = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++) {
            symbolFrequency.TryAdd(s[i], 0);
            symbolFrequency.TryAdd(t[i], 0);

            symbolFrequency[s[i]]++;
            symbolFrequency[t[i]]--;
        }

        return symbolFrequency.Values.All(frequence => frequence == 0);        
    }
}
