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
        List<Apartment> GetAllBolig();
        void AddBolig(Apartment item);
        void DeleateBolig(Apartment id);
        List<Resident> GetAllBeboere();
        void AddBeboere(Resident item);
        void DeleateBeboere(Resident id);
    }
}
