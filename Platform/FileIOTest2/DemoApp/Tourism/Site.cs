using System.Text.Json;

namespace Tourism;

public class Site : IDisposable
{
    public string Title { get; set; }

    public List<Visitor> Visitors { get; set; }

    public Site(string title)
    {
        Title = title;
        Visitors = new();
    }

    public Visitor GetVisitor(string name)
    {
        Visitor? visitor = Visitors.Find(e => e.Id == name);
        if(visitor is null)
        {
            visitor = new Visitor { Id = name };
            Visitors.Add(visitor);
        }
        return visitor;
    }

    public void Dispose()
    {
        using var output = File.OpenWrite(Title + ".store");
        JsonSerializer.Serialize(output, this);
    }

    public static Site Load(string name)
    {
        try
        {
            using var input = File.OpenRead(name + ".store");
            return JsonSerializer.Deserialize<Site>(input)!;
        }
        catch
        {
            return new Site(name);
        }
    }
}