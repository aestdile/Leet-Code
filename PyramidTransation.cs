public class Solution {
    Dictionary<string, List<char>> map = new Dictionary<string, List<char>>();
    Dictionary<string, bool> memo = new Dictionary<string, bool>();

    public bool PyramidTransition(string bottom, IList<string> allowed)
    {
        foreach (var t in allowed)
        {
            string key = t.Substring(0, 2);
            char value = t[2];

            if (!map.ContainsKey(key))
                map[key] = new List<char>();

            map[key].Add(value);
        }

        return DFS(bottom);
    }

    private bool DFS(string row)
    {
        if (memo.ContainsKey(row))
            return memo[row];

        if (row.Length == 1)
        {
            memo[row] = true;
            return true;
        }

        int n = row.Length;
        for (int i = 0; i < n - 1; i++)
        {
            if (!map.ContainsKey(row.Substring(i, 2)))
            {
                memo[row] = false;
                return false;
            }
        }

        bool Helper(int index, string curr)
        {
            if (index == n - 1)
                return DFS(curr);

            string pair = row.Substring(index, 2);

            foreach (char c in map[pair])
            {
                if (Helper(index + 1, curr + c))
                    return true;
            }
            return false;
        }

        bool result = Helper(0, "");
        memo[row] = result;
        return result;
}}
