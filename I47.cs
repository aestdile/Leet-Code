public class Solution {
    public bool CheckIfExist(int[] arr) {
        HashSet<int> set = new HashSet<int>();
        foreach (int num in arr) {
            if (set.Contains(2 * num) || (num % 2 == 0 && set.Contains(num / 2))) {
                return true;
            }
            set.Add(num);
        }
        return false;
    }
}
