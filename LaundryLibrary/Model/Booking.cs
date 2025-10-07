using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


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
            Date = DateTime.Today;
            Slot = TimeSlot.Slot08_10;
            MachineId = 0;
            ResidentId = 0;
        }

        // Fulde constructor
        public Booking(DateTime date, int slot, int machineId, int residentId):this()
        {
            Date = date.Date;
            MachineId = machineId;
            ResidentId = residentId;

            if (slot != null && TimeSlot.Slot08_10.Equals(1))
            {
                Slot = TimeSlot.Slot08_10;
            }
            else if (slot != null && TimeSlot.Slot10_12.Equals(2))
            {
                Slot = TimeSlot.Slot10_12;
            }
            else if (slot != null && TimeSlot.Slot12_14.Equals(3))
            {
                Slot = TimeSlot.Slot12_14;
            }
            else if (slot != null && TimeSlot.Slot12_14.Equals(4))
            {
                Slot = TimeSlot.Slot14_16;
            }
            else if (slot != null && TimeSlot.Slot14_16.Equals(5))
            {
                Slot = TimeSlot.Slot16_18;
            }
            else if (slot != null && TimeSlot.Slot16_18.Equals(6))
            {
                Slot = TimeSlot.Slot18_20;
            }
           
        }

        public TimeSlot ChangeTimeSlot(int newslot, TimeSlot slot)
        {
            if (newslot != null && TimeSlot.Slot08_10.Equals(1))
            {
                return Slot = TimeSlot.Slot08_10;
            }
            else if (newslot != null && TimeSlot.Slot10_12.Equals(2))
            {
                return Slot = TimeSlot.Slot10_12;
            }
            else if (newslot != null && TimeSlot.Slot12_14.Equals(3))
            {
                return Slot = TimeSlot.Slot12_14;
            }
            else if (newslot != null && TimeSlot.Slot14_16.Equals(4))
            {
                return Slot = TimeSlot.Slot14_16;
            }
            else if (newslot != null && TimeSlot.Slot16_18.Equals(5))
            {
                return Slot = TimeSlot.Slot16_18;
            }
            else if (newslot != null && TimeSlot.Slot18_20.Equals(6))
            {
                return Slot = TimeSlot.Slot18_20;
            }
            else
            {
                return slot;
            }
        }
        
        public override string ToString()
        {
            return "Booking #" + MachineId.ToString() + " [" + ResidentId.ToString() + "]";
        }
}
}
