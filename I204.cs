public class Solution {
    public string MakeFancyString(string s) {
        if(s.Length<3) return s;
        Span<char> ca=stackalloc char[s.Length];
        int di=2, si=2;
        for(char p1=ca[0]=s[0], p0=ca[1]=s[1], c; si<ca.Length;) {
            if((c=s[si++])!=p1 || p1!=p0) {
                p1=p0; p0=ca[di++]=c;
            }
        }
        return di==si ? s : ca[..di].ToString();
    }
}
