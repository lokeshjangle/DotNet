namespace Banking;

sealed class CurrentAccount : Account
{
    public override void Deposit(double amount)
    {
        Balance += amount;
    }

    public override void Withdraw(double amount)
    {
        Balance -= amount;
    }
}