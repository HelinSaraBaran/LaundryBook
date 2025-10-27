using Autofac.Extras.Moq;
using LaundryLibrary.Model;
using LaundryLibrary.Repository;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LaundryLibraryTest
{
    public class ResidentRepositoryTest
    {
        [Theory]
        [InlineData]
        public void AddNewResudent()
        {
            ResidentRepository rr = new ResidentRepository("Server=(localdb)\\MSSQLLocalDB;Database=vask_en_tid;Integrated Security=True;;Encrypt=False");




        }
        [Fact]
        public void GetAllResidentValidCall()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<SqlCommand>()
                    .Setup(x => x.)
            }
            ResidentRepository rr = new ResidentRepository("Server=(localdb)\\MSSQLLocalDB;Database=vask_en_tid;Integrated Security=True;;Encrypt=False");

            throw new NotImplementedException();

        }

    }
}
