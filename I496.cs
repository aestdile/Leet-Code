public class Solution {
    public int NumSteps(string s) {
        int ls = s.Length;
        int nextBit = 0;
        int currentBit = 0;
        int counter = 0;

        for(int i=ls-1;i>0;i--)
        {
            currentBit = s[i]-'0';
            counter += currentBit^nextBit;
            nextBit = currentBit|nextBit;
            counter++;
        }

        return counter+nextBit;  
    }
}
