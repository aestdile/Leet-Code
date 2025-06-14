public class Solution {
    public int MinMaxDifference(int num) 
    {
        var (s, hi) = (num.ToString(), 0);
        for(var len1 = s.Length-1; hi < len1 && s[hi]=='9'; hi++) { } 
        return int.Parse(s.Replace(s[hi], '9')) - int.Parse(s.Replace(s[0], '0'));
    }
}
