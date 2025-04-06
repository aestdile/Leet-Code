public class Solution {
    public IList<string> LetterCasePermutation(string s) 
    {
        List<string> result = new List<string>();
        Backtrack(s.ToCharArray(), 0, result);
        return result;
    }

    private void Backtrack(char[] chars, int index, List<string> result) 
    {
        if (index == chars.Length) {
            result.Add(new string(chars));
            return;
        }

        if (char.IsLetter(chars[index])) {
            chars[index] = char.ToLower(chars[index]);
            Backtrack(chars, index + 1, result);

            chars[index] = char.ToUpper(chars[index]);
            Backtrack(chars, index + 1, result);
        } else {
            
            Backtrack(chars, index + 1, result);
        }
    }
}


