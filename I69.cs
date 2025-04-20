public class Solution {
    public int NumRabbits(int[] answers) {
        Dictionary<int, int> freq = new Dictionary<int, int>();
        int result = 0;
        foreach (int answer in answers) {
            if (!freq.ContainsKey(answer)) {
                freq[answer] = 0;
            }
            freq[answer]++;
        }
        foreach (var pair in freq) {
            int x = pair.Key;      // javob bergan quyon: "x ta mendek bor"
            int count = pair.Value;  // nechta quyon shu javobni bergan

            int groupSize = x + 1;
            int groups = (int)Math.Ceiling((double)count / groupSize);
            result += groups * groupSize;
        }
        return result;
    }
}
