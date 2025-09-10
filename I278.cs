public class Solution {
    public int MinimumTeachings(int n, int[][] languages, int[][] friendships) {
        int userN = languages.Length;
        HashSet<int>[] sample = new HashSet<int>[n+1];
        for(int i = 1; i <= n; i++)
        {
            sample[i] = new HashSet<int>();
        }

        for(int i = 0; i < userN; i++)
        {
            int uN = i+1;
            foreach(int l in languages[i])
            {
                sample[l].Add(uN);
            }
        }

        HashSet<int> shouldTeach = new();
        int maxUser = 0;
        foreach(int[] cur in friendships)
        {
            int u = cur[0], v = cur[1];
            HashSet<int> common = new HashSet<int>(languages[u-1]);
            bool hasCommon = false;
            foreach(int adj in languages[v-1])
            {
                if(common.Contains(adj))
                {
                    hasCommon = true;
                    break;
                }
            }
            
            if(!hasCommon)
            {
                shouldTeach.Add(u);
                shouldTeach.Add(v);
            }
        }

        for(int i = 1; i <= n; i++)
        {
            int cont = 0;
            foreach(int cur in sample[i])
            {
                if(shouldTeach.Contains(cur))
                    cont++;
            }
            
            maxUser = Math.Max(maxUser, cont);
        }

        return shouldTeach.Count-maxUser;
    }
}
