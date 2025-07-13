public class Solution {
    public int MatchPlayersAndTrainers(int[] players, int[] trainers) {
        int n = players.Length;
        int m = trainers.Length;

        Array.Sort(players);
        Array.Sort(trainers);

        int i = 0;
        int j = 0;
        int cnt = 0;

        while(i < n && j < m)
        {
            if(trainers[j] >= players[i])
            {
                cnt++;
                i++;
                j++;
            }
            else
            {
                j++;
            }
        }
        return cnt;
    }
}
