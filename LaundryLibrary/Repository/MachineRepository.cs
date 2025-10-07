using LaundryLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using Microsoft.Identity.Client;


namespace LaundryLibrary.Repository
{
    public class MachineRepository:IMachineRepository
    {
        Dictionary<int,Machine> machines;
        public MachineRepository()
        {
            machines = new Dictionary<int,Machine>();
        }
        public Dictionary<int,Machine> GetAll()
        {
            return machines;
        }




        public void Add(Machine item)
        {
            int count = 0;
            foreach (KeyValuePair<int,Machine>  m in machines)
            {
                count++;
                Debug.WriteLine($"count is {count}");
            }
            machines.Add(count,item);

        }
        public void Delete(int id)
        {
            
                if (FindKey(id) != null)
                {
                    machines.Remove(id);
                    
                }
            
        }
        public Machine FindKey(int key)
        {
            if (machines.ContainsKey(key))
            {
                return machines[key];
            }
            else
            {
                return null;
            }
                
        }
       

    }

}
