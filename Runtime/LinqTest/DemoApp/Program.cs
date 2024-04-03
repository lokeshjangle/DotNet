if (args[0] == "items")
{
    var items = Shop.GetItems();
    items.Where(i => i.Brand == args[1])
        .Select(i => i.Name.ToUpper())
        .PrintEach();       
}
else if(args[0] == "customers")
{
    decimal amount = decimal.Parse(args[1]);
    var customers = Shop.GetCustomers();
    customers.Add(new Customer("Xavier", 120000, 5));
    var selection = from c in customers
                    where c.Purchase >= amount
                    orderby c.Id descending
                    select new //will initialize instance of an anonymous type with specified properties 
                    {
                        Email = c.Id.ToLower() + "@gmail.com",
                        Stars = new string('*', c.Rating),
                        Payment = 1.18m * c.Purchase
                    };
    foreach(var entry in selection)
        Console.WriteLine("{0, -20}{1, 10}", entry.Email, entry.Stars);
    Console.WriteLine("Total Payment: {0}", selection.Sum(c => c.Payment));
}