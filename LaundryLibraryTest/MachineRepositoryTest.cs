using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaundryLibrary;
using LaundryLibrary.Repository;
using LaundryLibrary.Model;
using Xunit;
using System.Diagnostics;

namespace LaundryLibraryTest
{
    public class MachineRepositoryTest
    {
        [Theory]
        [InlineData(0,1)]
        public void GetAllTest(int idKey,int mType)
        {
            MachineRepository mr = new MachineRepository("Server=(localdb)\\MSSQLLocalDB;Database=vask_en_tid;Integrated Security=True;;Encrypt=False");
            Dictionary<int, Machine> testlist = new Dictionary<int, Machine>();
            //testlist.Add(idKey,new Machine(idKey, mType));

            Dictionary<int, Machine> mrDict = mr.GetAll();
            
            
            Assert.Equal(mrDict, testlist);
        }
    }
}
