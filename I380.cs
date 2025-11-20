public class Solution {
    public int IntersectionSizeTwo(int[][] intervals) {
        Array.Sort(intervals, (a, b) => {
            if (a[1] == b[1])
                return b[0] - a[0];

            return a[1] - b[1];
        });

        List<int> list = new List<int>
        {
            intervals[0][1] - 1,
            intervals[0][1]
        };

        for (int i = 1; i < intervals.Length; i++) {
            int[] interval = intervals[i];
            int start = interval[0];
            int end = interval[1];

            int lastOne = list[list.Count - 1];
            int lastTwo = list[list.Count - 2];

            if (start > lastOne) {
                list.Add(end - 1);
                list.Add(end);
            }
            else if (start == lastOne || start > lastTwo) 
                list.Add(end);
        }

        return list.Count;
    }
}