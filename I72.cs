public class Solution {
    public int CountLargestGroup(int n) {
        var map = new Dictionary<int, int>();
        for (int i = 1; i <= n; i++) {
            int sum = 0, num = i;
            while (num > 0) {
                sum += num % 10;
                num /= 10;
            }
            if (!map.ContainsKey(sum)) map[sum] = 0;
            map[sum]++;
        }

        int max = map.Values.Max();
        return map.Values.Count(v => v == max);
    }
}
