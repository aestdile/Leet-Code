public class Solution {
    private int maxWind = 0;
    public int MaxFreeTime(int eventTime, int[] startTime, int[] endTime) {
        int len = startTime.Length;
        if(eventTime == 0 || len != endTime.Length)
            return maxWind;

        int preGap = 0, preEnd = 0;
        List<int> leftMaxGap = new(), gaps = new();
        for(int i = 0; i <= len; i++)
        {
             int gap = 0;
            if(i < len)
            {
                gap = startTime[i] - preEnd;
                maxWind = Math.Max(maxWind, gap + preGap);
                preEnd = endTime[i];
            }
            else
            {
                gap = eventTime-preEnd;
                maxWind = Math.Max(maxWind, gap + preGap);
            }
            
            gaps.Add(gap);
            leftMaxGap.Add(Math.Max(gap, leftMaxGap.Count > 0 ? leftMaxGap.Last() : 0));
            preGap = gap;
        }

        int[] rightMaxGap = new int[len+1];
        rightMaxGap[len] = 0;
        for(int i = len-1; i >= 0; i--)
        {
            rightMaxGap[i] = Math.Max(rightMaxGap[i+1], gaps[i+1]);
        }

        for(int i = 0; i < len; i++)
        {
            int twoGaps = gaps[i]+gaps[i+1];
            int curSize = endTime[i]-startTime[i];
            if(i > 0 && leftMaxGap[i-1] >= curSize || i < len && rightMaxGap[i+1] >= curSize)
                maxWind = Math.Max(maxWind, twoGaps+curSize);
        }
        return maxWind;
    }
}
