public class Solution {
  public string MakeLargestSpecial(string s) {
    int count = 0, start = 0;
    List<string> specials = new();

    for (int i = 0; i < s.Length; i++) {
      count += (s[i] == '1') ? 1 : -1;
      if (count == 0) {
        specials.Add($"1{MakeLargestSpecial(s.Substring(start + 1, i - start - 1))}0");
        start = i + 1;
      }
    }

    specials.Sort();
    specials.Reverse();

    return string.Join(string.Empty, specials);
  }
}
