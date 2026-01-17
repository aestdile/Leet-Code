public class Solution {
    public long LargestSquareArea(int[][] bottomLeft, int[][] topRight) {
        long rs = 0;
        int len = bottomLeft.Length;
        int overlapBottomLeftX = 0;
        int overlapBottomLeftY = 0;
        int overlapTopRightX = 0;
        int overlapTopRightY = 0;
        for(int i = 0; i < len; i++){
            for(int j = i + 1; j < len; j++){
                overlapBottomLeftX = Math.Max(bottomLeft[i][0], bottomLeft[j][0]);
                overlapBottomLeftY = Math.Max(bottomLeft[i][1], bottomLeft[j][1]);
                overlapTopRightX = Math.Min(topRight[i][0], topRight[j][0]);
                overlapTopRightY = Math.Min(topRight[i][1], topRight[j][1]);
                if(overlapBottomLeftX < overlapTopRightX && overlapBottomLeftY < overlapTopRightY){
                    long l = (long)Math.Min(overlapTopRightX - overlapBottomLeftX, overlapTopRightY - overlapBottomLeftY);
                    rs = Math.Max(rs, l * l);
                }
            }
        }
        return rs;
    }
}
