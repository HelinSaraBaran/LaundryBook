using LaundryLibrary.Interfaces;
using LaundryLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
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
            bookings.Add(item);

        }
        public void Delete(Booking id)
        {
            Booking bookingToRemove = null; // initialiserer "DocLogToRemove" som "null"

            foreach (Booking d in bookings)
            {
                if (d == id)
                {
                    bookingToRemove = d;
                    break;
                }
            }
            if (bookingToRemove != null)
            {
                bookings.Remove(bookingToRemove);
            }
        }
        public void Change(DateTime date, DateTime point)
        {

        }

        public void Choice(int id)
        {


        }
    }
}
