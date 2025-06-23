public class Solution {
    public long KMirror(int k, int n) {
        long sum = 0;
        int count = 0;
        int length = 1;

        while (count < n) {
            foreach (long num in GeneratePalindromes(length)) {
                if (IsPalindrome(ToBaseK(num, k))) {
                    sum += num;
                    count++;
                    if (count == n)
                        return sum;
                }
            }
            length++;
        }

        return sum;
    }
     private List<long> GeneratePalindromes(int length) {
        List<long> result = new List<long>();
        int start = (int)Math.Pow(10, (length - 1) / 2);
        int end = (int)Math.Pow(10, (length + 1) / 2);

        for (int i = start; i < end; i++) {
            string firstHalf = i.ToString();
            string fullPalindrome;

            if (length % 2 == 0) {
                fullPalindrome = firstHalf + ReverseString(firstHalf);
            } else {
                fullPalindrome = firstHalf + ReverseString(firstHalf.Substring(0, firstHalf.Length - 1));
            }

            result.Add(long.Parse(fullPalindrome));
        }

        return result;
    }

    private string ToBaseK(long num, int k) {
        StringBuilder sb = new StringBuilder();
        while (num > 0) {
            sb.Insert(0, num % k);
            num /= k;
        }
        return sb.ToString();
    }

    private bool IsPalindrome(string s) {
        int left = 0, right = s.Length - 1;
        while (left < right) {
            if (s[left++] != s[right--])
                return false;
        }
        return true;
    }

    private string ReverseString(string s) {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }
}
