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
            List<string> mobiles = new List<string>();
            List<int> machineids = new List<int>();
            Dictionary<int,Booking> compreApartments = _ibook.GetAll();
            foreach (KeyValuePair<int, Booking> kp in compreApartments)
            {

                mobiles.Add(kp.Value.Mobile);
                machineids.Add(kp.Value.MachineId);
            }
            if (!mobiles.Contains(item.Mobile) && item.Mobile != null && !machineids.Contains(item.MachineId))
            {
                _ibook.Add(item);
            }
            
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
