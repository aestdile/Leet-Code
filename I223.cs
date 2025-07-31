public class Solution {
    public int SubarrayBitwiseORs(int[] arr) {
        HashSet<int> set1 = new HashSet<int>(), set2 = new HashSet<int>();
        for (int i = 0; i < arr.Length; i++)
        {
            var set3 = new HashSet<int>();
            set3.Add(arr[i]);
            foreach (var item in set2)
                set3.Add(item | arr[i]);
            set2.Clear();
            foreach (var item in set3)
            {
                set2.Add(item);
                set1.Add(item);
            }
        }
        return set1.Count;
    }
}
