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
            this.Id = 0;
            this.Type = MachineType .Washer;
        }

        // Fulde constructor
        public Machine(int id, MachineType type)
        {
            this.Id= id;
            this.Type = type;
        }

        // ToString override metode -  kan ses som en "visningstekst" 
        public override string ToString()
        {
            return "Machine #" + this.Id.ToString() + " [" + this.Type.ToString() + "]";
        }
    }

}
