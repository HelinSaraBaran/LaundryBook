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
        List<T> GetAll();
        void Add(T item);
        void Delete(T id);
    }
}
