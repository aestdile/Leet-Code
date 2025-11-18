public class Solution {
    public bool IsOneBitCharacter(int[] bits) {
        int i = 0;
        while(i < bits.Length-1)
        {
            if(bits[i] == 1)
            {
                i++;
            }
            i++;
        }
        return i == bits.Length-1;
    }
}