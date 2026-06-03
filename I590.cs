public class Solution {
    private int FindEarliest(int[] start, int[] dur, int pre = 0)
    {
        int len = start.Length;
        int res = int.MaxValue;
        for(int i = 0; i < len; i++)
        {
            int begin = Math.Max(start[i], pre);
            res = Math.Min(res, begin+dur[i]);
        }

        return res;
    }
    public int EarliestFinishTime(int[] landStartTime, int[] landDuration, int[] waterStartTime, int[] waterDuration) {
        int minLand = FindEarliest(landStartTime, landDuration);
        int minWater = FindEarliest(waterStartTime, waterDuration);
        int min12 = FindEarliest(waterStartTime, waterDuration, minLand);
        int min21 = FindEarliest(landStartTime, landDuration, minWater);
        return Math.Min(min12, min21);
    }
}
