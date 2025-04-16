public class Solution {
    public string SmallestPalindrome(string s) {
        Dictionary<char, int> freq = new Dictionary<char, int>();
        foreach (char c in s) {
            if (!freq.ContainsKey(c)) freq[c] = 0;
            freq[c]++;
        }

        List<char> leftHalf = new List<char>();
        char middleChar = '\0'; 

        foreach (char c in freq.Keys.OrderBy(c => c)) {
            int count = freq[c];

            if (count % 2 == 1 && middleChar == '\0') {
                middleChar = c;
            }

            for (int i = 0; i < count / 2; i++) {
                leftHalf.Add(c);
            }
        }

        string left = new string(leftHalf.ToArray());
        string right = new string(leftHalf.AsEnumerable().Reverse().ToArray());

        return middleChar == '\0' ? left + right : left + middleChar + right;
    }
}
