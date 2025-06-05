public class Solution {
    public string SmallestEquivalentString(string s1, string s2, string baseStr) {
        int[] parent = new int[26];
        for (int i = 0; i < 26; i++) parent[i] = i;
        
        for (int i = 0; i < s1.Length; i++) {
            Union(parent, s1[i] - 'a', s2[i] - 'a');
        }
        
        StringBuilder sb = new StringBuilder();
        foreach (char c in baseStr) {
            sb.Append((char)('a' + Find(parent, c - 'a')));
        }
        return sb.ToString();
    }
    
    private int Find(int[] parent, int x) {
        return parent[x] == x ? x : parent[x] = Find(parent, parent[x]);
    }
    
    private void Union(int[] parent, int x, int y) {
        int px = Find(parent, x), py = Find(parent, y);
        if (px != py) parent[px < py ? py : px] = px < py ? px : py;
    }
}
