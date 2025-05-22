public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        var res = new List<IList<int>>();
        void Dfs(int i, int t, List<int> path) {
            if (t == 0) {
                res.Add(new List<int>(path));
                return;
            }
            if (i >= candidates.Length || t < 0) return;
            path.Add(candidates[i]);
            Dfs(i, t - candidates[i], path);
            path.RemoveAt(path.Count - 1);
            Dfs(i + 1, t, path);
        }
        Dfs(0, target, new List<int>());
        return res;
    }
}
