using LaundryLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace LaundryLibrary.Repository
{
    public class BookingRepository:IBookingRepository
    {
        // vi skal have en internal storage 
        private readonly List<Booking> bookings;

        public BookingRepository()
        {
            bookings = new List<Booking>();
        }
        public List<Booking> GetAll()
        {
            return bookings;
        }
        public void Add(Booking item)
        {
            if (item == null)
            {
                throw new ArgumentException("Booking cannot be null");
            }
            if (item.MachineId <= 0 || item.ResidentId <= 0)
            {

                throw new ArgumentException(" Booking ");
            }
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
