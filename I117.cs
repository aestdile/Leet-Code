public class Solution {
    public string ClearStars(string s) {
        var stacks = new Stack<int>[26]; 
        for (int i = 0; i < 26; i++) {
            stacks[i] = new Stack<int>();
        }
        var result = new char[s.Length];
        for (int i = 0; i < s.Length; i++) {
            if (s[i] == '*') {
                for (int j = 0; j < 26; j++) {
                    if (stacks[j].Count > 0) {
                        int pos = stacks[j].Pop();
                        result[pos] = '\0'; 
                        break;
                    }
                }
            } else {
                int idx = s[i] - 'a';
                stacks[idx].Push(i);
                result[i] = s[i];
            }
        }
        var sb = new System.Text.StringBuilder();
        for (int i = 0; i < result.Length; i++) {
            if (result[i] != '\0' && result[i] != '*') {
                sb.Append(result[i]);
            }
        }
        return sb.ToString();
    }
}
