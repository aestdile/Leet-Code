public class Solution {
    public int NumWaterBottles(int numBottles, int numExchange) {
        if (numBottles < numExchange) {
            return numBottles;
        }
        return numBottles + (numBottles - 1) / (numExchange -1);
    }
}
