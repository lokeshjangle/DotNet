using System.Text.Json.Serialization;

namespace Tourism;

public class Visitor
{
    public required string Id { get; set; }

    public int VisitCount { get; set; }

    public DateTime LastVisit { get; set; }

    [JsonIgnore]
    public long Ticket { get; set; }

    public void Visit()
    {
        VisitCount += 1;
        LastVisit = DateTime.Now;
        Ticket = LastVisit.Ticks % 1000000;
    }
}