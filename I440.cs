public class Solution{
    public int BestClosingTime(string customers) {
        int n= customers.Length;
        int maxCus = 0;
        int cus = 0;
        int bestTime = 0;

        for(int i=0; i<n; i++){
            if(customers[i] == 'Y'){
                cus++;
            }
            else{
                cus--;
            }
            if(cus > maxCus){
                maxCus = cus;
                bestTime = i+1;
            }
        }
        return bestTime;
    }
}
