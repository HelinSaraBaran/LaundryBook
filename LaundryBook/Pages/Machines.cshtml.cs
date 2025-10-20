using System.Collections.Generic;
using LaundryLibrary.Model;
using LaundryLibrary.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LaundryBook.Pages
{
    public class MachinesModel : PageModel
    {
        private readonly MachineService _machineService;

        public Dictionary<int, Machine> Machines { get; set; }

        public MachinesModel(MachineService machineService)
        {
            _machineService = machineService;
            Machines = new Dictionary<int, Machine>();
        }

        public void OnGet()
        {
            Machines = _machineService.GetAll();
        }
    }
}
