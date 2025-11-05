using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LaundryLibrary.Service;
using LaundryLibrary.Model;
using System.Collections.Generic;

namespace LaundryBook.Pages
{
    public class ResidentsListModel : PageModel
    {

        private readonly ResidentService _residentService; //to bring data from DB
        public List<Resident> Residents { get; set; }    // List that will hold all residents and be passed to the page

        // this constructor works once we open the page
        public ResidentsListModel(ResidentService residentService)
        {
            _residentService = residentService;
        }

        public IActionResult OnGet()
        {
            //this condition means that only admin can access this page
            if (HttpContext.Session.GetString("UserMobile") != "0000")
            
            {
                //if not admin, redirect to home page
                return RedirectToPage("/Index");
            }
            //if admin, get all residents
            Residents = _residentService.GetAllResidents();
            //then return the page with the list of residents
            return Page();
        }
    }
}
