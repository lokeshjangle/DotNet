namespace DemoApp.Models;

public class Visitor
{
    public required string Id { get; set; }

    public int Rating { get; set; }

    //navigation property
    public List<Visitation> Visits { get; set; } = new();
}
