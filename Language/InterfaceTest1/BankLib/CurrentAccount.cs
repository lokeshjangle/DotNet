namespace Banking;

sealed class CurrentAccount : Account, IFineable
{
    public override void Deposit(double amount)
    {
        Balance += amount;
    }

    public override void Withdraw(double amount)
    {
        Balance -= amount;
    }

    //explicit interface implementation
    bool IFineable.Withdraw(double penalty)
    {
        if(Balance < 0)
        {
            Balance -= penalty;
            return true;
        }
        return false;
    }
}