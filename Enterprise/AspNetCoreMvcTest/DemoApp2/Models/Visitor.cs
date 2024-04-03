using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DemoApp.Models;

public class Visitor
{
    [Required]
    [MinLength(4, ErrorMessage = "Name too small")]
    public string Id { get; set; }

    [Range(0, 5)]
    public int Rating { get; set; }

    [JsonIgnore]
    public List<Visitation> Visits { get; set; } = new();
}
