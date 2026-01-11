public class Solution {
    public int MaximalRectangle(char[][] matrix) {
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0) {
            return 0;
        }
        
        int rows = matrix.Length;
        int cols = matrix[0].Length;
        int maxArea = 0;
        int[] heights = new int[cols];
        
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                heights[j] = matrix[i][j] == '1' ? heights[j] + 1 : 0;
            }
            maxArea = Math.Max(maxArea, LargestRectangleArea(heights));
        }
        
        return maxArea;
    }

    private int LargestRectangleArea(int[] heights) {
        Stack<int> stack = new Stack<int>();
        int maxArea = 0;
        int i = 0;
        
        while (i < heights.Length) {
            if (stack.Count == 0 || heights[stack.Peek()] <= heights[i]) {
                stack.Push(i++);
            } else {
                int top = stack.Pop();
                int area = heights[top] * (stack.Count == 0 ? i : i - stack.Peek() - 1);
                maxArea = Math.Max(maxArea, area);
            }
        }
        
        while (stack.Count > 0) {
            int top = stack.Pop();
            int area = heights[top] * (stack.Count == 0 ? i : i - stack.Peek() - 1);
            maxArea = Math.Max(maxArea, area);
        }
        
        return maxArea;
    }
}
