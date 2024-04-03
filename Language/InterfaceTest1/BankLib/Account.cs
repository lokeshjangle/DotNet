namespace Banking;

public abstract class Account
{
    public long Id { get; internal set; }

    public double Balance { get; protected set; }

    public abstract void Deposit(double amount);

    public abstract void Withdraw(double amount);

    public bool Transfer(double amount, Account that)
    {
        if(ReferenceEquals(this, that))
            return false;
        this.Withdraw(amount);
        that.Deposit(amount);
        return true;
    }
}