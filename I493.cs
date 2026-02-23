public class Solution {
    public bool HasAllCodes(string s, int k) {
        
        HashSet<string> seen = [];
        
        for (int i = 0; i <= s.Length - k; i++) {
            string sub = s[i..(i+k)];
            seen.Add(sub);
        }
        
        return seen.Count == (1 << k);
    }
}
