public class Solution {
    public long CountInterestingSubarrays(IList<int> nums, int modulo, int k) {
        var map = new Dictionary<int, long> { [0] = 1 };
        long res = 0;
        int count = 0;

        foreach (var num in nums) {
            if (num % modulo == k) count++;
            int curr = count % modulo;
            int need = (curr - k + modulo) % modulo;
            if (map.ContainsKey(need)) res += map[need];
            if (!map.ContainsKey(curr)) map[curr] = 0;
            map[curr]++;
        }
        return res;
    }
}
