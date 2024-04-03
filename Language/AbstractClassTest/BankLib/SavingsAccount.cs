namespace Banking;

sealed class SavingsAccount : Account
{
    //a constant is replaced by its initializer where ever
    //it occurs
    const double MinimumBalance = 5000; 
    //static readonly double MinimumBalance = 5000;

    internal SavingsAccount()
    {
        Balance = MinimumBalance;
    }

    public override void Deposit(double amount)
    {
        Balance += amount;
    }

    public override void Withdraw(double amount)
    {
        if(Balance - amount < MinimumBalance)
            throw new InsufficientFundsException();
        Balance -= amount;
    }
}