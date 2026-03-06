public class Solution {
    public bool CheckOnesSegment(string s) {
        int index = 0;
        while (index < s.Length && s[index] == '1') index++;
        while (index < s.Length && s[index] == '0') index++;
        if (index < s.Length) return false;
        else return true;
    }
}
