public class Solution {
    public bool IsIsomorphic(string text1, string text2)
    {
        var codes1 = GetCodes(text1);
        var codes2 = GetCodes(text2);
        return codes1.SequenceEqual(codes2);
    }

    private IEnumerable<int> GetCodes(string text)
    {
        var set = new HashSet<char>();
        return text.Select((key, i) => set.Add(key) ? i : text.IndexOf(key));
    }
}
