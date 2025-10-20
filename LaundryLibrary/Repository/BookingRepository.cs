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

        // Henter alle bookinger fra databasen
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

                    // mobil hentes som tekst
                    string mobile = reader["mobile"].ToString();

                    // vi gemmer kun mobil som tekst i modellen
                    Booking booking = new Booking(date, slot, machineId, 0);
                    booking.Mobile = mobile; 
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

        // Tilføjer ny booking i databasen
        public void Add(Booking item)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand(
                "INSERT INTO Booking (bookingdate, bookingtime, machine_ID, mobile) " +
                "VALUES (@date, @time, @machine, @mobile)",
                connection);

            command.Parameters.AddWithValue("@date", item.Date);
            command.Parameters.AddWithValue("@time", ((int)item.Slot));
            command.Parameters.AddWithValue("@machine", item.MachineId);
            command.Parameters.AddWithValue("@mobile", item.Mobile);

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

        // Sletter booking ud fra machine_ID og mobil
        public void Delete(int machineId, string mobile)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand(
                "DELETE FROM Booking WHERE machine_ID = @machine AND mobile = @mobile",
                connection);

            command.Parameters.AddWithValue("@machine", machineId);
            command.Parameters.AddWithValue("@mobile", mobile);

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

            // Fjerner også lokalt fra dictionary
            List<int> keysToRemove = new List<int>();
            foreach (KeyValuePair<int, Booking> kv in _bookings)
            {
                if (kv.Value.MachineId == machineId && kv.Value.Mobile == mobile)
                {
                    keysToRemove.Add(kv.Key);
                }
            }

            foreach (int k in keysToRemove)
            {
                _bookings.Remove(k);
            }
        }

        // Ændrer dato/tidsrum 
        public void Change(DateTime date, int point, int id)
        {
            if (_bookings.ContainsKey(id))
            {
                _bookings[id].Date = date.Date;
                _bookings[id].Slot = _bookings[id].ChangeTimeSlot(point, _bookings[id].Slot);
            }
        }

        // Skifter maskine 
        public void Choice(int id, int booking)
        {
            if (_bookings.ContainsKey(booking))
            {
                _bookings[booking].MachineId = id;
            }
        }

        // Antal bookinger
        public int GetCount()
        {
            return _bookings.Count;
        }

        // Finder booking i dictionary
        public Booking FindKey(int key)
        {
            if (_bookings.ContainsKey(key))
            {
                return _bookings[key];
            }
            return null;
        }

        public void Delete(int id)
        {
            Delete(id, string.Empty);
        }
    }
}
