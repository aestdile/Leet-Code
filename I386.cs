public class Solution {
    public IList<bool> PrefixesDivBy5(int[] nums) {
        List<bool> result = new();
        int prefix = 0;
        for(int i = 0; i < nums.Length; i++) {
            prefix =  (prefix << 1 | nums[i]) % 5;
            result.Add(prefix == 0);
        }
        return result;
    }
}