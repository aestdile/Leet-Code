public class Solution{
    public int MinDeletionSize(string[] strs){
        int res = 0;
        for (int i = 0; i < strs[0].Length; i++){
            var col = strs.Select(s => s[i]);
            if (!col.OrderBy(c => c).SequenceEqual(col)) res++;
        }
        return res;
    }
}
