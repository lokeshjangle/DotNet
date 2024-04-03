if(args.Length == 0)
{
    //ICollection<Interval> store = new List<Interval>();
    //ICollection<Interval> store = new LinkedList<Interval>();
    //ICollection<Interval> store = new HashSet<Interval>();
    ICollection<Interval> store = new SortedSet<Interval>();
    store.Add(new Interval(4, 31));
    store.Add(new Interval(7, 42));
    store.Add(new Interval(5, 13));
    store.Add(new Interval(3, 24));
    store.Add(new Interval(6, 55));
    store.Add(new Interval(2, 151));
    foreach(Interval i in store)
        Console.WriteLine(i);
}
else
{
    //IDictionary<string, Interval> store = new Dictionary<string, Interval>();
    //IDictionary<string, Interval> store = new SortedDictionary<string, Interval>();
    IDictionary<string, Interval> store = new SortedList<string, Interval>();
    store.Add("monday", new Interval(4, 31));
    store.Add("tuesday", new Interval(7, 42));
    store.Add("wednesday", new Interval(5, 13));
    store.Add("thursday", new Interval(3, 24));
    store["friday"] = new Interval(6, 55); //adds a new key-value pair
    store["tuesday"] = new Interval(2, 42); //updates value of the key
    if(store.TryGetValue(args[0], out Interval val))
    {
        Console.WriteLine("Value: {0}", val);
    }
    else
    {
        foreach(var pair in store)
            Console.WriteLine("{0, -12}{1, 8}", pair.Key, pair.Value);
    }
}