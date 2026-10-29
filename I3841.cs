class Solution:
    def palindromePath(self, n, edges, s, queries):
        from collections import defaultdict
        g = defaultdict(list)
        for u, v in edges:
            g[u].append(v)
            g[v].append(u)

        LOG = n.bit_length()
        up = [[0]*n for _ in range(LOG)]
        tin, tout, depth = [0]*n, [0]*n, [0]*n
        timer = 0

        def dfs(u, p):
            nonlocal timer
            tin[u] = timer
            timer += 1
            up[0][u] = p
            for v in g[u]:
                if v != p:
                    depth[v] = depth[u]+1
                    dfs(v, u)
            tout[u] = timer

        dfs(0, 0)
        for k in range(1, LOG):
            for u in range(n):
                up[k][u] = up[k-1][up[k-1][u]]

        bit = [0]*(n+2)

        def add(i, x):
            i += 1
            while i < len(bit):
                bit[i] ^= x
                i += i & -i

        def get(i):
            x = 0
            i += 1
            while i:
                x ^= bit[i]
                i -= i & -i
            return x

        cur = [1 << (ord(c)-97) for c in s]
        for u in range(n):
            add(tin[u], cur[u])
            add(tout[u], cur[u])

        def lca(u, v):
            if depth[u] < depth[v]:
                u, v = v, u
            d = depth[u]-depth[v]
            for k in range(LOG):
                if d >> k & 1:
                    u = up[k][u]
            if u == v:
                return u
            for k in range(LOG-1, -1, -1):
                if up[k][u] != up[k][v]:
                    u, v = up[k][u], up[k][v]
            return up[0][u]

        ans = []
        for q in queries:
            t = q.split()
            u = int(t[1])
            if t[0] == "update":
                x = 1 << (ord(t[2])-97)
                d = cur[u] ^ x
                add(tin[u], d)
                add(tout[u], d)
                cur[u] = x
            else:
                v = int(t[2])
                a = lca(u, v)
                mask = get(tin[u]) ^ get(tin[v]) ^ cur[a]
                ans.append(mask & (mask-1) == 0)
        return ans
