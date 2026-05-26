public class Solution {
    public int NumberOfSpecialChars(string word) {
        char[] uniqueChar = word.Distinct().ToArray(); // get distinct character
        var pairs = word.ToLower().GroupBy(a=>a).Select(a=> new { Key=a.Key , Value=a.Count()}).Where(a=>a.Value >=2);
        int MagicalCharacterCount = 0;

        foreach (var ele in pairs)
        {
        if(word.Contains(ele.Key.ToString().ToLower()) && word.Contains(ele.Key.ToString().ToUpper())) //if word contain lower and upper case character then increment Counter
            {
                MagicalCharacterCount++;
            }
        }
        return MagicalCharacterCount;
    }
}
