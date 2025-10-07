using LaundryLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace LaundryLibrary.Repository
{
    public interface IBookingRepository: IGeneric<Booking>
    {
        Dictionary<int,Booking> GetAll();
        void Add(Booking item);
        void Delete(int id);
        void Change(DateTime date, DateTime point);
        Booking FindKey(int key);

    }
}
