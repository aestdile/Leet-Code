public class Solution 
{
    public int[] PivotArray(int[] nums, int pivot) 
    {
        Queue<int> less = new Queue<int>();
        Queue<int> piv = new Queue<int>();
        Queue<int> more = new Queue<int>();

        int[] answer = new int [nums.Length];
        
        for(int i = 0; i < nums.Length; i++)
        {
            if(nums[i] < pivot)
            {
                less.Enqueue(nums[i]);
            }
            if(nums[i] > pivot)
            {
                more.Enqueue(nums[i]);
            }
            if(nums[i]== pivot)
            {
                piv.Enqueue(nums[i]);
            }
        }

        for(int i = 0; i < nums.Length; i++)
        {
            if(less.Count > 0)
            {
                answer[i] = less.Dequeue();
            }
            else if(piv.Count > 0)
            {
                answer[i] = piv.Dequeue();
            }
            else if(more.Count > 0)
            {
                answer[i] = more.Dequeue();
            }
        }

        return answer;
    }
}
