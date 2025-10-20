using LaundryLibrary.Model;
using LaundryLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LaundryLibraryTest
{
    public class BookingRepositoryTest
    {
        [Theory]
        [InlineData(0, "2000, 01, 01", 2,1,1)]
        public void GetAllTest(int idKey,string bookdate,int solt,int macID,int resID)
        {
            //arrange
            BookingRepository br = new BookingRepository("Server=(localdb)\\MSSQLLocalDB;Database=vask_en_tid;Integrated Security=True;;Encrypt=False");
            Dictionary<int, Booking> testDict = new Dictionary<int, Booking>();
            DateTime date = Convert.ToDateTime(bookdate);
            testDict.Add(idKey, new Booking(date, solt, macID, resID));

            //act
            Dictionary<int, Booking> brDict = br.GetAll();


            //assert
            foreach (KeyValuePair<int, Booking> kp in brDict)
            {
                Debug.WriteLine("main dict"+kp.Value.Slot);
            }
            foreach (KeyValuePair<int, Booking> kp in testDict)
            {
                Debug.WriteLine("test dict" + kp.Value.Slot);
            }
            Assert.Equal(brDict, testDict);
        }
    }
}
