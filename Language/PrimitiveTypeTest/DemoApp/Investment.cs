using System;

class Investment
{
    //an optional parameter (risk) is defined with a constant expression as its initializer
    //and such a parameter can only appear after all the required parameters 
    public static double FutureValue(double installment, int years, bool risk = false)
    {
        double i = risk ? 0.08 : 0.06;
        return (installment / i) * (Math.Pow(1 + i, years) - 1);
    }
}