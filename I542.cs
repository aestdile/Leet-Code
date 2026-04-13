public class Solution {
    public int GetMinDistance(int[] nums, int target, int start) {
        int minDistance = int.MaxValue;
        
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] == target) {
                int distance = Math.Abs(i - start);
                if (distance < minDistance) {
                    minDistance = distance;
                }
            }
        }
        
        return minDistance;
    }
}
