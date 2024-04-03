using Payroll;

class Program
{
    private static double Tax(Employee emp)
    {
        double i = emp.Income();
        return i > 10000 ? 0.15 * (i - 10000) : 0;
    }

    private static double Bonus(Employee? emp)
    {
        if(emp is null || emp is SalesPerson)
            return 0;
        return 10 * emp.Hours;
    }

    public static void Main()
    {
        Employee jack = new Employee();
        jack.Hours = 186;
        jack.HourlyRate = 52;
        Console.WriteLine("Jack's Income is {0:0.00}, Tax is {1:0.00} and Bonus is {2:0.00}", jack.Income(), Tax(jack), Bonus(jack));
        SalesPerson jill = new SalesPerson(186, 52, 64000);
        Console.WriteLine("Jill's Income is {0:0.00}, Tax is {1:0.00} and Bonus is {2:0.00}", jill.Income(), Tax(jill), Bonus(jill));
        //Tax(null);
        Bonus(null);
    }
}
