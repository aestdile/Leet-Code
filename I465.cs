public class Solution {
    public int MinimumPairRemoval(int[] nums) {
        List<int> list = new List<int>();
        foreach(int n in nums){
            list.Add(n);
        }
        int count = 0;
        while(!Sorted(list)){
            int idx = 0;
            int minSum = int.MaxValue;
            
            // find smallest pair
            for(int i=0;i<list.Count-1;i++)
            {
                int sum = list[i]+list[i+1];
                if(sum<minSum)
                {
                    minSum = sum;
                    idx = i;
                }
            }
            // merge smallest pair
            int merged = list[idx] + list[idx + 1];
            list[idx] = merged;
            list.RemoveAt(idx + 1);
            count++;
        }  
        return count;
    }
     
     //check if list in non decreasing
    private bool Sorted(List<int> list){
        if(list == null || list.Count ==0)
           return true;
        for(int i =1; i < list.Count; i++){
            if(list[i-1] > list[i])
              return false;
        }
        return true;
    }
}
