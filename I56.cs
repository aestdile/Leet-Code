public class Solution {
    public string AddSpaces(string s, int[] spaces) {
        StringBuilder result = new StringBuilder();
        int spaceIndex = 0, n = s.Length;

        for (int i = 0; i < n; i++) {
            if (spaceIndex < spaces.Length && i == spaces[spaceIndex]) {
                result.Append(' ');
                spaceIndex++;
            }
            result.Append(s[i]);
        }
        return result.ToString();
    }
}
