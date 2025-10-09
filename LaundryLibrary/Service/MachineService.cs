using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaundryLibrary.Repository;
using LaundryLibrary.Model;
using Microsoft.Data.SqlClient;


namespace LaundryLibrary.Service
{
    public class MachineService
    {
        IMachineRepository _IMachine;
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
            _IMachine.Add(item);
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
