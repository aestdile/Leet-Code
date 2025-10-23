public class Solution
{
    public string ToGoatLatin(string sentence) 
        => string.Join(' ', sentence.Split(' ').Select(ConvertWordToGoatLatin));

    private static string ConvertWordToGoatLatin(string word, int index)
        => char.ToLower(word[0]) is not ('a' or 'e' or 'i' or 'o' or 'u')
            ? word[1..] + word[0] + "ma" + new string('a', index + 1)
            : word + "ma" + new string('a', index + 1);
}
