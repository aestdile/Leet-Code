public class Solution {
    public IList<string> RemoveSubfolders(string[] folder) {
        Array.Sort(folder);
        var list = new List<string>();
        list.Add(folder[0]);

        for (int i = 1; i < folder.Length; i++)
        {
            int m = list[^1].Length;
            int n = folder[i].Length;
            if (m >= n || 
                !(list[^1].Equals(folder[i].Substring(0, m)) 
                  && folder[i][m] == '/'))
                list.Add(folder[i]);
        }
        
        return list;
    }
}
