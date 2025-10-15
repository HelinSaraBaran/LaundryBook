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
        public int ResidentId { get; set; }

        public BookingModel(ResidentService residentService, MachineService machineService, BookingService bookingService)
        {
            _residentService = residentService;
            _machineService = machineService;
            _bookingService = bookingService;

            Date = DateTime.Today;
            Slot = 1;
            MachineId = 0;
            ResidentId = 0;
        }

        public void OnGet()
        {
            Residents = _residentService.GetAllResidents();
            Machines = _machineService.GetAll();
            Bookings = _bookingService.GetAll();
        }

        public IActionResult OnPostCreate()
        {
            Booking newBooking = new Booking(Date, Slot, MachineId, ResidentId);
            _bookingService.Add(newBooking);
            return RedirectToPage("/Booking");
        }

        public IActionResult OnPostDelete(int key)
        {
            _bookingService.Delete(key);
            return RedirectToPage("/Booking");
        }

        public IActionResult OnPostChange(int key, DateTime newDate, int newSlot)
        {
            _bookingService.Change(newDate, newSlot, key);
            return RedirectToPage("/Booking");
        }

        public IActionResult OnPostChooseMachine(int key, int machineId)
        {
            _bookingService.Choice(machineId, key);
            return RedirectToPage("/Booking");
        }
    }
}
