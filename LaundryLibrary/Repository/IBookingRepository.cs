using System;
using System.Collections.Generic;
using LaundryLibrary.Model;

namespace LaundryLibrary.Repository
{
    public interface IBookingRepository : IGeneric<Booking>
    {
        Dictionary<int, Booking> GetAll();
        void Add(Booking item);

        void Delete(int machineId, string mobile);

        void Change(DateTime date, int point, int id);
        Booking FindKey(int key);
        void Choice(int id, int booking);

       
    }

}
