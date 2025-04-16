public class Solution {
    public int FindClosest(int x, int y, int z) {
        int dist1 = Math.Abs(x - z); 
        int dist2 = Math.Abs(y - z); 

        if (dist1 < dist2)
            return 1;
        else if (dist2 < dist1)
            return 2;
        else
            return 0; 
    }
}
