using LaundryLibrary.Model;
using LaundryLibrary.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LaundryBook.Pages
{
    public class BookingModel : PageModel

    {
        private readonly ResidentService _residentService;
        public List<Resident> residents { get; set; } = new List<Resident>(); 
        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Description { get; set; }

        [BindProperty]
        public string PhoneNumber { get; set; }

        [BindProperty]
        public string Email { get; set; }

        private BookingService _bookingService;

       private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly ILogger<BookingModel> _logger;

        public BookingModel(ILogger<BookingModel> logger, ResidentService rs)
        {
            _logger = logger;
            _residentService = rs;
        }


        // her henter den alle residents
        public void OnGet()
        {
            residents = _residentService.GetAllResidents();
        }
       
        // her bliver den slettet
        public IActionResult OnPost(Resident resident) 
        {
            _residentService.DeleteResident(resident);

            return RedirectToPage();
        }
    }

}
