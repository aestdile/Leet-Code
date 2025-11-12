public class Solution
{
    public int MinOperations(int[] nums)
    {
        if (nums.Contains(1))
            return nums.Length - nums.Count(n => n == 1);

        var result = -1;

        for (var i = 0; i < nums.Length; i++)
            for (var j = i; j < nums.Length; j++)
            {
                var d = nums.Skip(i).Take(j - i + 1).Aggregate(nums[j], Gcd);

                if (d != 1)
                    continue;

                result = result == -1
                    ? j - i + 1
                    : Math.Min(result, j - i + 1);
            }

        return result == -1 ? -1 : nums.Length + result - 2;
    }

    private static int Gcd(int a, int b)
    {
        return b == 0 ? a : Gcd(b, a % b);
    }
}