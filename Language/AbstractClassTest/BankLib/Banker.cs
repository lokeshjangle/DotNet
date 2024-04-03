namespace Banking;

//a class declared with 'static' keyword can only define static
//members and as such it does not have an instance constructor 
public static class Banker
{
    private static long nid = DateTime.Now.Ticks % 10000000;

    public static Account OpenCurrentAccount()
    {
        var acc = new CurrentAccount(); //type inference: var = CurrentAccount
        acc.Id = ++nid + 100000000;
        return acc;
    }

    public static Account OpenSavingsAccount()
    {
        SavingsAccount acc = new();
        acc.Id = ++nid + 200000000;
        return acc;
    }

    //An extension method is a member of a static class whose first parameter
    //is declared with 'this' keyword. Such a method can be called as an
    //instance method of its first parameter type in any scope within which
    //its class is accessible without namespace qualification
    public static void FreezeAccount(this Account acc)
    {
        acc.Id = -acc.Id;
    }
}
