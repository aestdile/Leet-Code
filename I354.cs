public class Solution {
    public int SmallestNumber(int n) =>
        (int)BitOperations.RoundUpToPowerOf2((uint)n + 1) - 1;
}
