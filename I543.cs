public class Solution {
    public long MinimumTotalDistance(IList<int> robot, int[][] factory) {
        robot = robot.OrderBy(x => x).ToList();
        Array.Sort(factory, (a, b) => a[0].CompareTo(b[0]));
        var memo = new Dictionary<(int, int), long>();
        return Dp(robot, factory, 0, 0, memo);
    }
    private long Dp(IList<int> robot, int[][] factory, int rIndex, int fIndex, Dictionary<(int, int), long> memo) {
        if (rIndex == robot.Count) return 0;
        if (fIndex == factory.Length) return long.MaxValue;
        if (memo.ContainsKey((rIndex, fIndex))) return memo[(rIndex, fIndex)];

        long minDist = long.MaxValue;
        minDist = Dp(robot, factory, rIndex, fIndex + 1, memo);
        long currentDist = 0;
        for (int i = 0; i < factory[fIndex][1] && rIndex + i < robot.Count; i++) {
            currentDist += Math.Abs(robot[rIndex + i] - factory[fIndex][0]);
            long nextDist = Dp(robot, factory, rIndex + i + 1, fIndex + 1, memo);
            if (nextDist != long.MaxValue) {
                minDist = Math.Min(minDist, currentDist + nextDist);
            }
        }
        memo[(rIndex, fIndex)] = minDist;
        return minDist;
    }
}
