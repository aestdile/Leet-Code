public class Solution {
    public int MaxArea(int[] height) {
        int left = 0;
        int right = height.Length - 1;
        int maxarea = 0;
        while (left < right)
        {
           int area = Math.Min(height[left],height[right]) * (right - left);
            maxarea = Math.Max(area,maxarea);
           if(height[left] < height[right])
           {
            left ++;
           }
           else
           {
            right--;
           }            
        }
       return maxarea;       
    }
}
