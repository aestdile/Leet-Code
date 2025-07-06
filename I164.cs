public class Solution {
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        Array.Sort(candidates);
        var dp = new List<IList<int>>[target + 1];

        for (int i = 0; i <= target; i++) {
            dp[i] = new List<IList<int>>();
        }

        dp[0].Add(new List<int>()); 

        foreach (var candidate in candidates) {
            for (int i = target; i >= candidate; i--) {
                foreach (var comb in dp[i - candidate]) {
                    var newComb = new List<int>(comb) { candidate };
                    if (!dp[i].Any(x => x.SequenceEqual(newComb))) {
                        dp[i].Add(newComb);
                    }
                }
            }
        }

        return dp[target];
    }
}
