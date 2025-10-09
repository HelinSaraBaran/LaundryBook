using LaundryLibrary.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace LaundryLibrary.Repository
{
    


    public class BookingRepository:IBookingRepository
    {


        private string _connectionString;
        public BookingRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


        // vi skal have en internal storage 
        private readonly Dictionary<int,Booking> bookings;

        public BookingRepository()
        {
            bookings = new Dictionary<int, Booking>();
        }
        public Dictionary<int, Booking> GetAll()
        {
            var Booking = new Dictionary<int, Booking>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("Select date from booking", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var booking = new Booking((DateTime)reader["date"],(int)reader["bookingtime"],(int)reader["Machineid"],(int)reader["Residentid"])
                        {
                        }; 
                        bookings.Add(1, booking);

                    }
                }
                return bookings;
            }
        }

        public void Add(Booking item)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("Insert into Booking(date, bookingtime, maskine_ID,mobile) Values (@date,@bookingtime, @machine_ID, @mobile)", connection);
                command.Parameters.AddWithValue("@date", item.Date);
                command.Parameters.AddWithValue("@bookingtime", item.Slot);
                command.Parameters.AddWithValue("@machine_ID", item.MachineId);
                command.Parameters.AddWithValue("@mobile", item.ResidentId);
                connection.Open();
                command.ExecuteNonQuery();

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                    }
                }
                int count = GetCount();
                if (item == null)
                {
                    throw new ArgumentException("Booking cannot be null");
                }
                else if (item.MachineId < 0 && item.ResidentId < 0)
                {

                    bookings.Add(count, item);
                }
            }
        }

        
        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("Delete from Booking Where Id = @Id", connection);
                command.Parameters.AddWithValue("@Id",id);
                connection.Open();
                command.ExecuteNonQuery();
            }
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
