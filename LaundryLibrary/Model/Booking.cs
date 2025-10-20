namespace LaundryLibrary.Model
{
    // Enum for tidsintervaller (2 timer)
    public enum TimeSlot
    {
        Slot08_10 = 1,
        Slot10_12 = 2,
        Slot12_14 = 3,
        Slot14_16 = 4,
        Slot16_18 = 5,
        Slot18_20 = 6
    }

    // Booking repræsenterer en vaskereservation i systemet
    public class Booking
    {
        public DateTime Date { get; set; }       
        public TimeSlot Slot { get; set; }       
        public int MachineId { get; set; }       
        public int ResidentId { get; set; }      
        public string Mobile { get; set; }       

        // Fulde constructor
        public Booking(DateTime date, int slot, int machineId, int residentId)
        {
            Date = date.Date;
            MachineId = machineId;
            ResidentId = residentId;
            Mobile = string.Empty; // undgå null

            // Tildeler tidsrum ud fra talværdi 1-6
            if (slot >= 1 && slot <= 6)
            {
                Slot = (TimeSlot)slot;
            }
            else
            {
                Slot = TimeSlot.Slot08_10;
            }
        }

        // Ændrer tidsrum for en eksisterende booking
        public TimeSlot ChangeTimeSlot(int newSlot, TimeSlot currentSlot)
        {
            if (newSlot >= 1 && newSlot <= 6)
            {
                Slot = (TimeSlot)newSlot;
                return Slot;
            }
            return currentSlot;
        }

        // Returnerer en simpel tekst om bookingen
        public override string ToString()
        {
            return "Booking: Maskine #" + MachineId + " | Mobil: " + Mobile + " | Tidsrum: " + Slot.ToString();
        }
    }
}
