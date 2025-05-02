public class Solution {
    public IList<string> LetterCombinations(string digits) {
        if (string.IsNullOrEmpty(digits)) return new List<string>();
        var map = new[] {
            "",    "",    "abc", "def", "ghi",
            "jkl", "mno", "pqrs", "tuv", "wxyz"
        };
        var res = new List<string> { "" };
        foreach (var d in digits) {
            var temp = new List<string>();
            foreach (var prefix in res)
                foreach (var c in map[d - '0'])
                    temp.Add(prefix + c);
            res = temp;
        }
        return res;
    }
}
