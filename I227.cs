public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        var triangle = new List<IList<int>>();

        if (numRows >= 1) {
            triangle.Add(new List<int> { 1 });
        }

        for (int row = 1; row < numRows; row++) {
            var prevRow = triangle[row - 1];
            var currRow = new List<int>();
            currRow.Add(1); 

            for (int j = 1; j < row; j++) {
                int val = prevRow[j - 1] + prevRow[j];
                currRow.Add(val);
            }

            currRow.Add(1);
            triangle.Add(currRow);
        }

        return triangle;
    }
}
