public class Solution {
    public bool CanReach(string s, int minJump, int maxJump) {
        int n = s.Length;
        int[] range = new int[n];
        if (s[n-1] != '0')
        {
            return false;
        }
        int r = 0;
        for(int i=0; i<s.Length; i++)
        {
            r += range[i];
            if (i == n-1)
            {
                return r > 0;
            }
            // Reachable zero, since r > 0
            if (s[i] == '0' && (r > 0 || i == 0))
            {
                int max = Math.Min(i+maxJump, n-1);
                if (max+1 < n)
                {
                    range[max+1] -= 1;
                }
                if ((i+minJump) < n) {
                    range[i+minJump] += 1;
                }
            }
            //Print(range);
        }
        return true;
    }

    private void Print(int[] r)
    {
        for(int i=0; i<r.Length; i++)
        {
            Console.Write($"{r[i]} : ");
        }
        Console.WriteLine("\n");
    }
}
