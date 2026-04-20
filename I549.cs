public class Solution {
    public int MaxDistance(int[] colors) => colors
        .Select((m, i) => Array.FindLastIndex(colors, n => n != m) - i)
        .Max();
}
