public class Router {
    int memoryLimit;
    Queue<int[]> queue;
    HashSet<string> hashSet;
    Dictionary<int, IList<int>> timeStampsMap;

    public Router(int memoryLimit) {
        this.memoryLimit = memoryLimit;
        queue = new();
        hashSet = new();
        timeStampsMap = new();
    }
    
    public bool AddPacket(int source, int destination, int timestamp) {
        int[] packet = new int[3] { source, destination, timestamp };
        string packetString = $"{source} - {destination} - {timestamp}";
        //Console.WriteLine($"Inside Add => {packetString}");

        if(hashSet.Contains(packetString)) return false;

        if(hashSet.Count >= memoryLimit) {
            var top = queue.Dequeue();
            string topPacketString = $"{top[0]} - {top[1]} - {top[2]}";
            hashSet.Remove(topPacketString);
            timeStampsMap[top[1]].RemoveAt(0);
        }

        if(!timeStampsMap.ContainsKey(destination)){
            timeStampsMap.Add(destination, new List<int>());
        }

        timeStampsMap[destination].Add(timestamp);
        queue.Enqueue(packet);
        hashSet.Add(packetString);
        return true;
    }
    
    public int[] ForwardPacket() {
        if(queue.Count == 0) return new int[0];

        //Console.WriteLine($"count=>{queue.Count}, hashSet.Count={hashSet.Count}");
        var top = queue.Dequeue();
        string packetString = $"{top[0]} - {top[1]} - {top[2]}";
        //Console.WriteLine($"Inside Forward => {packetString}");
        hashSet.Remove(packetString);
        timeStampsMap[top[1]].RemoveAt(0);
        return top;
    }
    
    public int GetCount(int destination, int startTime, int endTime) {
        if(!timeStampsMap.ContainsKey(destination)) return 0;

        int lowerBound = GetLowerBound(timeStampsMap[destination], startTime);
        int upperBound = GetUpperBound(timeStampsMap[destination], endTime);        
        
        Console.WriteLine($"lowerBound={lowerBound}, upperBound={upperBound}");

        if(lowerBound <= upperBound)
            return upperBound - lowerBound + 1;
        
        return 0;
    }

    private int GetLowerBound(IList<int> timeStamps, int time){
        int start = 0, end = timeStamps.Count - 1, lb = end + 1;

        while(start <= end){
            int mid = (start + end)/2;

            if(timeStamps[mid] >= time){
                lb = mid;
                end = mid-1;
            }
            else{
                start = mid + 1;
            }
        }

        return lb;
    }

    private int GetUpperBound(IList<int> timeStamps, int time){
        int start = 0, end = timeStamps.Count - 1, ub = -1;

        while(start <= end){

            int mid = (start + end)/2;

            if(timeStamps[mid] <= time){
                ub = mid;
                start = mid + 1;
            }
            else{
                end = mid - 1;
            }
        }

        return ub;
    }
}

/**
 * Your Router object will be instantiated and called as such:
 * Router obj = new Router(memoryLimit);
 * bool param_1 = obj.AddPacket(source,destination,timestamp);
 * int[] param_2 = obj.ForwardPacket();
 * int param_3 = obj.GetCount(destination,startTime,endTime);
 */