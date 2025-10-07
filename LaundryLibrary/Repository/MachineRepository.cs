using LaundryLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace LaundryLibrary.Repository
{
    public class MachineRepository:IMachineRepository
    {
        List<Machine> machines;
        public MachineRepository()
        {
            machines = new List<Machine>();
        }
        public List<Machine> GetAll()
        {
            return machines;
        }
        public void Add(Machine item)
        {
            machines.Add(item);

        }
        public void Delete(Machine id)
        {
            Machine MachineToRemove = null; // initialiserer "DocLogToRemove" som "null"

            foreach (Machine d in machines)
            {
                if (d.Id == id.Id)
                {
                    MachineToRemove = d;
                    break;
                }
            }
            if (MachineToRemove != null)
            {
                machines.Remove(MachineToRemove);
            }
        }
       

    }

}
