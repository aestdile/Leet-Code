public class Solution {
    public int MaxBottlesDrunk(int numBottles, int numExchange) {
        int a = 1;
        int b = 2 * numExchange - 3;
        int c = -2 * numBottles;
        double delta = (double)b * b - 4.0 * a * c;
        int t = (int)Math.Ceiling((-b + Math.Sqrt(delta)) / (2.0 * a));
        return numBottles + t - 1;
    }
}
