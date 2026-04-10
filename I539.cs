public class Solution 
{
    public int MinimumDistance(int[] nums) 
    {
        var count = 3;
        var map = new Dictionary<int, LinkedList<int>>();
        var result = int.MaxValue;

        for (var i = 0; i < nums.Length; i++)
        {
            if (!map.TryGetValue(nums[i], out var list))
            {
                var newList = new LinkedList<int>();
                newList.AddLast(i);
                map.Add(nums[i], newList);
            }
            else
            {
                list.AddLast(i);

                if (list.Count > count)
                    list.RemoveFirst();

                if (list.Count == count)
                {
                    var dist = (list.Last.Value - list.First.Value) * 2;
                    result = Math.Min(result, dist);
                }
            }
        }

        return result == int.MaxValue ? -1 : result;
    }
}
