public class Solution {
    public int NumJewelsInStones(string jewels, string stones) {
        return stones.Where(x=>jewels.Contains(x)).Count();
    }
}
