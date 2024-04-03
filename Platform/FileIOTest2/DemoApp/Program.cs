using Tourism;

using Site mysite = Site.Load("CitiZoo");
if(args.Length > 0)
{
    Visitor visitor = mysite.GetVisitor(args[0]);
    visitor.Visit();
    Console.WriteLine($"Welcome {visitor.Id}, your ticket number is {visitor.Ticket}");
}
else
{
    foreach(Visitor visitor in mysite.Visitors)
        Console.WriteLine($"{visitor.Id}\t{visitor.VisitCount}\t{visitor.LastVisit:yyyy-MMM-dd hh:mm:ss tt}");
}
