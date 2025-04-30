public class Solution {
    public int FindNumbers(int[] nums) {
        int count = 0;
        foreach (int num in nums) {
            int digitCount = num.ToString().Length;
            if (digitCount % 2 == 0) {
                count++;
            }
        }
        return count;
    }
}
