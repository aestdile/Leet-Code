public class Solution {
    long[] spf;
    Dictionary<long,List<long>> map;
    
    public void PrimeFactorization(int ind ,int num,SortedSet<int> nums)
    {
        while(num>1)
        {
            int x=(int)spf[num];

            if(nums.Contains(x))
            {
                if(map.ContainsKey(x))
                {
                    map[x].Add(ind);
                }
                else
                {
                    map.Add(x,new List<long>(){ind});
                }
            }
            num/=x;
          
        }
    }

    public void Sieve(long max)
    {
        long n=max;
        spf=new long[n+1];
        spf[1]=1;
        
        for(long i=2;i<=n;i++)
        {
            if(spf[i]!=0)
            {
                continue;
            }
            
            spf[i]=i;
           
            for(long j=i*i;j<=n;j+=i)
            {
                
                if(spf[j]==0)
                {
                    spf[j]=i;
                }
            }
            
        }
    }
    
    public int MinJumps(int[] nums) 
    {
        int n=nums.Length;
        map=new Dictionary<long,List<long>>();

        if(n==1)
        {
            return 0;
        }

        long max=long.MinValue;
        SortedSet<int> lstNums=new SortedSet<int>(nums);
        
        Sieve(lstNums.Max);
       

        for(int i=0;i<nums.Length;i++)
        {
            PrimeFactorization(i,nums[i],lstNums);   
        }

        Queue<long> qu=new Queue<long>();    
        HashSet<long> visited=new HashSet<long>();
        qu.Enqueue(0);
        
        int ans=0;
        while(qu.Count>0)
        {
            int size=qu.Count;
            while(size>0)
            {
                long currNode=qu.Peek();
                
                qu.Dequeue();
                size--;

                if(currNode==n-1)
                {
                    return ans;
                }

                long num=nums[currNode];
                
                if(map.ContainsKey(num))
                {
                   foreach(long neiNode in map[num])
                   {
                    if(visited.Contains(neiNode) || neiNode==currNode)
                    {
                        continue;
                    }
                    qu.Enqueue(neiNode);
                    visited.Add(neiNode);
                   }
                   map.Remove(num);
                }
                
                
                if(currNode+1<n &&  !visited.Contains(currNode+1))
                {
                    qu.Enqueue(currNode+1);
                    visited.Add(currNode+1);
                }
                
                   
                if(currNode-1>=0 && !visited.Contains(currNode-1))
                {
                    qu.Enqueue(currNode-1);
                    visited.Add(currNode-1);
                }
            }
            ans++;
        }
        
        return -1;
    }
}
