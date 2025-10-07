using LaundryLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace LaundryLibrary.Repository
{
    public class ResidentRepository:IResidentRepository
    {
        List<Apartment> apartments;
        List<Resident> residents;
        public ResidentRepository()
        {
            apartments = new List<Apartment>();
            residents = new List<Resident>();
        }
        public List<Apartment> GetAllApartments()
        {
            return apartments;
        }
        public void AddApartment(Apartment item)
        {

        }
        public void DeleteApartment(Apartment id)
        {

        }
        public List<Resident> GetAllResidents()
        {
            return residents;
        }
        public void AddResident(Resident item)
        {

        }
        public void DeleteResident(Resident id)
        {

        }
    }
}
