public class Solution {
    public bool WordPattern(string pattern, string s)
    {
        var dictionary = new Dictionary<char, string>();
        var words = s.Split(' ');
        if (words.Length != pattern.Length)
        {
            return false;
        }
        for (var i = 0; i < pattern.Length ; i++)
        {
            if (dictionary.TryGetValue(pattern[i], out var currentPair))
            {
                if (currentPair != words[i])
                {
                    return false;
                }
                continue;
            }
            if (dictionary.ContainsValue(words[i]))
            {
                return false;
            }
            dictionary.Add(pattern[i], words[i]);
        }
        return true;
    }
}
