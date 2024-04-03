using Finance;
using System.Reflection;
using RateFunc = System.Func<double, int, double>;

class Program
{
    public static void Main(string[] args)
    {
        double p = double.Parse(args[0]);
        Type t = Type.GetType($"Finance.{args[1]},FinLib", true); 
        object policy = Activator.CreateInstance(t);
        MethodInfo mi = t.GetMethod(args[2]); 
        RateFunc scheme = mi.CreateDelegate<RateFunc>(policy);
        MaxDurationAttribute md = mi.GetCustomAttribute<MaxDurationAttribute>();
        int m = md?.Limit ?? 10; //md != null ? md.Limit : 10; 
        for(int n = 1; n <= m; ++n)
        {
            double r = scheme(p, n); //scheme.Invoke(p, n);
            double emi = Loans.GetMonthlyInstallment(p, n, r);
            Console.WriteLine("{0, -6}{1, 16:0.00}", n, emi);
        }
    }
}
