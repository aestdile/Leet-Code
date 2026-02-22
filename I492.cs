public class Solution {
    public int BinaryGap(int n) {
        List<int> list = new List<int>();
        int index=0;
        while(n!=0){
            if((n&1)==1) list.Add(index);
            n>>=1;
            index++; 
        }
        if(list.Count<=1) return 0;
        int maxDiff=list[1]-list[0];
        for(int i=1; i<list.Count-1; i++){
            if(list[i+1]-list[i]>maxDiff) maxDiff=list[i+1]-list[i];
        }
        return maxDiff;
    }
}
