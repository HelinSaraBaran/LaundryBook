using System;
using System.Collections.Generic;
using LaundryLibrary.Repository;
using LaundryLibrary.Model;
using Microsoft.Data.SqlClient;

namespace LaundryLibrary.Service
{
   
    public class BookingService
    {
        private readonly IBookingRepository _ibook; 

        public BookingService(IBookingRepository repo)
        {
            _ibook = repo;
        }

        // booking oprettes
        public void Add(Booking item)
        {
            _ibook.Add(item);
        }

        // Henter alle bookinger
        public Dictionary<int, Booking> GetAll()
        {
            return _ibook.GetAll();
        }

      
        public void Delete(int machineId, string mobile)
        {
            _ibook.Delete(machineId, mobile);
        }

        // Ændr dato/tidsrum 
        public void Change(DateTime date, int point, int id)
        {
            _ibook.Change(date, point, id);
        }

        // Find booking i dictionary
        public Booking FindKey(int key)
        {
            return _ibook.FindKey(key);
        }

        // Skift maskine 
        public void Choice(int id, int booking)
        {
            _ibook.Choice(id, booking);
        }
    }
}
