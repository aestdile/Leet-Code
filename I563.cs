public class Solution {
    public char[][] RotateTheBox(char[][] box) {
        int m = box.Length;    
        int n = box[0].Length; 
        for (int i = 0; i < m; i++) {
            int emptyIndex = n - 1; 
            for (int j = n - 1; j >= 0; j--) {
                if (box[i][j] == '*') {
                    emptyIndex = j - 1;
                } else if (box[i][j] == '#') {
                    box[i][j] = '.';
                    box[i][emptyIndex] = '#';
                    emptyIndex--;
                }
            }
        }
        char[][] rotatedBox = new char[n][];
        for (int i = 0; i < n; i++) {
            rotatedBox[i] = new char[m];
        }

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                rotatedBox[j][m - i - 1] = box[i][j];
            }
        }

        return rotatedBox;
    }
}
