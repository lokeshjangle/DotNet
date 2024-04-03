class Program
{
    static void Main(string[] args)
    {
        SimpleStack<string> a = new SimpleStack<string>();
        a.Push("Monday");
        a.Push("Tuesday");
        a.Push("Wednesday");
        a.Push("Thursday");
        a.Push("Friday");
        //a.Push(9.8);
        while(!a.Empty())
            Console.WriteLine(a.Pop());
        Console.WriteLine("--------------------------------");
        SimpleStack<Interval> b = new SimpleStack<Interval>();
        b.Push(new Interval(3, 41));
        b.Push(new Interval(5, 32));
        b.Push(new Interval(4, 13));
        b.Push(new Interval(6, 24));
        while(!b.Empty())
            Console.WriteLine(b.Pop());
    }
}