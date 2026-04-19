public class Solution {
    public int MaxDistance(int[] nums1, int[] nums2) {
        int ret = 0, i = 0, j = 0;
        while (i < nums1.Length && j < nums2.Length) {
            if(i > j)
                j++;
            else if(nums1[i] > nums2[j])
                i++;
            else{
                ret = Math.Max(ret, j-i);
                j++;
            }
        }
        return ret;
    }
}
