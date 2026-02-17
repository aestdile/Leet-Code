public class Solution
{
    public IList<string> ReadBinaryWatch(int turnedOn) =>
    [..
        from h in Enumerable.Range(0, 12)
        from m in Enumerable.Range(0, 60)
        where int.PopCount(h << 6 | m) == turnedOn
        select $"{h}:{m:d2}"
    ];
}
