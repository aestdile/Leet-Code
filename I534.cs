public class Solution {
    public bool JudgeCircle(string moves) {
        return moves.Count(x => x == 'L') == moves.Count(x => x == 'R')
            && moves.Count(x => x == 'U') == moves.Count(x => x == 'D');
    }
}
