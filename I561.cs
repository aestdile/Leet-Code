public class Solution {

    public int RotatedDigits(int n) {
        return Enumerable.Range(1, n).Select(x => x.ToString()).
            Count(x => x.Count(a => a == '3'||a == '4'||a == '7') == 0 &&
                       x.Count(a => a == '2'||a == '5'||a == '6'||a == '9') != 0);
    }
}
