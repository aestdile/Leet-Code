func romanToInt(s string) int {
    m := map[string]int{
        "I": 1,
        "V": 5,
        "X": 10,
        "L": 50,
        "C": 100,
        "D": 500,
        "M": 1000,
    }
    
    var r string
    var c int
    
    for i:=0; i<len(s); i++ {
        l := string(s[i])
        if m[r]<m[l] && i>0 {
            c-=m[r]+m[r]
        }
        r=l
        c+=m[l]
    }
    return c
}

/*
public class Solution {
    public int RomanToInt(string s) {
        Dictionary<string, int> m = new Dictionary<string, int>
        {
            { "I", 1 },
            { "V", 5 },
            { "X", 10 },
            { "L", 50 },
            { "C", 100 },
            { "D", 500 },
            { "M", 1000 }
        };
        
        string r = "";
        string l = "";
        int c = 0;
        
        for (int i = 0; i < s.Length; i++)
        {
            r = s[i].ToString();
            
            if (i > 0 && m[r] > m[l])
            {
                c -= m[l];
                c += (m[r] - m[l]);
            }
            else
            {
                c += m[r];
            }
            
            l = r;
        }
        
        return c;  
    }
}
*/
