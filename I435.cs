public class Solution {
    public int MinDeletionSize(string[] strs) {
        int rows = strs.Length;
        int cols = strs[0].Length;

        bool[] sorted = new bool[rows - 1];
        int deletions = 0;

        for (int col = 0; col < cols; col++){
            bool needDelete = false;

            for (int row = 0; row < rows - 1; row++){
                if (!sorted[row] && strs[row][col] > strs[row + 1][col]){
                    needDelete = true;
                    break;
                }
            }

            if (needDelete){
                deletions++;
            }
            else{
                for (int row = 0; row < rows - 1; row++){
                    if (strs[row][col] < strs[row + 1][col]){
                        sorted[row] = true;
                    }
                }
            }
        }

        return deletions;
    }
}
