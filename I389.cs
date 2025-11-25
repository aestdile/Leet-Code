public class Solution {
    public int SmallestRepunitDivByK(int k) {
        if (k % 2 == 0 || k % 5 == 0)
            return -1;

        int remainder = 1;           
        int repunitLength = 1;      

        while (true)
        {
            if (remainder % k == 0)
                return repunitLength;

            remainder = (remainder % k) * 10 + 1;
            repunitLength++;
        }
    }
}