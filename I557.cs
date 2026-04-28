public class Solution {
    public int MinOperations(int[][] grid, int x) {
  List<int> nums = new List<int>();
  foreach(var row in grid){
    foreach(var num in row){
        nums.Add(num);
    }
  }

int remainder = nums[0] % x;

foreach(var num in nums){
    if( num % x != remainder ) return -1;
}

nums.Sort();
int med  = nums[nums.Count /2];
int count = 0;

foreach(var num in nums){
count += Math.Abs(num - med)/x;
}

return count;


    }
}
