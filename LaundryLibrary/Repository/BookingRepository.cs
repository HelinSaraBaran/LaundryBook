using LaundryLibrary.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace LaundryLibrary.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly string _connectionString;
        private readonly Dictionary<int, Booking> _bookings;

        public BookingRepository(string connectionString)
        {
            _connectionString = connectionString;
            _bookings = new Dictionary<int, Booking>();
        }

        public Dictionary<int, Booking> GetAll()
        {
            Dictionary<int, Booking> result = new Dictionary<int, Booking>();

            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand(
                "SELECT bookingdate, bookingtime, machine_ID, mobile FROM Booking",
                connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                int counter = 1;
                while (reader.Read())
                {
                    DateTime date = Convert.ToDateTime(reader["bookingdate"]);
                    int slot = Convert.ToInt32(reader["bookingtime"]);
                    int machineId = Convert.ToInt32(reader["machine_ID"]);

                    int residentId = 0;
                    string mobileText = reader["mobile"].ToString();
                    if (int.TryParse(mobileText, out int mobileValue))
                    {
                        residentId = mobileValue;
                    }

                    Booking booking = new Booking(date, slot, machineId, residentId);
                    result.Add(counter, booking);
                    counter++;
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error in BookingRepository.GetAll(): " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return result;
        }

        public void Add(Booking item)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand(
                "INSERT INTO Booking (bookingdate, bookingtime, machine_ID, mobile) " +
                "VALUES (@date, @time, @machine, @mobile)",
                connection);

           
            command.Parameters.AddWithValue("@date", item.Date);
            command.Parameters.AddWithValue("@time", ((int)item.Slot).ToString());
            command.Parameters.AddWithValue("@machine", item.MachineId);
            command.Parameters.AddWithValue("@mobile", item.ResidentId.ToString());

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error in BookingRepository.Add(): " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            int nextKey = _bookings.Count + 1;
            if (!_bookings.ContainsKey(nextKey))
            {
                _bookings.Add(nextKey, item);
            }
        }

        public void Delete(int id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("DELETE FROM Booking WHERE machine_ID = @id", connection);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error in BookingRepository.Delete(): " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            if (_bookings.ContainsKey(id))
            {
                _bookings.Remove(id);
            }
        }

        public void Change(DateTime date, int point, int id)
        {
            if (_bookings.ContainsKey(id))
            {
                _bookings[id].Date = date.Date;
                _bookings[id].Slot = _bookings[id].ChangeTimeSlot(point, _bookings[id].Slot);
            }
        }

        public void Choice(int id, int booking)
        {
            if (_bookings.ContainsKey(booking))
            {
                _bookings[booking].MachineId = id;
            }
        }

        public int GetCount()
        {
            int count = 0;
            foreach (KeyValuePair<int, Booking> b in _bookings)
            {
                count++;
            }
            return count;
        }

        public Booking FindKey(int key)
        {
            if (_bookings.ContainsKey(key))
            {
                return _bookings[key];
            }
            else
            {
                return null;
            }
        }
    }
}
