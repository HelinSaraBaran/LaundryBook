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
        public int Ap { get; set; }
        [BindProperty]
        public Dictionary<int,Apartment> Apartments { set; get; }

        public NewResidentModel(ResidentService rs)
        {
            
            _residentService = rs;
            
        }
        public void OnGet()
        {
            Apartments = _residentService.GetAllApartments();
        }
        public IActionResult OnPostCreate()
        {
            try
            {
                _residentService.AddResident(new Resident(Id, FristName, LastName, Moblie, Email, Apartments[Ap]));

            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                return RedirectToPage("/Index");

            }
            return RedirectToPage("/");
        }
    }
}
