using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// class responsible for reservation, machine and resident id 
namespace LaundryLibrary.Model
{
    // enum 2 hours (maks to timer som står i vores opgave ) gemt som int i vores database
    public enum TimeSlot
    {
        Slot08_10 = 1,
        Slot10_12 = 2,
        Slot12_14 = 3,
        Slot14_16 = 4,
        Slot16_18 = 5,
        Slot18_20 = 6,
    }
    public class Booking
    {
       // our properties 
       public DateTime Date { get; set; }
        public TimeSlot Slot { get; set; }
        public int MachineId { get; set; }
        public int ResidentId { get; set; }

        // Constructor - parameterløs
        public Booking()
        {
            this.Date = DateTime.Today;
            this.Slot = TimeSlot.Slot08_10;
            this.MachineId = 0;
            this.ResidentId = 0;
        }

        // Fulde constructor
        public Booking(DateTime date, TimeSlot slot, int machineId, int residentId)
        {
            this.Date = date.Date;
            this.Slot = slot;
            this.MachineId = machineId;
            this.ResidentId = residentId;
        }
         // igen måske en tostring overrife for dato  machine id og resident id? 
    }
}
