public class Solution {
    public char KthCharacter(int k) {
        int shift = 0;
        k--; 
        while (k > 0) {
            if ((k & 1) == 1) shift++;
            k >>= 1;
        }
        return (char)('a' + (shift % 26));
    }
}
