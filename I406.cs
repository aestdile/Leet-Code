public class Solution {
    public IList<int> GetRow(int rowIndex) {
        List<IList<int>> pt=new List<IList<int>>();
        for(int i=0;i<=rowIndex;i++){
            pt.Add(new List<int>());
            for(int j=0;j<=i;j++){
                if(j==0||j==i){
                    pt[i].Add(1);
                }
                else{
                    pt[i].Add(pt[i-1][j]+pt[i-1][j-1]);
                }
            }
        }
        return pt[rowIndex];
    }
}
