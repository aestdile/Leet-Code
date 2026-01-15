public class Solution {
    public int MaximizeSquareHoleArea(int n, int m, int[] hBars, int[] vBars) {
        Array.Sort(hBars);
        Array.Sort(vBars);
        int k=1;
        int v=1;
        int h=1;
        if(hBars.Length>0) h++;
        if(vBars.Length>0) v++;
        for (int i=0; i< hBars.Length; i+=k){
            k=1;
            while(i+k<hBars.Length && hBars[i+k]-hBars[i+k-1]==1){
                k++;
            }
            h=Math.Max(h,k+1);
        }       
        for (int i=0; i< vBars.Length; i+=k){
            k=1;
            while(i+k<vBars.Length && vBars[i+k]-vBars[i+k-1]==1){
                k++;
            }
            v=Math.Max(v,k+1);
        }   
        int l=Math.Min(v,h);
        return l*l;    
    }
}
