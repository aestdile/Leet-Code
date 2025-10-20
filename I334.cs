public class Solution {
    public int FinalValueAfterOperations(string[] operations) => operations.
        Select(m => m.Contains("--") ? -1 : 1).
        Sum();
}
