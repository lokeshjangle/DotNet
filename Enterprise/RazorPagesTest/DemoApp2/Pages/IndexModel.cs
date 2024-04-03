using System.Security.Claims;
using DemoApp.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoApp.Pages;

public class IndexModel : PageModel
{
    private readonly ShopDbContext shop;

    [BindProperty]
    public Customer Input { get; set; }

    public IndexModel(ShopDbContext db) => shop = db;

    public void OnGet()
    {
        Input = new Customer();
    }

    public async Task<IActionResult> OnPost()
    {
        var customer = await shop.Customers.FindAsync(Input.Id);
        if(customer?.Password == Input.Password)
        {
            var identity = new ClaimsIdentity("Customer");
            identity.AddClaim(new Claim(ClaimTypes.Name, Input.Id));
            await HttpContext.SignInAsync(new ClaimsPrincipal(identity));
            return RedirectToPage("Detail");
        }
        ModelState.AddModelError("Login", "Invalid Customer ID or Password");
        return Page();
    }

}