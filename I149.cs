public class Solution {
    public int PossibleStringCount(string word) {
        int n = word.Length, ans = 1;
        for (int i = 1; i < n; ++i)
        {
            if (word[i - 1] == word[i])
            {
                ++ans;
            }
        }
        return ans;
    }
}
