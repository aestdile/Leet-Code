public class Solution {
    
    public int MinMirrorPairDistance(int[] nums)
    {
        Dictionary<int, Queue<int>> dict = [];
        Dictionary<int, int> memo = [];
        for (int i = 0; i < nums.Length; i++)
        {
            int n = nums[i];
            if (!dict.ContainsKey(n)) dict[n] = [];
            dict[n].Enqueue(i);
        }

        int min = int.MaxValue;
        for (int i = 0; i < nums.Length; i++)
        {
            int reverse = GetReverse(nums[i]);

            if (dict.TryGetValue(reverse, out var queue))
            {
                while (queue.Count != 0)
                {
                    int j = queue.Peek();
                    if (j <= i) queue.Dequeue();
                    else
                    {
                        min = Math.Min(min, j - i);
                        break;
                    }
                }
            }
        }
        if (min == int.MaxValue) return -1;
        return min;
    }


    static int Reverse(int n)
    {
        int result = 0;
        while (n > 0)
        {
            result = result * 10 + n % 10;
            n /= 10;
        }
        return result;
    }

    static readonly Dictionary<int, int> memo = [];
    static int GetReverse(int n)
    {
        int reverse = memo.GetValueOrDefault(n, -1);
        if (reverse == -1)
        {
            reverse = Reverse(n);
            memo[n] = reverse;
        }
        return reverse;
    }
}
