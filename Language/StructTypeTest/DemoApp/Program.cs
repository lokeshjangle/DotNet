global using System;

class Program
{
	//a parameter declared with 'ref' keyword receives address
	//of argument instead of a copy of its value
	private static void Advise(ref Investment inv)
	{
		inv.AllowRisk(inv.TotalPayment() < 500000);
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
		Advise(ref myinv); //passing address of myinv
		Console.WriteLine("Future value in smart investment    : {0:0.00}", myinv.FutureValue());
	}
}


