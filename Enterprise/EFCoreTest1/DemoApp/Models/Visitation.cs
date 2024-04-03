namespace DemoApp.Models;

public class Visitation
{
    public int Id { get; set; }

    public string VisitorId { get; set; }

    public DateTime Moment { get; set; } = DateTime.Now;
}
