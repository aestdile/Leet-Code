public class Solution {
    public int[] AvoidFlood(int[] rains) {
        int n = rains.Length;
        int[] ans = new int[n];
        var fullLakes = new Dictionary<int, int>();   
        var dryDays = new SortedSet<int>();           
        for (int i = 0; i < n; i++) {
            int lake = rains[i];
            if (lake == 0) {
                dryDays.Add(i);
                ans[i] = 1; 
            } else {
                ans[i] = -1;
                if (fullLakes.ContainsKey(lake)) {
                    int lastRainDay = fullLakes[lake];
                    int? dryDay = null;
                    foreach (int d in dryDays) {
                        if (d > lastRainDay) {
                            dryDay = d;
                            break;
                        }
                    }
                    if (dryDay == null) {
                        return new int[0];
                    }
                    ans[dryDay.Value] = lake;
                    dryDays.Remove(dryDay.Value);
                }
                
                fullLakes[lake] = i;
            }
        }
        return ans;
    }
}
