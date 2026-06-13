public class Solution {
    public string MapWordWeights(string[] words, int[] weights) => new string(words.
        Select(m => m.Sum(n => weights[n - 'a'])).
        Select(m => (char)('z' - (m % 26))).
        ToArray());
}
