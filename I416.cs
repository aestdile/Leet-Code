public class Solution {
    public int CountPermutations(int[] complexity) {
        var result = 1L;
        for (int i = 1; i < complexity.Length; i++){
            if (complexity[0] < complexity[i])
                result = result * i % 1_000_000_007;
            else
                return 0;
        }
        return (int)result;
    }
}