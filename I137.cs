public class Solution {
    public string LongestSubsequenceRepeatedK(string s, int k) {
        int[] freq = new int[26];
        foreach (char c in s) {
            freq[c - 'a']++;
        }

        List<char> usable = new List<char>();
        for (int i = 25; i >= 0; i--) {
            if (freq[i] >= k) {
                usable.Add((char)(i + 'a'));
            }
        }

        Queue<string> queue = new Queue<string>();
        queue.Enqueue("");

        string result = "";

        while (queue.Count > 0) {
            string current = queue.Dequeue();

            foreach (char c in usable) {
                string next = current + c;

                if (IsValid(next, s, k)) {
                    queue.Enqueue(next);

                    if (next.Length > result.Length || 
                       (next.Length == result.Length && string.CompareOrdinal(next, result) > 0)) {
                        result = next;
                    }
                }
            }
        }

        return result;
    }
    private bool IsValid(string seq, string s, int k) {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < k; i++) {
            sb.Append(seq);
        }

        string repeated = sb.ToString();

        int i1 = 0, i2 = 0;
        while (i1 < s.Length && i2 < repeated.Length) {
            if (s[i1] == repeated[i2]) {
                i2++;
            }
            i1++;
        }

        return i2 == repeated.Length;
    }
}
