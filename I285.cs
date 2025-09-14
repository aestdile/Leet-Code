public class Solution {
    public int HammingDistance(int x, int y) {
        return int.PopCount(x ^ y);
    }
}
