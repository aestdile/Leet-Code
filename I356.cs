public class Solution {
    public int[] GetSneakyNumbers(int[] nums) {
        return nums.GroupBy(x => x).Where(y => y.Count() > 1).Select(z => z.First()).ToArray();
    }
}
