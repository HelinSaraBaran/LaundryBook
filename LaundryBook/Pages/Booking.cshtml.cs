using System;
using System.Collections.Generic;
using LaundryLibrary.Model;
using LaundryLibrary.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LaundryBook.Pages
{
    public class BookingModel : PageModel
    {
        private readonly ResidentService _residentService;
        private readonly MachineService _machineService;
        private readonly BookingService _bookingService;

        // Lists til visning i dropdowns og tabel
        public List<Resident> Residents { get; set; } = new List<Resident>();
        public Dictionary<int, Machine> Machines { get; set; } = new Dictionary<int, Machine>();
        public Dictionary<int, Booking> Bookings { get; set; } = new Dictionary<int, Booking>();

     
        [BindProperty]
        public DateTime Date { get; set; }

        [BindProperty]
        public int Slot { get; set; }

        [BindProperty]
        public int MachineId { get; set; }

   
        [BindProperty]
        public string Mobile { get; set; }

        public BookingModel(ResidentService residentService, MachineService machineService, BookingService bookingService)
        {
            _residentService = residentService;
            _machineService = machineService;
            _bookingService = bookingService;

            Date = DateTime.Today;
            Slot = 1;
            MachineId = 0;
            Mobile = string.Empty;
        }

        // Henter data fra services
        public void OnGet()
        {
            Residents = _residentService.GetAllResidents();
            Machines = _machineService.GetAll();
            Bookings = _bookingService.GetAll();
        }

        // Opret ny booking
        public IActionResult OnPostCreate()
        {
            Booking newBooking = new Booking(Date, Slot, MachineId, 0);
            newBooking.Mobile = Mobile;

            _bookingService.Add(newBooking);
            return RedirectToPage("/Booking");
        }

        // 0 referencer da vi mangler data i vores db
       
        public IActionResult OnPostDelete(int machineId, string mobile)
        {
            _bookingService.Delete(machineId, mobile);
            return RedirectToPage("/Booking");
        }

        // Ændrer dato/tidsrum
        public IActionResult OnPostChange(int key, DateTime newDate, int newSlot)
        {
            _bookingService.Change(newDate, newSlot, key);
            return RedirectToPage("/Booking");
        }

        // Skifter maskine
        public IActionResult OnPostChooseMachine(int key, int machineId)
        {
            _bookingService.Choice(machineId, key);
            return RedirectToPage("/Booking");
        }
    }
}
