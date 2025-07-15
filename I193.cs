public class Solution {
    public bool IsValid(string word) {
        if (word.Length < 3) return false;
        bool hasVowel = false, hasCons = false;

        foreach (char c in word) {
            if (!char.IsLetterOrDigit(c)) return false;
            if (char.IsLetter(c)) {
                char l = char.ToLower(c);
                if ("aeiou".Contains(l)) hasVowel = true;
                else hasCons = true;
            }
        }

        return hasVowel && hasCons;
    }
}
