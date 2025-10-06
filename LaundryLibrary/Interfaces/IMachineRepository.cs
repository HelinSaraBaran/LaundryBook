using LaundryLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryLibrary.Interfaces
{
    public interface IMachineRepository:IGeneric<Machine>
    {
        List<Machine> GetAll();
        void Add(Machine item);
        void Deleate(Machine id);
        void Choice(int id);

    }
}
