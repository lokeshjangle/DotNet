delegate double InterestRate(int period);

class Investment
{
    public double Installment { get; }

    public int Years { get; }

    public Investment(double amount, int count)
    {
        Installment = amount;
        Years = count;
    }

    public double FutureValue(InterestRate rate)
    {
        double i = rate.Invoke(Years) / 100;
        return (Installment / i) * (Math.Pow(1 + i, Years) - 1);
    }
}