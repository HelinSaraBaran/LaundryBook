using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;



namespace LaundryLibrary.Model
{ 
    public enum MachineType
    {
     Washer = 1, 
     Dryer = 2, 
     Ironer = 3, 

    }

    public class Machine
    {
        public int Id { get; set; } 
        public MachineType Type { get; set; } 


        // Fulde constructor
        public Machine(int id, MachineType type)
        {
            Id= id;
            Type = type;
        }

        // ToString override metode 
        public override string ToString()
        {
            return "Machine #" + Id.ToString() + " [" + Type.ToString() + "]";
        }
    }

}
