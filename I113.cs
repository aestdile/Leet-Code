public class Solution {
    public int MaxCandies(int[] status, int[] candies, int[][] keys, int[][] containedBoxes, int[] initialBoxes) {
        int n = status.Length;
        int totalCandies = 0;
        HashSet<int> unprocessedBoxes = new HashSet<int>();
        HashSet<int> availableKeys = new HashSet<int>();
        Queue<int> queue = new Queue<int>();
        foreach (int box in initialBoxes) {
            if (status[box] == 1) { 
                queue.Enqueue(box);
            } else { 
                unprocessedBoxes.Add(box);
            }
        }
        while (queue.Count > 0) {
            int currentBox = queue.Dequeue();
            totalCandies += candies[currentBox];
            foreach (int key in keys[currentBox]) {
                if (!availableKeys.Contains(key)) {
                    availableKeys.Add(key);
                    if (unprocessedBoxes.Contains(key)) {
                        unprocessedBoxes.Remove(key);
                        queue.Enqueue(key);
                    }
                }
            }
            foreach (int foundBox in containedBoxes[currentBox]) {
                if (status[foundBox] == 1 || availableKeys.Contains(foundBox)) {
                    queue.Enqueue(foundBox);
                } else {
                    unprocessedBoxes.Add(foundBox);
                }
            }
        }
        return totalCandies;
    }
}
