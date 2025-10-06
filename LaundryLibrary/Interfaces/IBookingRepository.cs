using LaundryLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryLibrary.Interfaces
{
    public interface IBookingRepository: IGeneric<Booking>
    {
        List<Booking> GetAll();
        void Add(Booking item);
        void Deleate(Booking id);
        void Change(DateTime date, DateTime point);
    }
}
