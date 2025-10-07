using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaundryLibrary.Model;
using Microsoft.Data.SqlClient;


namespace LaundryLibrary.Repository
{
    public interface IGeneric<T>
    {
        Dictionary<int,T> GetAll();
        void Add(T item);
        void Delete(int id);
         T FindKey(int key);

    }
}
