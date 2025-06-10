public class Solution {
    public int MaxDifference(string s) {
        Dictionary<char, int> freq = new Dictionary<char, int>();
        foreach (char c in s) {
            if (freq.ContainsKey(c)) {
                freq[c]++;
            } else {
                freq[c] = 1;
            }
        }
        int maxOddFreq = -1;
        int minEvenFreq = int.MaxValue;
        foreach (var kvp in freq) {
            int frequency = kvp.Value;
            
            if (frequency % 2 == 1) { 
                maxOddFreq = Math.Max(maxOddFreq, frequency);
            } else { 
                minEvenFreq = Math.Min(minEvenFreq, frequency);
            }
        }
        if (maxOddFreq == -1 || minEvenFreq == int.MaxValue) {
            return 0;
        }
        return maxOddFreq - minEvenFreq;
    }
}
