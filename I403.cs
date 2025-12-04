public class Solution {
    public string CountAndSay(int n) {
        if (n == 1) return "1"; 

        string result = "1";

        for (int i = 2; i <= n; i++) {
            StringBuilder sb = new StringBuilder();
            int count = 1;
            char prevChar = result[0];

            for (int j = 1; j < result.Length; j++) {
                char currentChar = result[j];
                if (currentChar == prevChar) {
                    count++;
                } else {
                    sb.Append(count).Append(prevChar);
                    count = 1;
                    prevChar = currentChar;
                }
            }

            sb.Append(count).Append(prevChar); 
            result = sb.ToString(); 
        }

        return result;
    }
}
