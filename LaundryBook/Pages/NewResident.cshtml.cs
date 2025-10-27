using LaundryLibrary.Model;
using LaundryLibrary.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        public List<Apartment> Apartments { set; get; }

        public NewResidentModel(ResidentService rs)
        {
            
            _residentService = rs;
            
        }
        public void OnGet()
        {
            Apartments = _residentService.GetAllApartments();
        }
        public IActionResult OnPostCreate(int id,string fristName,string lastName,string mobile,string email, Apartment apartment)
        {
            _residentService.AddResident(new Resident(id, fristName, lastName, mobile, email, apartment));
            return RedirectToPage("/");
        }
    }
}
