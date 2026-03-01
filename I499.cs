public class Solution {
    public int MinPartitions(string n) => n.
        ToCharArray().
        Max(m => m - '0');
}
