using DemoApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers;

[ApiController] //enable Web (REST) API specific behaviors
[Route("/api/review")]
public class FeedbackController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Visitor>> ReadFeedbacks(SiteDbContext site, int min = 0)
    {
        var selection = from visitor in site.Visitors
                        where visitor.Rating >= min
                        select visitor;
        return selection.Count() > 0 ? selection.ToList() : NotFound();
    }

    [HttpPut]
    public IActionResult UpdateFeedback(SiteDbContext site, Visitor input)
    {
        Visitor visitor = site.Visitors.Find(input.Id);
        if(visitor is not null)
        {
            visitor.Rating = input.Rating;
            site.SaveChanges();
            return Ok();
        }
        return NotFound();
    }
}