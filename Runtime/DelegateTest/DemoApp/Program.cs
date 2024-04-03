class Program 
{
    static double SafeScheme(int y)
    {
        return y < 3 ? 6 : 7.5;
    }

    static void Main()
    {
        Console.Write("Amount to Invest: ");
        double p = double.Parse(Console.ReadLine());
        Console.Write("Number of Years : ");
        int n = int.Parse(Console.ReadLine());
        var myinv = new Investment(p, n);
        Console.WriteLine("Future value of safe investment : {0:0.00}", myinv.FutureValue(SafeScheme));
        //passing lambda expression: body of an anonymous (compiler generated) method 
        Console.WriteLine("Future value of risky investment: {0:0.00}", myinv.FutureValue(y => 9 + 0.25 * y));
    }
}
