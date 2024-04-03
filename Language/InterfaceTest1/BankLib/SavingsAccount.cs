namespace Banking;

sealed class SavingsAccount : Account, IProfitable
{
    const double MinimumBalance = 5000; 

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

    public double AddInterest(int months)
    {
        double rate = Balance < 4 * MinimumBalance ? 3.5 : 4.0;
        double interest = Balance * rate * months / 1200;
        Balance += interest;
        return interest;
    }
}