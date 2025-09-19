public class Solution {
    public int TitleToNumber(string columnTitle) {
        int result = 0;
        int mpl = 1;
        for (int i = columnTitle.Length - 1; i >= 0; --i){
            result += (int)(columnTitle[i] - 'A' + 1) * mpl;
            mpl *= 26;
        }

        return result;
    }
}
