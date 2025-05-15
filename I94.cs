public class Solution {
    public IList<string> GetLongestSubsequence(string[] words, int[] groups) {
        List<string> result = new List<string>();

        if (words.Length == 0)
            return result;

        result.Add(words[0]); 
        int lastGroup = groups[0];

        for (int i = 1; i < words.Length; i++) {
            if (groups[i] != lastGroup) {
                result.Add(words[i]);
                lastGroup = groups[i]; 
            }
        }

        return result;
    }
}
