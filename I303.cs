public class Solution {
    public string FractionToDecimal(int numerator, int denominator) {
        StringBuilder sb = new();
        
        if((numerator > 0 && denominator < 0) || (numerator < 0 && denominator > 0)){
            sb.Append($"-");
        }

        long num = numerator < 0 ? -(long)numerator : numerator;
        long den = denominator < 0 ? -(long)denominator : denominator;
        sb.Append($"{num/den}");
        num = num%den;
        
        if(num == 0) return sb.ToString();

        sb.Append(".");
        Dictionary<long, int> numeratorIndexMap = new();
        num = num*10;
        bool repeating = false;
        
        while(num != 0){
            if(numeratorIndexMap.ContainsKey(num)){
                sb.Insert(numeratorIndexMap[num], "(");
                repeating = true;
                break;
            }

            //Console.WriteLine($"num={num}, denominator={denominator}, sb={sb}");
            numeratorIndexMap.Add(num, sb.Length);
            sb.Append($"{num/den}");
            num = num%den;
            num = num*10;
        }

        if(repeating) sb.Append(")");

        return sb.ToString();
    }
}