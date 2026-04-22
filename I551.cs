public class Solution
{
    public IList<string> TwoEditWords(string[] queries, string[] dictionary)
    {
        return queries.Where(query => dictionary.Any(word => query.Where((c, i) => c != word[i]).Count() <= 2)).ToList();
    }
}
