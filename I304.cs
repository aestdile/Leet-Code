public class Solution {
    public int MinimumTotal(IList<IList<int>> triangle) {
        
        var memo = new Dictionary<(int,int),int>();
        int GetMin(int i, int level){

            if(level == triangle.Count)
                return 0;
            if(memo.ContainsKey((i,level)))
                return memo[(i,level)];
                
            return memo[(i,level)] = Math.Min(triangle[level][i] + GetMin(i,level+1), triangle[level][i+1] + GetMin(i+1,level+1));
        }

        return triangle[0][0] + GetMin(0,1);
    }
}
