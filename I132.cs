public class Solution {
    public string[] DivideString(string s, int k, char fill) {
        while (s.Length % k > 0)
        {
            s += fill;
        }
        var response = new string[s.Length / k];
        int position = 0;
        for (int i = 0; i < response.Length; i++)
        {
            response[i] = s.Substring(position, k);
            position += k;

        }
        return response;
    }
}
