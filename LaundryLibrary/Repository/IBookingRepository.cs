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
        void Change(DateTime date, int point, int id);
        Booking FindKey(int key);
        void Choice(int id, int booking);


    }
}
