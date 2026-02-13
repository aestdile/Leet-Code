public class Solution {
    public int LongestBalanced(string s) {
        var result = GetSingle(s);
        result = Math.Max(result, GetAll(s));
        result = Math.Max(result, GetPair(s, 'a', 'b', 'c'));
        result = Math.Max(result, GetPair(s, 'b', 'c', 'a'));
        result = Math.Max(result, GetPair(s, 'c', 'a', 'b'));

        return result;
    }

    public int GetPair(string s, char first, char second, char ignore)
    {
        var result = 0;
        var count = new int[3];
        var dict = new Dictionary<int , int>();
        dict.Add(0, -1);
        for(int i = 0; i < s.Length; i++)
        {
            if(s[i] == ignore)
            {
                dict.Clear();
                dict[0] = i;
                count[first - 'a'] = 0;
                count[second -'a'] = 0;
            }
            else
            {
                count[s[i] - 'a'] += 1;
                var diff = count[first - 'a'] - count[second -'a'];
                if(dict.ContainsKey(diff))
                {
                    result = Math.Max(result, i - dict[diff]);
                }
                else
                {
                    dict.Add(diff, i);
                }
            }
        }

        //Console.WriteLine($"{first} - {second} , {result}");
        return result;
    }

    public int GetAll(string s)
    {
        var result = 0;
        var count = new int[3];
        var dict = new Dictionary<(int, int), int>();
        dict.Add((0,0), -1);
        for(int i = 0; i < s.Length; i++)
        {
            count[s[i] - 'a'] += 1;
            var diff = (count[1] - count[0], count[2] - count[0]);
            if(dict.ContainsKey(diff))
            {
                result = Math.Max(result, i - dict[diff]);
            }
            else
            {
                dict.Add(diff, i);
            }
        }

        return result;
    }

    public int GetSingle(string s)
    {
        var result = 1;
        var count  = 1;
        for(int i = 1; i < s.Length; i++)
        {
            if(s[i] == s[i - 1])
            {
                count += 1;
            }
            else
            {
                result = Math.Max(result, count);
                count = 1;
            }
        }
        result = Math.Max(result, count);
        return result;
    }

}
