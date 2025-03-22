public class Solution {
    public int HammingWeight(int n) {
        if (n==0) return 0;
        int s=0;
        while(n!=0)
        {
            int ones=n%2;
            if(ones==1)
            {
                s+=ones;
            }
            n/=2;
        }
        return s;
    }
}
