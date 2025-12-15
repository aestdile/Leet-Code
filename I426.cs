public class Solution{
    public long GetDescentPeriods(int[] prices){
        long result = 1; 
        long count = 1;  
        for (int i = 1; i < prices.Length; i++){
            if (prices[i - 1] - prices[i] == 1){
                count++;
            } else{
                count = 1;
            }
            result += count;
        }
        return result;
    }
}
