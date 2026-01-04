public class Solution {
    public int SumFourDivisors(int[] nums) {
        int max = nums.Max();
        int sum = 0;

        foreach(var num in nums){
            HashSet<int> divisors = new();
            var sqrt = Math.Sqrt(num);

            for(int i=1; i<=sqrt; i++){
                int divisor = num/i;

                if(num%i == 0){
                    divisors.Add(i);
                    divisors.Add(divisor);
                }
            }

            if(divisors.Count == 4){
                foreach(var div in divisors){
                    sum += div;
                }
            }
        }

        return sum;
    }

    private HashSet<int> GetPrimes(int max){
        HashSet<int> primes = new();
        var isPrime = new bool[max+1];
        Array.Fill(isPrime, true);

        for(int i=2; i<=max; i++){
            if(!isPrime[i]){
                continue;
            }

            primes.Add(i);

            for(int j=i*2; j <= max; j+=i){
                isPrime[j] = false;
            }
        }

        return primes;
    }
}
