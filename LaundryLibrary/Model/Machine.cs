using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LaundryLibrary.Model
{ // Responsible for identity and type of a laundry machine
    public enum MachineType
    {
     Washer = 1, // Vaskemaskine
     Dryer = 2, //Tørretumbler
     Ironer = 3, // Rullemaskine

    }

    public class Machine
    {
        public int Id { get; set; } // PK i database
        public MachineType Type { get; set; } // enum i vores kode

        // parameterløs constructor 

        public Machine() 
        {
            Id = 0;
            Type = MachineType .Washer;
            Type = MachineType.Dryer;
            Type = MachineType.Ironer;
        }

        // Fulde constructor
        public Machine(int id, MachineType type)
        {
            Id= id;
            Type = type;
        }

        // ToString override metode -  kan ses som en "visningstekst" 
        public override string ToString()
        {
            return "Machine #" + Id.ToString() + " [" + Type.ToString() + "]";
        }
    }

}
