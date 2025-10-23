public class Solution {
    public int[] NumberOfLines(int[] widths, string s) {
        
        int[] result = new int[2];
        result[0] = 1;
        int pixels = 0;
        foreach(char ch in s)
        {
            int width = widths[ch - 'a'];

            if(pixels + width > 100)
            {
                result[0]++;
                pixels = 0;
            }
            pixels += width;
        }

        result[1] = pixels;
        return result;
    }
}
