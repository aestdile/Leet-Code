public class Solution {
    public bool ThreeConsecutiveOdds(int[] arr) {
        int count = 0;
        foreach (int num in arr) {
            if (num % 2 == 1) {
                count++;
                if (count == 3) return true;
            } else {
                count = 0; 
            }
        }
        return false; 
    }
}
