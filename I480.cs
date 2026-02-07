public class Solution {
    public int MinimumDeletions(string s) {
        int n=s.Length,j=n-1;
        int[] count_a=new int[n];
        int[] count_b=new int[n];
        int b_count=0,a_count=0;
        for(int i=0;i<n;i++)
        {
            count_b[i]=b_count;
            count_a[j]=a_count;
            if(s[i]=='b')b_count++;
            if(s[j]=='a')a_count++;
            j--;
        }
        int minDeletion=n;
        for(int i=0;i<n;i++)
        {
            minDeletion=Math.Min(minDeletion,count_a[i]+count_b[i]);
        }
        return minDeletion;
    }
}
