using LaundryLibrary.Model;
using LaundryLibrary.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace LaundryBook.Pages
{
    public class NewResidentModel : PageModel
    {
        private readonly ResidentService _residentService;

        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public string FristName { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        public string Moblie { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
       public string City { get; set; }
        [BindProperty]

        public int Floor { get; set; }
        [BindProperty]

        public string Streetandnumber { get; set; }
        [BindProperty]

        public string postacode { get; set; }
        [BindProperty]

        public string aprtymentletter { get; set; }
        [BindProperty]

        public string addressline { get; set; }


        public NewResidentModel(ResidentService rs)
        {
            
            _residentService = rs;
            
        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("UserMobile") != "0000")

            {
                //if not admin, redirect to home page
                return RedirectToPage("/Index");
            }
            return Page();
        }
        public IActionResult OnPostCreate()
        {
                _residentService.AddResident(new Resident(Id, FristName, LastName, Moblie, Email, new Apartment(City,Floor,Streetandnumber,postacode,aprtymentletter,addressline)));

            
          
            return RedirectToPage("/index");
        }
    }
}
