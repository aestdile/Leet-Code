public class Solution {
    public int StrStr(string haystack, string needle){
        for (var i = 0; i < haystack.Length - needle.Length + 1; i++)
        {
            if (haystack.Substring(i, needle.Length) == needle) return i;
        }
        return -1;
    }
}
