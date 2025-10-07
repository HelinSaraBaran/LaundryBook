using LaundryLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryLibrary.Repository
{
    public class BookingRepository:IBookingRepository
    {
        List<Booking> bookings;
        public BookingRepository()
        {
            bookings = new List<Booking>();
        }
        public List<Booking> GetAll()
        {
            return bookings;
        }
        public  void Add(Booking item)
        {

        }
        public void Delte(Booking id)
        {

        }
        public void Change(DateTime date, DateTime point)
        {

        }
    }
}
