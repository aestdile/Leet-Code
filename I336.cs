public class Solution {
    public int MaxFrequency(int[] nums, int k, int numOperations) {
        Array.Sort(nums);

        int ans = 0;
        Dictionary<int, int> numCount = new Dictionary<int, int>();
        SortedSet<int> modes = new SortedSet<int>();

        Action<int> addMode = (value) => {
            modes.Add(value);
            if (value - k >= nums[0]) {
                modes.Add(value - k);
            }
            if (value + k <= nums[nums.Length - 1]) {
                modes.Add(value + k);
            }
        };

        int lastNumIndex = 0;
        for (int i = 0; i < nums.Length; ++i) {
            if (nums[i] != nums[lastNumIndex]) {
                numCount[nums[lastNumIndex]] = i - lastNumIndex;
                ans = Math.Max(ans, i - lastNumIndex);
                addMode(nums[lastNumIndex]);
                lastNumIndex = i;
            }
        }

        numCount[nums[lastNumIndex]] = nums.Length - lastNumIndex;
        ans = Math.Max(ans, nums.Length - lastNumIndex);
        addMode(nums[lastNumIndex]);

        Func<int, int> leftBound = (value) => {
            int left = 0, right = nums.Length - 1;
            while (left < right) {
                int mid = (left + right) / 2;
                if (nums[mid] < value) {
                    left = mid + 1;
                } else {
                    right = mid;
                }
            }
            return left;
        };

        Func<int, int> rightBound = (value) => {
            int left = 0, right = nums.Length - 1;
            while (left < right) {
                int mid = (left + right + 1) / 2;
                if (nums[mid] > value) {
                    right = mid - 1;
                } else {
                    left = mid;
                }
            }
            return left;
        };

        foreach (int mode in modes) {
            int l = leftBound(mode - k);
            int r = rightBound(mode + k);
            int tempAns;
            if (numCount.ContainsKey(mode)) {
                tempAns = Math.Min(r - l + 1, numCount[mode] + numOperations);
            } else {
                tempAns = Math.Min(r - l + 1, numOperations);
            }
            ans = Math.Max(ans, tempAns);
        }

        return ans;
    }
}
