namespace LaundryLibrary.Model
{
    // enum 2 hours (gemmes som 1..6 i DB)
    public enum TimeSlot
    {
        Slot08_10 = 1,
        Slot10_12 = 2,
        Slot12_14 = 3,
        Slot14_16 = 4,
        Slot16_18 = 5,
        Slot18_20 = 6
    }

    public class Booking
    {
        // our properties 
        public DateTime Date { get; set; }
        public TimeSlot Slot { get; set; }
        public int MachineId { get; set; }
        public int ResidentId { get; set; }

        // Fulde constructor
        public Booking(DateTime date, int slot, int machineId, int residentId)
        {
            Date = date.Date;
            MachineId = machineId;
            ResidentId = residentId;

            
            if (slot >= 1 && slot <= 6)
            {
                Slot = (TimeSlot)slot;
            }
            else
            {
                Slot = TimeSlot.Slot08_10;
            }
        }

      
        public TimeSlot ChangeTimeSlot(int newslot, TimeSlot current)
        {
            if (newslot >= 1 && newslot <= 6)
            {
                Slot = (TimeSlot)newslot;
                return Slot;
            }
            return current;
        }

      
        public override string ToString()
        {
            return "Booking #" + MachineId.ToString() + " [" + ResidentId.ToString() + "]";
        }
    }
}
