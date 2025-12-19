public class Solution {
    public IList<int> FindAllPeople(int n, int[][] meetings, int firstPerson) {
        Array.Sort(meetings, (a, b) => a[2].CompareTo(b[2]));

        bool[] knows = new bool[n];
        knows[0] = true;
        knows[firstPerson] = true;

        UnionFind uf = new UnionFind(n);

        int i = 0;
        while (i < meetings.Length) {
            int time = meetings[i][2];
            List<int> participants = new List<int>();

            while (i < meetings.Length && meetings[i][2] == time) {
                int x = meetings[i][0];
                int y = meetings[i][1];
                uf.Union(x, y);
                participants.Add(x);
                participants.Add(y);
                i++;
            }

            HashSet<int> secretRoots = new HashSet<int>();
            foreach (int p in participants) {
                if (knows[p]) {
                    secretRoots.Add(uf.Find(p));
                }
            }

            foreach (int p in participants) {
                if (secretRoots.Contains(uf.Find(p))) {
                    knows[p] = true;
                }
            }

            foreach (int p in participants) {
                uf.Reset(p);
            }
        }

        List<int> result = new List<int>();
        for (int p = 0; p < n; p++) {
            if (knows[p]) {
                result.Add(p);
            }
        }

        return result;
    }
    private class UnionFind {
        private int[] parent;

        public UnionFind(int n) {
            parent = new int[n];
            for (int i = 0; i < n; i++) {
                parent[i] = i;
            }
        }

        public int Find(int x) {
            if (parent[x] != x) {
                parent[x] = Find(parent[x]);
            }
            return parent[x];
        }

        public void Union(int x, int y) {
            int rx = Find(x);
            int ry = Find(y);
            if (rx != ry) {
                parent[ry] = rx;
            }
        }

        public void Reset(int x) {
            parent[x] = x;
        }
    }
}
