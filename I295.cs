public class Solution {
    public IList<string> SummaryRanges(int[] nums) {
        var list = new List<string>();
         int index = 0;
         while (index < nums.Length)
         {
             int start = index;
             while (index + 1 < nums.Length && nums[index + 1] == nums[index] + 1)
                 index++;
             
             if(start == index)
                 list.Add(nums[start].ToString());
             else 
                 list.Add($"{nums[start]}->{nums[index]}");

             index++;
         }
         return list;
    }
}
