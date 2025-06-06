public class Solution {
    public string RobotWithString(string s) {
        int n = s.Length;
        char[] minRight = new char[n];
        minRight[n-1] = s[n-1];
        for (int i = n-2; i >= 0; i--) {
            minRight[i] = (char)Math.Min(s[i], minRight[i+1]);
        }
        StringBuilder result = new StringBuilder();
        Stack<char> t = new Stack<char>();
        for (int i = 0; i < n; i++) {
            t.Push(s[i]);
            while (t.Count > 0 && (i == n-1 || t.Peek() <= minRight[i+1])) {
                result.Append(t.Pop());
            }
        }
        return result.ToString();
    }
}
