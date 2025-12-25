public class Solution {
    public long MaximumHappinessSum(int[] happiness, int k) {
        Array.Sort(happiness, (a, b) => b - a); // Sort in descending order
        
        int rounds = 0;
        long totalHappySum = 0;
        
        for (int i = 0; i < k && i < happiness.Length; i++) {
            int selected = happiness[i] - rounds;
            if (selected > 0) {
                totalHappySum += selected;
                rounds++;
            }
        }
        
        return totalHappySum;
    }
}
