public class Solution {
    public int[] CountMentions(int numberOfUsers, IList<IList<string>> events) {
        int[] stat =new int[numberOfUsers];
        int[] ans =new int[numberOfUsers];
        IList<IList<string>> eventss = events.OrderBy(innerList => int.Parse(innerList[1])).ThenByDescending(innerList =>(innerList[0])).ToList();
        foreach (IList<string> eventt in eventss){
            if (eventt[0]=="OFFLINE"){
                stat[int.Parse(eventt[2])] = int.Parse(eventt[1])+60;
            }
            else{
                if (eventt[2] =="ALL"){
                    for(int i =0; i<numberOfUsers;i++){
                        ans[i]++;
                    }
                }
                if (eventt[2]=="HERE"){
                    for (int i = 0; i <numberOfUsers;i++){
                        if (int.Parse(eventt[1])>=stat[i]){
                            ans[i]++;
                        }
                    }
                }
                if (eventt[2][0]=='i'){
                    string[] ids = eventt[2].Split(' ');
                    foreach (string idd in ids){
                        int pos = int.Parse((idd.Substring(2)));
                        ans[pos]++;
                    }
                }
                
            }
        }
        return ans;

    }
}
