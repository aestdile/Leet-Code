public class Solution {
    public bool RotateString(string s, string goal) {
        if (s.Length != goal.Length)    return false;
        if (s.Equals(goal)) return true;
        var length = s.Length;
        for(int i = 0; i < length-1; i++)
        {
            s = s.Substring(1,length-1) + s.Substring(0,1);
            if(s.Equals(goal))
                return true;
        }
        return false;
    }
}
