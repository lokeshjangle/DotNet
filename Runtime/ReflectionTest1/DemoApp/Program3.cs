using Finance;
using System.Reflection;

delegate double RateFunc(double amount, int period);

class Program
{
    public static void Main(string[] args)
    {
        double p = double.Parse(args[0]);
        Type t = Type.GetType(args[1], true); 
        object policy = Activator.CreateInstance(t);
        MethodInfo mi = t.GetMethod(args[2]); //t.GetMethod(args[2], new Type[]{typeof(double), typeof(int)});
        RateFunc scheme = mi.CreateDelegate<RateFunc>(policy);
        int m = 10;
        for(int n = 1; n <= m; ++n)
        {
            double r = scheme(p, n); //scheme.Invoke(p, n);
            double emi = Loans.GetMonthlyInstallment(p, n, r);
            Console.WriteLine("{0, -6}{1, 16:0.00}", n, emi);
        }
    }
}
