using System.Linq.Expressions;

class Program
{
    private static void Present(string head, object body)
    {
        Console.WriteLine($"{head} = {body.ToString()}"); //using string interpolation
    }

    public static void Main()
    {
        Interval a = new Interval(4, 5);
        Interval b = new Interval(5, 45);
        Interval c = new Interval(3, 65);
        Interval d = b;
        Present("Interval a", a);
        Present("Interval b", b);
        Present("Interval c", c);
        Present("Interval d", d);
        Present("Total", a + b + c + d);
        Console.WriteLine("----------------------------------");
        Console.WriteLine("a is identical to b: {0}", ReferenceEquals(a, b));
        Console.WriteLine("a is identical to c: {0}", ReferenceEquals(a, c));
        Console.WriteLine("d is identical to b: {0}", ReferenceEquals(d, b));
        Console.WriteLine("----------------------------------");
        Console.WriteLine("a is equal to b: {0}", a.GetHashCode() == b.GetHashCode() && a.Equals(b));
        Console.WriteLine("a is equal to c: {0}", a.GetHashCode() == c.GetHashCode() && a.Equals(c));
        Console.WriteLine("d is equal to b: {0}", d.GetHashCode() == b.GetHashCode() && d.Equals(b));
        Console.WriteLine("----------------------------------");   
        //using instance-initializer syntac
        Rectangle e = new Rectangle { Length = 12.75, Breadth = 8.25};
        //automatic boxing is performed to convert Rectangle (value-type)
        //to object (reference-type)
        Present("Rectangle e", e);     
    }
}
