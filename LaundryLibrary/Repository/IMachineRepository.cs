using LaundryLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace LaundryLibrary.Repository
{
    public interface IMachineRepository:IGeneric<Machine>
    {
        Dictionary<int, Machine> GetAll();
        void Add(Machine item);
        void Delete(int id);
      
        
       

    }
}
