public class Solution {
    public int FurthestDistanceFromOrigin(string moves) {
        int total = 0;
        int free = 0;

        foreach(char c in moves){
            if (c == 'L') total--;
            if (c == 'R') total++;
            if (c == '_') free++;
        }

        return Math.Abs(total) + free;
    }
}
