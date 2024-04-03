namespace Taxation;

//a struct declared with 'readonly' keyword produces
//immutable values (state of its instance cannot be
//modified after it is initialized)
public readonly struct Worker : ITaxPayer
{
    //init-only property can only be set in the initializer statement
    public int Jobs { get; init; }

    public decimal AnnualIncome()
    {
        return 200000 + 500 * Jobs;
    }
}
