public class Solution {
    public IList<string> RemoveComments(string[] source) {
        var result = new List<string>();
        bool inBlock = false;
        var newLine = new StringBuilder();

        foreach (string line in source) {
            int i = 0;
            if (!inBlock) newLine.Clear();
            while (i < line.Length) {
                if (!inBlock && i + 1 < line.Length && line[i] == '/' && line[i + 1] == '*') {
                    inBlock = true;
                    i++;
                } else if (inBlock && i + 1 < line.Length && line[i] == '*' && line[i + 1] == '/') {
                    inBlock = false;
                    i++;
                } else if (!inBlock && i + 1 < line.Length && line[i] == '/' && line[i + 1] == '/') {
                    break;
                } else if (!inBlock) {
                    newLine.Append(line[i]);
                }
                i++;
            }
            if (!inBlock && newLine.Length > 0) {
                result.Add(newLine.ToString());
            }
        }
        return result;
    }
}
