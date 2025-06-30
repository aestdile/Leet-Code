public class Solution {
    public int FindLHS(int[] nums) {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        for(int i = 0; i < nums.Length; i++)
        {
            if(dict.ContainsKey(nums[i])) dict[nums[i]]++;
            else dict[nums[i]] = 1;   
        }
        
        int result = 0;
        foreach(KeyValuePair<int, int> item in dict)
        {
            if(dict.ContainsKey(item.Key + 1))
            {
                result = Math.Max(result, dict[item.Key] + dict[item.Key + 1]);
            }
        }
        return result;
    }
}
