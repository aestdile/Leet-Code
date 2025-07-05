public class Solution {
    public int Trap(int[] height) {
        int sum = 0;
        int e = height.Length -1;
        int s = 0;
        int smax = 0;
        int emax = 0;

        while(s < e){
            if(height[s] < height[e]){
                if(height[s] > smax){
                    smax = height[s];
                }else{
                    sum += smax - height[s];
                }
                s++;
            }else{
                if(height[e] > emax){
                    emax = height[e];
                }else{
                    sum += emax - height[e];
                }
                e--;
            }
        }
        return sum;
    }
}
