public class Solution {
    public bool CanReach(int[] arr, int start) {
        
        Stack<int> s = new Stack<int>();
        bool[] visited = new bool[arr.Length];

        s.Push(start);

        while (s.Count > 0) {

            int curr = s.Pop();

            if (visited[curr])
                continue;

            visited[curr] = true;

            if (arr[curr] == 0)
                return true;

            int forward = curr + arr[curr];
            int backward = curr - arr[curr];

            if (forward >= 0 && forward < arr.Length)
                s.Push(forward);

            if (backward >= 0 && backward < arr.Length)
                s.Push(backward);
        }

        return false;
    }
}
