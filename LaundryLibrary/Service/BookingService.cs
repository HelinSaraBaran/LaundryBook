using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaundryLibrary.Repository;
using LaundryLibrary.Model;
using Microsoft.Data.SqlClient;


namespace LaundryLibrary.Service
{
    public class BookingService
    {
        IBookingRepository _ibook;
        public BookingService(IBookingRepository repo)
        {
            _ibook = repo;
        }


        public void Add(Booking item)
        {
          
                _ibook.Add(item);
           
        }
        public Dictionary<int, Booking> GetAll()
        {
            return _ibook.GetAll();
        }
        public void Delete(int id)
        {
            _ibook.Delete(id);
        }
        public void Change(DateTime date, int point, int id)
        {
            _ibook.Change(date, point, id);
        }
        public Booking FindKey(int key)
        {
            return _ibook.FindKey(key);
        }
        public void Choice(int id, int booking)
        {
            _ibook.Choice(id, booking);
        }


    }
}
