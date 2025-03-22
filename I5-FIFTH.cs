public class Solution {
    public bool IsPalindrome(int x) {
        string str = x.ToString();
        char[] arr = str.ToCharArray();
        Array.Reverse(arr);
        return str == new string(arr);
    }
}
