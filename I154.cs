public class Solution {
      private const int mod = 1000000007;

  public int PossibleStringCount(string word, int k)
  {
      int n = word.Length;
      int cnt = 1;
      List<int> freq = new List<int>();

      for (int i = 1; i < n; ++i)
      {
          if (word[i] == word[i - 1])
          {
              ++cnt;
          }
          else
          {
              freq.Add(cnt);
              cnt = 1;
          }
      }
      freq.Add(cnt);
      long ans = 1;
      foreach (int o in freq)
      {
          ans = ans * o % mod;
      }
      if (freq.Count >= k)
      {
          return (int)ans;
      }

      int[] f = new int[k];
      int[] g = new int[k];
      f[0] = 1;
      Array.Fill(g, 1);
      for (int i = 0; i < freq.Count; ++i)
      {
          int[] f_new = new int[k];
          for (int j = 1; j < k; ++j)
          {
              f_new[j] = g[j - 1];
              if (j - freq[i] - 1 >= 0)
              {
                  f_new[j] = (f_new[j] - g[j - freq[i] - 1] + mod) % mod;
              }
          }

          int[] g_new = new int[k];
          g_new[0] = f_new[0];
          for (int j = 1; j < k; ++j)
          {
              g_new[j] = (g_new[j - 1] + f_new[j]) % mod;
          }

          f = f_new;
          g = g_new;
      }

      return (int)((ans - g[k - 1] + mod) % mod);
  }
}