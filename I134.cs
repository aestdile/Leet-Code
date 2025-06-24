public class Solution {
    public IList<int> FindKDistantIndices(int[] nums, int key, int k) {
        List<int> res = new();
        int len = nums.Length;
       
        List<int[]> preIds = new();
        int[] pre = [-1, -1];
        for(int i = 0; i < len; i++)
        {
            if(nums[i] == key)
            {
                int startIdx = Math.Max(0, i-k), endIdx = Math.Min(i+k, len-1);

                if(pre[1] == -1)
                    pre = [startIdx, endIdx];
                else if(pre[1] < startIdx-1)
                {
                    preIds.Add([pre[0], pre[1]]);
                    pre = [startIdx, endIdx];
                }
                else
                    pre[1] = Math.Max(pre[1], endIdx);
            }
        }

        if(pre[1] != -1)
            preIds.Add(pre);

        foreach(int[] cur in preIds)
        {
            int id = cur[0];
            while(id <= cur[1])
            {
                res.Add(id++);
            }
        }

        return res;
    }
}
