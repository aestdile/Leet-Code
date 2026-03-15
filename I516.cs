public class Fancy {
    private const int MOD = 1000000007;
    private List<long> sequence;
    private long add;
    private long mult;

    public Fancy() {
        sequence = new List<long>();
        add = 0;
        mult = 1;
    }
    
    public void Append(int val) {
        long newVal = (val - add + MOD) % MOD;
        newVal = (newVal * Inverse(mult)) % MOD;
        sequence.Add(newVal);
    }
    
    public void AddAll(int inc) {
        add = (add + inc) % MOD;
    }
    
    public void MultAll(int m) {
        add = (add * m) % MOD;
        mult = (mult * m) % MOD;
    }
    
    public int GetIndex(int idx) {
        if (idx >= sequence.Count)
            return -1;
        
        long val = (sequence[idx] * mult) % MOD;
        val = (val + add) % MOD;
        return (int)val;
    }

    private long Inverse(long x) {
        long result = 1;
        long power = MOD - 2;
        while (power > 0) {
            if (power % 2 == 1) {
                result = (result * x) % MOD;
            }
            x = (x * x) % MOD;
            power /= 2;
        }
        return result;
    }
}
