public class Solution{
    public string LargestNumber(int[] nums){
        var numStrs = nums.Select(n => n.ToString()).ToArray();
        Array.Sort(numStrs, (a, b) => (b + a).CompareTo(a + b));
        if (numStrs[0] == "0")
            return "0";
        return string.Join("", numStrs);
    }
}
