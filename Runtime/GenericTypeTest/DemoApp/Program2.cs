class Program
{
    static void PrintStack(SimpleStack<string> stack)
    {
        while(!stack.Empty())
            Console.WriteLine(stack.Pop());
    }

    static void PrintStack(SimpleStack<Interval> stack)
    {
        while(!stack.Empty())
            Console.WriteLine(stack.Pop());
    }

    static void Main(string[] args)
    {
        SimpleStack<string> a = new SimpleStack<string>();
        a.Push("Monday");
        a.Push("Tuesday");
        a.Push("Wednesday");
        a.Push("Thursday");
        a.Push("Friday");
        PrintStack(a);
        Console.WriteLine("--------------------------------");
        SimpleStack<Interval> b = new SimpleStack<Interval>();
        b.Push(new Interval(3, 41));
        b.Push(new Interval(5, 32));
        b.Push(new Interval(4, 13));
        b.Push(new Interval(6, 24));
        PrintStack(b);
    }
}