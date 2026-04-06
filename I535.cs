public class Solution {
    public int RobotSim(int[] commands, int[][] obstacles) {
        // Define direction vectors for North, East, South, West
        int[,] directions = new int[,] { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };
        
        // Map obstacles into a Dictionary for O(1) lookups
        var obstacleMap = new Dictionary<(int, int), bool>();
        foreach (var obstacle in obstacles) {
            obstacleMap[(obstacle[0], obstacle[1])] = true;
        }

        int x = 0, y = 0;  // Initial position of the robot
        int directionIndex = 0;  // Starting direction (North)
        int maxDistance = 0;  // To track the maximum distance squared

        foreach (var command in commands) {
            if (command == -1) {
                // Turn right: Increase the direction index
                directionIndex = (directionIndex + 1) % 4;
            } else if (command == -2) {
                // Turn left: Decrease the direction index
                directionIndex = (directionIndex + 3) % 4;
            } else {
                // Move forward by command units
                for (int i = 0; i < command; i++) {
                    int nextX = x + directions[directionIndex, 0];
                    int nextY = y + directions[directionIndex, 1];

                    // Check if next position is an obstacle
                    if (!obstacleMap.ContainsKey((nextX, nextY))) {
                        x = nextX;
                        y = nextY;
                        maxDistance = Math.Max(maxDistance, x * x + y * y);
                    } else {
                        break;  // Stop moving in this direction if an obstacle is encountered
                    }
                }
            }
        }

        return maxDistance;
    }
}
