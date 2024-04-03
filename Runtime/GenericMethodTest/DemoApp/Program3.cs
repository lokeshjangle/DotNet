using System.Net.Http.Headers;

class Program
{
    static T Select<T>(int index, T first, T second) 
    {
        if((index % 2) == 1)
            return first;
        return second;
    }

    static T Select<T>(T first, T second) where T: IComparable<T>
    {
        if(first.CompareTo(second) > 0)
            return first;
        return second;
    }

    static void Main(string[] args)
    {
        if(args.Length > 0)
        {
            int s = int.Parse(args[0]);
            string ss = Select(s, "Monday", "Tuesday");
            Console.WriteLine($"Selected string = {ss}");
            double sd = Select(s, 45.6, 32.1);
            Console.WriteLine($"Selected double = {sd}");
            //double ssd = (double) Select(s, "Friday", 56.7);
        }
        else
        {
            string ss = Select("Monday", "Tuesday");
            Console.WriteLine($"Selected string = {ss}");
            double sd = Select(45.6, 32.1);
            Console.WriteLine($"Selected double = {sd}");
            Interval si = Select(new Interval(3, 45), new Interval(2, 30)); 
            Console.WriteLine($"Selected Interval = {si}");      
        }
    }
}
