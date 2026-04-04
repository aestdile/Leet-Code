public class Solution {
    public string DecodeCiphertext(string encodedText, int rows) 
    {
        if(rows==1) return encodedText;

        int len = encodedText.Length;
        int cols = len / rows;

        var result = new StringBuilder(len);

        for(int col = 0; col < cols; col++)
        {
            int row =0;
            int j = col;

            while(row < rows && j < cols)
            {
                result.Append(encodedText[row * cols + j]);
                row++;
                j++;
            }
        }

        int end = result.Length-1;
        while(end >=0 && result[end] == ' ')
            end--;
        
        return result.ToString(0,end+1);
    }
}
