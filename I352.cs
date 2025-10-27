public class Solution {
    public int NumberOfBeams(string[] bank) {
        int totalBeams = 0;
        int prevDeviceCount = 0;
        
        foreach (string row in bank) {
            int currentDeviceCount = 0;
            
            foreach (char cell in row) {
                currentDeviceCount += cell & 1; 
            }
            
            if (currentDeviceCount > 0) {
                totalBeams += prevDeviceCount * currentDeviceCount;
                prevDeviceCount = currentDeviceCount;
            }
        }
        
        return totalBeams;
    }
}
