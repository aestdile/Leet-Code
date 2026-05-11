public class Solution {
    public int[] SeparateDigits(int[] nums) {
        static IEnumerable<int> Digits(int value) {
            for (; value > 0; value /= 10)
                yield return value % 10;
        }    

        return nums
            .SelectMany(item => Digits(item).Reverse())
            .ToArray();
    }
}
