public class Solution {
    public int MinSwaps(int[][] grid) {
        List<int> ids = new();
        int m = grid.Length, n = grid[0].Length;

        for(int i = 0; i < m; i++)
        {
            bool findOne = false;
            for(int j = n-1; j >= 0; j--)
            {
                int cur = grid[i][j];
                if(cur == 1)
                {
                    findOne = true;
                    ids.Add(j);
                    break;
                }
            }

            if(!findOne)
                ids.Add(0);
        }

        int res = 0;
        for(int i = 0; i < m-1; i++)
        {
            int id = ids[i];

            if(id > i)
            {
                int nextId = i+1;
                while(nextId < m && ids[nextId] > i)
                {
                    nextId++;
                }

                if(nextId >= m)
                    return -1;

                res += (nextId-i);

                for(int j = nextId; j > i; j--)
                {
                    int tmp = ids[j-1];
                    ids[j-1] = ids[j];
                    ids[j] = tmp;
                }
            }
        }

        return res;
    }
}
