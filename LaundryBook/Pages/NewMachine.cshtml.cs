using LaundryLibrary.Model;
using LaundryLibrary.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Drawing;

namespace LaundryBook.Pages
{
    public class NewMachineModel : PageModel
    {
        private readonly MachineService _ms;
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public MachineType Type { get; set; }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("UserMobile") != "0000")

            {
                //if not admin, redirect to home page
                return RedirectToPage("/Index");
            }
            return Page();
        }
        public NewMachineModel(MachineService ms)
        {
            _ms = ms;
        }
        public IActionResult OnPostCreate()
        {
            if (Type != 0)
            {
                _ms.Add(new Machine(Id, Type));
                Debug.WriteLine($"type is {Type}" );



                return RedirectToPage("/index");
            }
            return RedirectToPage("/NewMachine");



        }
    }
}
