global using System;

class Program
{
	private static void Advise(ref Investment inv)
	{
		inv.AllowRisk(inv.TotalPayment() < 500000);
	}

	//an 'out' parameter is like 'ref' parameter but can accept an
	//uninitialized argument which it must be initialize before the
	//method returne
	private static bool Suggest(int years, out Investment inv)
	{
		if(years <= 3)
		{
			inv = new Investment(80000, years);
			inv.AllowRisk(RiskLevel.High);
			return true;
		}
		if(years <= 5)
		{
			inv = new Investment(60000, years);
			inv.AllowRisk(RiskLevel.Low);
			return true;
		}
		if(years <= 10)
		{
			inv = new Investment(25000, years);
			return true;
		}
		inv = new Investment();
		return false;
	}

	public static void Main(string[] args)
	{
		Console.WriteLine("Welcome Investor");
		double p = double.Parse(args[0]);
		int n = int.Parse(args[1]);
		Investment myinv = new Investment(p, n);
		Console.WriteLine("Future value in risk-free investment: {0:0.00}", myinv.FutureValue());
		myinv.AllowRisk(true);
		Console.WriteLine("Future value in low-risk investment : {0:0.00}", myinv.FutureValue());
		Advise(ref myinv);
		Console.WriteLine("Future value in smart investment    : {0:0.00}", myinv.FutureValue());
		myinv.AllowRisk(RiskLevel.High);
		Console.WriteLine("Future value in high-risk investment: {0:0.00}", myinv.FutureValue());
		if(Suggest(n, out Investment aninv))
			Console.WriteLine("Future value in an investment suggested for {0} years: {1:0.00}", n, aninv.FutureValue());
	}
}


