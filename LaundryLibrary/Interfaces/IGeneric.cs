using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryLibrary.Interfaces
{
    public interface IGeneric<T>
    {
        List<T> GetAll();
        void Add(T item);
        void Deleate(T id);
    }
}
