public class Solution {
    public int TriangleNumber(int[] nums) {
         Array.Sort(nums);
         int answer = 0;
         
         for(int k = nums.Length - 1 ; k>1; k--)
         {
            int i = 0 , j = k - 1;
            while(i<j)
            {
                if(nums[i] + nums[j] > nums[k])
                {
                    answer+= (j - i);
                    j--;
                }
                else i++;
            }
         }
         return answer;
    }
}
