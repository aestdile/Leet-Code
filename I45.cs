public class Solution {
    public IList<int> FindDisappearedNumbers(int[] nums) {
        HashSet<int> numSet = new HashSet<int>(nums);
        List<int> result = new List<int>();

        for (int i = 1; i <= nums.Length; i++) {
            if (!numSet.Contains(i)) {
                result.Add(i);
            }
        }
        return result;
    }
}
