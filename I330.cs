public class Solution {
    public int FindSmallestInteger(int[] nums, int value) {
        int[] cnt = new int[value];
        int temp;
        for (int i = 0; i < nums.Length; i++) {
            temp = nums[i] % value;
            if (temp < 0) {
                cnt[temp + value]++;
            } else cnt[temp]++;
        }
        int min = cnt[0];
        int index = 0;
        for (int i = 1; i < value; i++) {
            if (cnt[i] < min) {
                min = cnt[i];
                index = i;
            }
        }
        return value * min + index;
    }
}
