public class Solution {
    public int MinJumps(int[] arr) {
        int len = arr.Length, step = 0;
        bool[] visited = new bool[len];
        HashSet<int> dist = new HashSet<int>(arr);
        if(dist.Count == len)
            return len-1;

        //Build duplimicated numbers' value, idx map:
        Dictionary<int, List<int>> dups = new();
        for(int i = 0; i < len; i++)
        {
            int n = arr[i];
            if(!dups.ContainsKey(n))
                dups.Add(n, new List<int>());

            dups[n].Add(i);
        }

        Queue<int> que = new();
        que.Enqueue(0);
        visited[0] = true;

        bool findLast = false;
        while(que.Count > 0)
        {
            int qLen = que.Count;
            for(int i = 0; i < qLen; i++)
            {
                int id = que.Dequeue();
                if(id == len-1)
                    return step;

                int curV = arr[id];
                if(dups.ContainsKey(curV))
                {
                    foreach(int nextId in dups[curV])
                    {
                        if(!visited[nextId])
                        {
                            if(nextId == len-1)
                                findLast = true;

                            visited[nextId] = true;
                            que.Enqueue(nextId);
                        }
                    }

                    dups.Remove(curV);
                }

                if(id > 0 && !visited[id-1])
                {
                    visited[id-1] = true;
                    que.Enqueue(id-1);
                }

                if(id < len-1 && !visited[id+1])
                    que.Enqueue(id+1);
                    if(id+1 == len-1)
                        findLast = true;
            }

            step++;
            if(findLast)
                return step;
        }

        return len-1;
    }
}
