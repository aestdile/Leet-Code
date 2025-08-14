public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        return strs
            .GroupBy(s => new string(s.OrderBy(c => c).ToArray()))
            .Select(g => g.ToList() as IList<string>)
            .ToList();
    }
}
