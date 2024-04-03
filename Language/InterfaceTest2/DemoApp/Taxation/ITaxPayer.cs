namespace Taxation;

public interface ITaxPayer
{
    const decimal Rate = 0.15M;

    decimal AnnualIncome();

    decimal IncomeTax()
    {
        decimal extra = AnnualIncome() - 120000;
        return extra > 0 ? Rate * extra : 0;
    }
}