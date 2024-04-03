using Finance;

double p = double.Parse(args[0]);
Type t = Type.GetType(args[1], true); //true = throws exception if type is not found
//static(strict) type-checking is disabled for a variable declared
//with 'dynamic' keyword as its type instead a runtime-binder based
//invocation code is generated for its binding
dynamic policy = Activator.CreateInstance(t);
int m = 10;
for(int n = 1; n <= m; ++n)
{
    double r = policy.Common(p, n); //duck typing
    double emi = Loans.GetMonthlyInstallment(p, n, r);
    Console.WriteLine("{0, -6}{1, 16:0.00}", n, emi);
}
