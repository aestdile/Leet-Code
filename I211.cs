public class Solution {
    public int MaxSum(int[] nums) {
        int m = nums.Max();
        if(m <= 0){
            return m;
        }
        HashSet<int> set = new();
        foreach(int x in nums){
            if(x>=0){
                set.Add(x);
            }
        }
        return set.Sum();
    }
}
