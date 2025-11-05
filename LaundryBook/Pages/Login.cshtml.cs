using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LaundryLibrary.Service;
using System.Linq;

namespace LaundryBook.Pages;
public class LoginModel : PageModel
{
    private readonly ResidentService _residentService; //to bring data from DB
    // this constructor works once we open the page
    public LoginModel(ResidentService residentService)
    {  
        _residentService = residentService;
    }

    //[BindProperty]
    //public string Username { get; set; } = ""; //this "" is to avoid null reference exception

    [BindProperty]
    public string Mobile { get; set; } = ""; //this "" is to avoid null reference exception

    public string ErrorMessage { get; set; }

    //it is called when the page is loaded and its empty now but we can use it later if needed like welcome message fx.
    public void OnGet()
    {
    }

    //it is called when the form is submitted, IActionResult means it can return different types of responses like this page or another page.
    public IActionResult OnPost()
    {

        //hard code Admin login
        if (Mobile == "0000")
        {
            HttpContext.Session.SetString("UserLoggedIn", "True");
            HttpContext.Session.SetString("Username", "Admin");
            HttpContext.Session.SetString("UserMobile", "0000");
            return RedirectToPage("/Index");
        }


        //brings first resident with matching mobile number from DB
        var resident = _residentService.GetAllResidents().FirstOrDefault(r => r.Mobile == Mobile);

        //check login
        if (resident != null)
        {

            HttpContext.Session.SetString("UserLoggedIn", "True");
            HttpContext.Session.SetString("Username", resident.FirstName + " " + resident.LastName);
            HttpContext.Session.SetString("UserMobile", resident.Mobile);


            //return to home page if valid login
            return RedirectToPage("/Index");
        }
        //if invalid login
        ErrorMessage = "Mobile number not found";
        return Page();
    }
}
