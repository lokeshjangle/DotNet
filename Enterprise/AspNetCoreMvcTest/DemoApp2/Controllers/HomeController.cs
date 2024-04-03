using DemoApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index([FromServices] SiteDbContext site)
    {
        var selection = from visitor in site.Visitors
                        where visitor.Id.Length > 3
                        select new VisitInfo 
                        {
                            VisitorName = visitor.Id,
                            VisitCount = visitor.Visits.Count,
                            LastVisit = visitor.Visits.Max(e => e.Moment)
                        };
        return View(selection.ToList()); //~/Views/<current-controller-name>/<current-action-name>.cshtml
    }

    public IActionResult Register()
    {
        return View(new Visitor());
    }

    [HttpPost]
    public IActionResult Register([FromServices] SiteDbContext site, Visitor input)
    {
        if(ModelState.IsValid)
        {
            var visitor = site.Visitors.Find(input.Id);
            if(visitor is null)
            {
                visitor = input;
                site.Visitors.Add(visitor);
            }
            visitor.Visits.Add(new Visitation());
            site.SaveChanges();
            return RedirectToAction("Index");
        }
        return Register();
    }
}