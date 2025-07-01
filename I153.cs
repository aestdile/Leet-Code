public class Solution {
    public IList<int> FindSubstring(string s, string[] words) {
        var result = new List<int>();
    if (words.Length == 0 || s.Length == 0) return result;

    int wordLen = words[0].Length;
    int wordCount = words.Length;
    int totalLen = wordLen * wordCount;

    if (s.Length < totalLen) return result;

    var wordMap = new Dictionary<string, int>();
    foreach (var word in words) {
        if (!wordMap.ContainsKey(word)) wordMap[word] = 0;
        wordMap[word]++;
    }

    for (int i = 0; i < wordLen; i++) { 
        int left = i, count = 0;
        var windowMap = new Dictionary<string, int>();

        for (int j = i; j <= s.Length - wordLen; j += wordLen) {
            var word = s.Substring(j, wordLen);

            if (wordMap.ContainsKey(word)) {
                if (!windowMap.ContainsKey(word)) windowMap[word] = 0;
                windowMap[word]++;
                count++;

                while (windowMap[word] > wordMap[word]) {
                    var leftWord = s.Substring(left, wordLen);
                    windowMap[leftWord]--;
                    count--;
                    left += wordLen;
                }

                if (count == wordCount)
                    result.Add(left);
            } else {
                windowMap.Clear();
                count = 0;
                left = j + wordLen;
            }
        }
    }

    return result;
    }
}
