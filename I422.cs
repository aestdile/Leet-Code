public class Solution {
    public int NumberOfWays(string corridor) {
        Stack<int> stack= new();
        long ways=1;

        for(int i=0;i<corridor.Length;i++){
            if(corridor[i]=='S'){
                if(stack.Count>0&&stack.Count%2==0){
                 int curr=i-stack.Peek() ;
                 ways*=curr;
                 ways=ways%1000000007;  
                }
                stack.Push(i);
            }
        }
        return (stack.Count>0&&stack.Count%2==0)?(int)ways:0;
    }
}
