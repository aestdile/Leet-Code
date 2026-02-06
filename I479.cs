public class Solution {
    public int MinRemoval(int[] nums, int k) {
        int len = nums.Length;
        Dictionary<int, int[]> dict = new();
        foreach(int n in nums)
        {
            if(!dict.ContainsKey(n))
                dict.Add(n, new int[2]);

            dict[n][0]++;
        }

        List<int> keys = dict.Keys.ToList();
        keys.Sort();
        int kLen = keys.Count, rightId = kLen-1, res = int.MaxValue, rightCnt = 0;
        for(int i = kLen-1; i >= 0; i--)
        {
            int curK = keys[i];
            dict[curK][1] = rightCnt;

            rightCnt += dict[curK][0];
            int kTimes = curK*k;
            while(keys[rightId]/curK > k || keys[rightId]/curK == k && keys[rightId]%curK != 0)
            {
                rightId--;
            }

            int high = dict[keys[rightId]][1], low = len - dict[curK][0]-dict[curK][1];
            if(low+high < res)
                res = low+high;
        }

        return res;
    }
}
