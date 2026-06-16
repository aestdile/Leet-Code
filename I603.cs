public class Solution {
    public string ProcessStr(string s) {
        StringBuilder ans=new StringBuilder();
        foreach(char i in s){
            if(i>='a' && i<='z'){
                ans.Append(i);
            }
            else if(i=='*'){
                if(ans.Length!=0)ans.Length--;
            }
            else if(i=='#')ans.Append(ans.ToString());
            else{
                int st=0,ed=ans.Length-1;
                while(st<ed){
                    char temp=ans[st];
                    ans[st]=ans[ed];
                    ans[ed]=temp;
                    st++;
                    ed--;
                }
            }
        }
        return ans.ToString();
    }
}
