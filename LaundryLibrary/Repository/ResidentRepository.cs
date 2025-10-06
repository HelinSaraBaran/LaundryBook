using LaundryLibrary.Interfaces;
using LaundryLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<Apartment> GetAllBolig()
        {
            return apartments;
        }
        public void AddBolig(Apartment item)
        {

        }
        public void DeleateBolig(Apartment id)
        {

        }
        public List<Resident> GetAllBeboere()
        {
            return residents;
        }
        public void AddBeboere(Resident item)
        {

        }
        public void DeleateBeboere(Resident id)
        {

        }
    }
}
