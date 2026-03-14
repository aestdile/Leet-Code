public class Solution {
    public string GetHappyString(int n, int k) {
        List<string> happyStrings = new List<string>();
        Backtrack(n, "", happyStrings);

        return k <= happyStrings.Count ? happyStrings[k - 1] : "";
    }
    private void Backtrack(int n, string current, List<string> happyStrings) {
        if (current.Length == n) {
            happyStrings.Add(current);
            return;
        }

        foreach (char ch in new char[] { 'a', 'b', 'c' }) {
            if (current.Length == 0 || current[current.Length - 1] != ch) {
                Backtrack(n, current + ch, happyStrings);
            }
        }
    }
}
