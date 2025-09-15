public class Solution {
    public int CanBeTypedWords(string text, string brokenLetters) => text.
        Split(" ").
        Count(m => m.IndexOfAny(brokenLetters.ToCharArray()) == -1);
}