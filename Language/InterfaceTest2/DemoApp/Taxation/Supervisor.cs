namespace Taxation;

public struct Supervisor : ITaxPayer
{
    public int Subordinates { get; set; }

    public decimal AnnualIncome()
    {
        return 500000 + 3000 * Subordinates;
    }
}
