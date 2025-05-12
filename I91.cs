public class Solution {
    public int[] FindEvenNumbers(int[] digits) {
        int[] count = new int[10];
        foreach (int d in digits)
            count[d]++;

        var result = new List<int>();
        for (int num = 100; num <= 999; num += 2) 
        { 
            int a = num / 100, b = (num / 10) % 10, c = num % 10;
            int[] needed = new int[10];
            needed[a]++;
            needed[b]++;
            needed[c]++;

            bool valid = true;
            for (int d = 0; d < 10; d++) {
                if (needed[d] > count[d]) {
                    valid = false;
                    break;
                }
            }
            if (valid) result.Add(num);
        }
        return result.ToArray();
    }
}
