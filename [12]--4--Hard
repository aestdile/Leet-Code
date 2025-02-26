public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int[] res = nums1.Concat(nums2).ToArray();
        Array.Sort(res);
        int lenz=res.Length;
        if (lenz%2==1)
        {
            return res[lenz/2];
        }
        else
        {
            return (res[lenz/2-1]+res[lenz/2])/2.0;
        }  
    }
}
