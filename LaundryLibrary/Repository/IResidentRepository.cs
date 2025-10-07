using LaundryLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryLibrary.Repository
{
    public interface IResidentRepository
    {
        List<Apartment> GetAllApartments();
        void AddApartment(Apartment item);
        void DeleteApartment(Apartment id);
        List<Resident> GetAllResidents();
        void AddResident(Resident item);
        void DeleteResident(Resident id);
    }
}
