public class FindSumPairs
{
    private readonly int[] _nums1;
    private readonly int[] _nums2;
    private readonly Dictionary<int, int> _frequencies = [];

    public FindSumPairs(int[] nums1, int[] nums2)
    {
        _nums1 = nums1;
        _nums2 = nums2;
        foreach (var x in nums2)
        {
            ChangeFrequency(x, 1);
        }
    }

    public void Add(int index, int val)
    {
        ChangeFrequency(_nums2[index], -1);
        _nums2[index] += val;
        ChangeFrequency(_nums2[index], 1);
    }

    public int Count(int total)
    {
        var result = 0;

        foreach (var n in _nums1)
        {
            if (_frequencies.TryGetValue(total - n, out var count))
            {
                result += count;
            }
        }

        return result;
    }

    private void ChangeFrequency(int key, int value)
    {
        if (_frequencies.ContainsKey(key))
        {
            _frequencies[key] += value;
            if (_frequencies[key] == 0)
            {
                _frequencies.Remove(key);
            }
        }
        else if (value > 0)
        {
            _frequencies[key] = value;
        }
    }
}
