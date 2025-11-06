public class Solution {
        public class UnionFind{
            public UnionFind(int size){
                parent = new int[size + 1];
                for (var i = 0; i <= size; i++){
                    parent[i] = i;
                }
            }

            private int[] parent;
            public int Find(int x){
                if (parent[x] != x)
                    parent[x] = Find(parent[x]);
                return parent[x];
            }

            public void Union(int x, int y){
                var px = Find(x);
                var py = Find(y);
                if (px != py){
                    if (px < py)
                        parent[py] = px;
                    else
                        parent[px] = py;

                }
            }
        }

        public int[] ProcessQueries(int c, int[][] connections, int[][] queries){
            var uf = new UnionFind(c);

            foreach (var connection in connections){
                uf.Union(connection[0], connection[1]);
            }

            var connectedNodeDic = new Dictionary<int, SortedSet<int>>();
            var onlines = new bool[c + 1];

            for (var i = 1; i <= c; i++){
                var p = uf.Find(i);
                if (!connectedNodeDic.ContainsKey(p))
                    connectedNodeDic[p] = new SortedSet<int>();
                connectedNodeDic[p].Add(i);
                onlines[i] = true;
            }

            var result = new List<int>();

            foreach (var querie in queries){
                var type = querie[0];
                var x = querie[1];
                var p = uf.Find(x);

                if (type == 2){
                    if (onlines[x]){
                        onlines[x] = false;
                        connectedNodeDic[p].Remove(x);
                    }
                }
                else if (type == 1){
                    if (onlines[x]){
                        result.Add(x);
                    }
                    else{
                        if (connectedNodeDic[p].Count == 0)
                            result.Add(-1);
                        else
                            result.Add(connectedNodeDic[p].Min);
                    }
                }
            }

            return result.ToArray();
        }
}
