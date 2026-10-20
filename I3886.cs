public class Solution {
    public int SortableIntegers(int[] nums) {
        int n = nums.Length,
            sum = 0;
        for (int k = 1; k * k <= n; k++) {
            if (n % k == 0) {
                if (IsSortable(nums, k)) 
                    sum += k;

                if (k != n / k && IsSortable(nums, n / k))
                    sum += n / k;
            }
        }
        return sum;
    }

    private bool IsSortable(int[] nums, int k) {
        int i = 0, 
            n = nums.Length, 
            previousMin = int.MaxValue, 
            previousMax = 0;

        while (i < n) {
            int currentMin = nums[i], 
                currentMax = nums[i],
                drops = 0;

            for (int j = i; j < i + k; j++) {
                currentMin = Math.Min(currentMin, nums[j]);
                currentMax = Math.Max(currentMax, nums[j]);

                if (nums[j] > nums[i + (j + 1) % k]) {
                    if (++drops > 1) {
                        return false;
                    }
                }
            }

            if (currentMin < previousMax) 
                return false;

            (previousMin, previousMax) = (currentMin, currentMax);
            i += k;
    
        }
        return true;
    }
}
