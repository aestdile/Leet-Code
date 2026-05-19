public class Solution {
    public int GetCommon(int[] nums1, int[] nums2) => nums1
        .Intersect(nums2)
        .FirstOrDefault(-1);
}
