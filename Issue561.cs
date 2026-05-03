public class Solution 
{
    public bool RotateString(string s, string goal) 
    {
        if (s.Length != goal.Length) {
            return false;
        }
        if (s == goal) {
            return true;
        }
        for (int i = 0; i < s.Length; i++) {
            s = s.Substring(1) + s[0];
            if (s == goal) {
                return true;
            }
        }
        return false;
    }
}
