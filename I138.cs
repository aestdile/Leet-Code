public class Solution 
{
    public int[] MaxSubsequence(int[] nums, int k) 
    {
        List<int> list = new(nums);
        int n = nums.Length - k;
        for (int i = 0; i < n; i++) 
        {
            list.RemoveAt(list.IndexOf(list.Min()));
        }
        return list.ToArray();
    }
}
