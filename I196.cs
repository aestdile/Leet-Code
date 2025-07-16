public class Solution {
    public int MaximumLength(int[] nums) {
        var alternating = 0;
        var even = 0;
        var odd = 0;

        bool? lastEven = null;

        foreach(var num in nums){
            var isEven = num % 2 == 0;
            if(isEven)
            {
                even++;
            }
            else
            {
                odd++;
            }

            if(lastEven == null || lastEven.Value != isEven)
            {
                lastEven = isEven;
                alternating++;
            }
        }

        return Math.Max(Math.Max(even, odd), alternating);
    }
}
