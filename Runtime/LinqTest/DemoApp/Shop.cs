record Item(string Name, string Brand);

record Customer(string Id, decimal Purchase, int Rating) : IComparable<Customer>
{
    public int CompareTo(Customer other)
    {
        return Id.CompareTo(other.Id);
    }
}

static class Shop
{
    public static Item[] GetItems()
    {
        return new Item[] 
        {
            new Item("cpu", "intel"),
            new Item("ddr", "samsung"),
            new Item("motherboard", "intel"),
            new Item("mouse", "logitech"),
            new Item("cpu", "amd"),
            new Item("monitor", "samsung"),
            new Item("keyboard", "logitech"),
            new Item("ssd", "samsung"),
            new Item("mouse", "microsoft")
        };
       
    }

    public static ICollection<Customer> GetCustomers()
    {
        ICollection<Customer> customers = new List<Customer>();
        customers.Add(new Customer("Diptish", 42000, 3));
        customers.Add(new Customer("Vinayak", 58000, 2));
        customers.Add(new Customer("Karan", 65000, 5));
        customers.Add(new Customer("Amol", 84000, 4));
        customers.Add(new Customer("Suyog", 21000, 1));
        customers.Add(new Customer("Ritul", 72000, 3));
        customers.Add(new Customer("Bhavesh", 52000, 4));
        customers.Add(new Customer("Monali", 96000, 5));
        customers.Add(new Customer("Tejal", 81000, 4));
        customers.Add(new Customer("Nikita", 19000, 2));
        return customers;
    }

    public static void PrintEach<E>(this IEnumerable<E> source)
    {
        foreach(var entry in source)
            Console.WriteLine(entry);
    }
}


