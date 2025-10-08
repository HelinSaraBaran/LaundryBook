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
        private readonly Dictionary<int,Booking> bookings;

        public BookingRepository()
        {
            bookings = new Dictionary<int, Booking>();
        }
        public Dictionary<int,Booking> GetAll()
        {
            return bookings;
        }
        public void Add(Booking item)
        {
            int count = GetCount();
            if (item == null)
            {
                throw new ArgumentException("Booking cannot be null");
            }
           else if (item.MachineId < 0 && item.ResidentId < 0)
            {

                bookings.Add(count,item);
            }
        }

        
        public void Delete(int id)
        {

            {
                if (FindKey(id) != null)
                {
                    bookings.Remove(id);
                    
                }
            }
        }
        public void Change(DateTime date, int point,int id)
        {
            if(FindKey(id) != null)
            {
                bookings[id].Date = date.Date;
                bookings[id].Slot = bookings[id].ChangeTimeSlot(point, bookings[id].Slot);
            }
        }

        public void Choice(int id, int booking)
        {
            
            if(FindKey(booking) != null)
            {
                bookings[booking].MachineId = id;
            }
            
        }
        public int GetCount()
        {
            int count = 0;
            foreach(KeyValuePair<int,Booking> b in bookings)
            {
                count++;
            }
            return count;
        }
        public Booking FindKey(int key)
        {
            if (bookings.ContainsKey(key))
            {
                return bookings[key];
            }
            else
            {
                return null;
            }

        }
    }
}
