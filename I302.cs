public class Solution {
    public int CompareVersion(string version1, string version2) {
        int index1 = 0, index2 = 0;
        int length1 = version1.Length, length2 = version2.Length;

        while (index1 < length1 || index2 < length2) {
            int number1 = 0;
            while (index1 < length1 && version1[index1] != '.') {
                number1 = number1 * 10 + (version1[index1] - '0');
                index1++;
            }
            index1++; 
            int number2 = 0;
            while (index2 < length2 && version2[index2] != '.') {
                number2 = number2 * 10 + (version2[index2] - '0');
                index2++;
            }
            index2++; 
            if (number1 > number2) return 1;
            if (number1 < number2) return -1;
        }

        return 0;
    }
}