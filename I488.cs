public class Solution {
        public bool HasAlternatingBits(int n)
        {
            var x = n ^(n>>1);
            return (x&(x+1))==0;
        }
}
