public class Solution {
    public IList<string> CommonChars(string[] words) {
        return words.SelectMany(s => s.ToCharArray())
                    .GroupBy(s => s)
                    .Where(s => s.Count() >= words.Length)
                    .SelectMany(s => Enumerable.Repeat(s.Key.ToString(), words.Min(word => word.Count(c => c == s.Key))))
                    .ToList();
    }
}
