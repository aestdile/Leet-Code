public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        var result = new List<string>();
        GenerateCombinations(result, "", 0, 0, n);
        return result;
    }
    
    private void GenerateCombinations(IList<string> result, string current, int open, int close, int max) {
        if (current.Length == max * 2) {
            result.Add(current);
            return;
        }
        
        if (open < max) {
            GenerateCombinations(result, current + "(", open + 1, close, max);
        }
        
        if (close < open) {
            GenerateCombinations(result, current + ")", open, close + 1, max);
        }
    }
}
