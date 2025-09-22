public class MovieRentingSystem {
    Dictionary<int,SortedSet<(int shop,int price)>> unrentedMap;
    SortedSet<(int shop, int movie,int price)> rentedSet;
    Dictionary<(int shop, int movie),int> map;
    public MovieRentingSystem(int n, int[][] entries) {
        unrentedMap = new Dictionary<int,SortedSet<(int shop,int price)>>();
        
        rentedSet = new SortedSet<(int shop, int movie,int price)>(
            Comparer<(int shop, int movie,int price)>.Create((a, b) =>
            {
                int cmp = a.price.CompareTo(b.price);
                if (cmp == 0){
                    int shopCompare = a.shop.CompareTo(b.shop);
                    if(shopCompare == 0)
                        return a.movie.CompareTo(b.movie);;
                    return shopCompare;
                }
                return cmp;
            })
        );
        map = new Dictionary<(int shop, int movie),int>();
        foreach(var e in entries){
            (int shop, int movie,int price) = (e[0],e[1],e[2]);
            if(!unrentedMap.ContainsKey(movie)){
                unrentedMap[movie] = new SortedSet<(int shop,int price)>(
                    Comparer<(int shop,int price)>.Create((a, b) =>
                    {
                        int cmp = a.price.CompareTo(b.price);
                        if (cmp == 0)
                            return a.shop.CompareTo(b.shop);
                        return cmp;
                    })
                );
            }
            unrentedMap[movie].Add((shop,price));
            map[(shop,movie)] = price;
        }
    }
    
    public IList<int> Search(int movie) {
        List<int> res = new();
        if(!unrentedMap.ContainsKey(movie)) return res;
        foreach (var record in unrentedMap[movie]){
            if(res.Count >= 5) break;
            res.Add(record.shop);
        }
        return res;
    }
    
    public void Rent(int shop, int movie) {
        var price = map[(shop,movie)];
        rentedSet.Add((shop,movie,price));
        unrentedMap[movie].Remove((shop,price));
    }
    
    public void Drop(int shop, int movie) {
        var price = map[(shop,movie)];
        unrentedMap[movie].Add((shop,price));
        rentedSet.Remove((shop,movie,price));
    }
    
    public IList<IList<int>> Report() {
        IList<IList<int>> res = new List<IList<int>>();
        foreach (var record in rentedSet){
            if(res.Count >= 5) break;
            res.Add(new List<int>(){record.shop,record.movie});
        }
        return res;
    }
}