public class Solution {
    public int CountCollisions(string directions) =>
        directions.TrimStart('L').TrimEnd('R').Count(c => c != 'S');   
}
