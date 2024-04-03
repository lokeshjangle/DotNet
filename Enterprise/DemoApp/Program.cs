using Shopping;

var shop = new ShopDbContext();
if(args.Length == 0)
{
    foreach(var product in shop.Products)
        Console.WriteLine("{0, -6}{1, 12:0.00}{2, 8}", product.Id, product.Price, product.Stock);
}
else
{
    int pid = int.Parse(args[0]);
    var product = shop.Products
                    .Where(e => e.Id == pid)
                    .Include(e => e.Orders)
                    .FirstOrDefault();
    Console.WriteLine("Price of Product: {0:0.00}", product.Price);
    if(product != null)
    {
        foreach(var order in product.Orders)
            Console.WriteLine("{0}\t{1}\t{2:yyyy-MM-dd}", order.CustomerId, order.Quantity, order.OrderDate);
    }
    else
    {
        Console.WriteLine("No such product!");
    }

}