public class Solution {
    public string ConvertToBase7(int num) {
        if(num == 0)
            return "0";
        
        int r = 0, d = 0;
        var res = "";
        var sign = num >= 0 ? 1:-1;
        num = num*sign;
        while(num != 0){
            d = num/7;
            r = num%7;
            num = d;
            res = $"{r}{res}";
        }
        return sign > 0 ? res : $"-{res}";        
    }
}
