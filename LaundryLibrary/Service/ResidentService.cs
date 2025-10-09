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
    public class ResidentService
    {
        IResidentRepository _IResident;
        public ResidentService(IResidentRepository repo)
        {
            _IResident = repo;
        }
        public List<Apartment> GetAllApartments()
        {
            return _IResident.GetAllApartments();
        }
        public void AddApartment(Apartment item)
        {
            _IResident.AddApartment(item);
        }
        public void DeleteApartment(Apartment id)
        {
            _IResident.DeleteApartment(id);
        }
        public List<Resident> GetAllResidents()
        {
            return _IResident.GetAllResidents();
        }
        public void AddResident(Resident item)
        {
            _IResident.AddResident(item);
        }
        public void DeleteResident(Resident id)
        {
            _IResident.DeleteResident(id);
        }
    }
}
