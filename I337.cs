public class Solution {
    public bool HasSameDigits(string s) {
        int n = s.Length;
        char[] arr = s.ToCharArray();
        for (int i = 1; i <= n - 2; i++) {
            for (int j = 0; j <= n - 1 - i; j++) {
                arr[j] =
                    (char)(((arr[j] - '0') + (arr[j + 1] - '0')) % 10 + '0');
            }
        }
        return arr[0] == arr[1];
    }
}
