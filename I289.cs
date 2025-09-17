public class FoodRatings {
    Dictionary<string, PriorityQueue<string,(long,string)>> dict;
    Dictionary<string,string> foodToCuisine;
    Dictionary<string,long> foodToRating;

    public FoodRatings(string[] foods, string[] cuisines, int[] ratings) {
        dict = new Dictionary<string, PriorityQueue<string,(long,string)>>();
        foodToCuisine = new Dictionary<string,string>();
        foodToRating = new Dictionary<string,long>();

        for(int i=0;i<foods.Length;i++){
            if(!dict.ContainsKey(cuisines[i]))
                dict[cuisines[i]] = new PriorityQueue<string,(long,string)>();
            dict[cuisines[i]].Enqueue(foods[i],(-1 * ratings[i],foods[i]));

            foodToCuisine[foods[i]] = cuisines[i]; 
            foodToRating[foods[i]] = ratings[i]; 
        }
    }
    
    public void ChangeRating(string food, int newRating) {

        var cuisine = foodToCuisine[food];
        dict[cuisine].Enqueue(food,(-1 * newRating,food));
        foodToRating[food] = newRating;
    }
    
    public string HighestRated(string cuisine) {
        var pq = dict[cuisine];
        while (pq.Count > 0) {
            var food = pq.Peek();
            var (negRating, name) = pq.UnorderedItems.First(x => x.Element == food).Priority;
            long rating = -negRating;
            if (foodToRating[food] == rating) {
                return food;
            }
            pq.Dequeue(); 
        }
        return "";
    }
}

/**
 * Your FoodRatings object will be instantiated and called as such:
 * FoodRatings obj = new FoodRatings(foods, cuisines, ratings);
 * obj.ChangeRating(food,newRating);
 * string param_2 = obj.HighestRated(cuisine);
 */
