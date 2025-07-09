public class Solution {
    public int MaxFreeTime(int eventTime, int k, int[] startTime, int[] endTime){
        var curMax = 0;
        var curFreeTime = startTime[0];
        var len = startTime.Length;

        for (int id = 0; id < len; id++)
        {
            curFreeTime += (id == (len - 1)) ? 
                eventTime - endTime[len - 1] : startTime[id + 1] - endTime[id];

            if (id >= k)
            {
                curFreeTime -= (id < (k + 1)) ? 
                    startTime[0] : startTime[id - k] - endTime[id - k - 1];
            }

            curMax = Math.Max(curMax, curFreeTime);
        }

        return curMax;
    }
}
