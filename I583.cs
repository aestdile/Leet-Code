public class Solution {
    public int NumberOfSpecialChars(string word) {
       Dictionary<int,int> a=new Dictionary<int,int>();
       int count=0;
       for(int i=0;i<word.Length;i++)
       {
            if(!a.ContainsKey(word[i]))
            {
                a.Add(word[i],i);
            }
            if(word[i]>=97)
            {
                a[word[i]]=i;
            }
       }
       foreach(var i in a)
       {
            if(a.ContainsKey(i.Key+32))
            {
                int v=a[i.Key+32];
                if(v<i.Value)
                {
                    count++;
                }
            }
       }
       return count;
    }
}
