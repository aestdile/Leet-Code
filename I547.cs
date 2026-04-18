public class Solution {
    public int MirrorDistance(int n) {
        return Math.Abs(n - int.Parse(new string(n.ToString().Reverse().ToArray())));
    }
}
