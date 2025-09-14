public class Solution {
    public string[] Spellchecker(string[] wordlist, string[] queries) {
        var exact = new HashSet<string>(wordlist);
        var caseMap = new Dictionary<string, string>();
        var vowelMap = new Dictionary<string, string>();

        foreach (string w in wordlist) {
            string lower = w.ToLower();
            string devowel = DeVowel(lower);
            if (!caseMap.ContainsKey(lower)) caseMap[lower] = w;
            if (!vowelMap.ContainsKey(devowel)) vowelMap[devowel] = w;
        }
        string[] result = new string[queries.Length];
        for (int i = 0; i < queries.Length; i++) {
            string q = queries[i];
            if (exact.Contains(q)) {
                result[i] = q;
            } else {
                string lower = q.ToLower();
                string devowel = DeVowel(lower);
                if (caseMap.ContainsKey(lower)) result[i] = caseMap[lower];
                else if (vowelMap.ContainsKey(devowel)) result[i] = vowelMap[devowel];
                else result[i] = "";
            }
        }
        return result;
    }

    private string DeVowel(string s) {
        var ch = s.ToCharArray();
        for (int i = 0; i < ch.Length; i++) {
            if ("aeiou".IndexOf(char.ToLower(ch[i])) >= 0) ch[i] = '*';
        }
        return new string(ch);
    }
}
