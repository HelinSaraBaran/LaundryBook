using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaundryLibrary.Repository;
using LaundryLibrary.Model;
using Microsoft.Data.SqlClient;
using System.Diagnostics;


namespace LaundryLibrary.Service
{
    public class MachineService
    {
        IMachineRepository _IMachine;
        Dictionary<int, Machine> compreMachines;
        public MachineService(IMachineRepository repo)
        {
            _IMachine = repo;
        }
        public Dictionary<int, Machine> GetAll()
        {
            return _IMachine.GetAll();
        }

        public void Add(Machine item)
        {
            List<int> keys = new List<int>();
            compreMachines = _IMachine.GetAll();
            foreach(KeyValuePair<int,Machine> kp in compreMachines)
            {
                Debug.WriteLine(kp.Key);
                keys.Add(kp.Key);
            }
            if(!keys.Contains(item.Id) )
            {
                _IMachine.Add(item);
            }
            


        }
        public void Delete(int id)
        {
            _IMachine.Delete(id);
        }
        public Machine FindKey(int key)
        {
            return _IMachine.FindKey(key);
        }

    }
}
