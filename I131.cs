
public class Solution {
    public int MinimumDeletions(string word, int k) {
        var freq = new Dictionary<char, int>();
        foreach (char c in word) {
            if (!freq.ContainsKey(c))
                freq[c] = 0;
            freq[c]++;
        }

        var freqValues = freq.Values.ToList();
        freqValues.Sort();

        int minDeletions = int.MaxValue;

        for (int i = 0; i < freqValues.Count; i++) {
            int target = freqValues[i];
            int deletions = 0;

            foreach (int f in freqValues) {
                if (f > target + k) {
                    deletions += f - (target + k);
                } else if (f < target) {
                    deletions += f;
                }
            }
            minDeletions = Math.Min(minDeletions, deletions);
        }

        return minDeletions;
    }
}
