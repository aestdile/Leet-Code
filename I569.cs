public class Solution {
    public int MinimumEffort(int[][] tasks) {
        int[] diff = new int[tasks.Length];
        for(int i=0; i<tasks.Length; i++) {
            diff[i] = tasks[i][1] - tasks[i][0];
        }
        Array.Sort(diff, tasks, Comparer<int>.Create((x,y) => y.CompareTo(x)));
        int ans = tasks[0][1], rem = tasks[0][1]-tasks[0][0];
        for(int i=1; i<tasks.Length; i++) {
            if(tasks[i][1] > rem) {
                ans += tasks[i][1] - rem;
                rem = diff[i];
            } else {
                rem -= tasks[i][0];
            }
        }
        return ans;
    }
}
