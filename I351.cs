public class Bank {
    private readonly long[] _balance;
    private readonly int n;
    public Bank(long[] balance) {
        _balance=balance;
        n=balance.Length;
    }
    
    public bool Transfer(int account1, int account2, long money) {
        if(account1<1||account1>n||
            account2<1||account2>n||
            _balance[account1-1]<money) return false;
        _balance[account1-1]-=money;
        _balance[account2-1]+=money;
        return true;
    }
    
    public bool Deposit(int account, long money) {
        if(account<1||account>n) return false;
        _balance[account-1]+=money;
        return true;
    }
    
    public bool Withdraw(int account, long money) {
        if(account<1||account>n||_balance[account-1]<money) return false;
        _balance[account-1]-=money;
        return true;
    }
}
