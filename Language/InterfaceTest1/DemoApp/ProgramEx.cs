//The definition of a type declared with 'partial' keyword 
//can be split across multiple source files. It is commonly
//used when one part of type definition is auto-generated and
//other part is coded explicitly
using Banking;

partial class Program
{

    private static void PayAnnualInterest(Account[] accounts)
    {
        foreach(Account acc in accounts)
        {
            /*
            if(acc is IProfitable p)
            {
                //IProfitable p = (IProfitable)acc;
                p.AddInterest(12);
            }
            */
            IProfitable p = acc as IProfitable;
            p?.AddInterest(12);//if(p != null) p.AddInterest(12);
        }
    }
}