public class Solution {
    public string FindDifferentBinaryString(string[] nums) {
        HashSet<string> set = new HashSet<string>(nums);
        int n = nums.Length;
        char[] result = new char[n];
        
        for (int i = 0; i < n; i++) {
            result[i] = nums[i][i] == '0' ? '1' : '0';
        }
        
        return new string(result);
    }
}
