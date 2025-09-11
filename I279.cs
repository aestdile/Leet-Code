public class Solution {
    public string SortVowels(string s) {
        char[] chars = s.ToCharArray();
        List<char> vowels = new List<char>();

        foreach (char c in chars) {
            if (IsVowel(c)) {
                vowels.Add(c);
            }
        }

        vowels.Sort();

        int vowelIndex = 0;
        for (int i = 0; i < chars.Length; i++) {
            if (IsVowel(chars[i])) {
                chars[i] = vowels[vowelIndex++];
            }
        }

        return new string(chars);
    }

     private bool IsVowel(char c) {
        char lowerC = char.ToLower(c);
        return lowerC == 'a' || lowerC == 'e' || lowerC == 'i' || lowerC == 'o' || lowerC == 'u';
    }

}
