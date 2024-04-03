using DemoApp.Models;

var site = new SiteDbContext();
if(args.Length > 0)
{
    Visitor visitor = site.Visitors.Find(args[0]);
    if(visitor is null)
    {
        visitor = new Visitor { Id = args[0] };
        site.Visitors.Add(visitor);
    }
    visitor.Visits.Add(new Visitation { VisitorId = visitor.Id});
    site.SaveChanges();
    Console.WriteLine($"Welcome {visitor.Id}");
}
else
{
    var selection = from e in site.Visitors
                    where e.Id.Length > 3
                    select new VisitInfo 
                    {
                        VisitorName = e.Id,
                        VisitCount = e.Visits.Count,
                        LastVisit = e.Visits.Max(v => v.Moment)
                    };
    foreach(var entry in selection)
        Console.WriteLine("{0}\t{1}\t{2}", entry.VisitorName, entry.VisitCount, entry.LastVisit);

}
