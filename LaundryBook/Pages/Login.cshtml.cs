using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LaundryBook.Pages;
public class LoginModel : PageModel
{
    [BindProperty]
    public string Username { get; set; } = ""; //this "" is to avoid null reference exception

    [BindProperty]
    public string Password { get; set; } = "";

    public string ErrorMessage { get; set; }

    //it is called when the page is loaded and its empty now but we can use it later if needed like welcome message fx.
    public void OnGet()
    {
    }

    //it is called when the form is submitted, IActionResult means it can return different types of responses like this page or another page.
    public IActionResult OnPost()
    {
        //check login
        if (Username == "admin" && Password == "1234")
        {
            //if valid login
            return RedirectToPage("/Index");
        }
        //if invalid login
        ErrorMessage = "User name or password not valid";
        return Page();
    }
}
