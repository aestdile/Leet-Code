public class Solution 
{
    public int Search(int[] nums, int target) 
    {
        int left = 0;
        int right = nums.Length - 1;
        int middle;

        while (left <= right)
        {
            middle = (left + right) / 2; 

            if (nums[middle] == target)
            {
                return middle;
            }
            else if (nums[middle] < nums[right])
            {
                if (target > nums[middle] && target <= nums[right])
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }
            else 
            {
                if (target >= nums[left] && target < nums[middle])
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }
        }

        return -1;
    }
}
