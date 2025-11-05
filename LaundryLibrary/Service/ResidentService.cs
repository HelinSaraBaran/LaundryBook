using LaundryLibrary.Model;
using LaundryLibrary.Repository;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;


namespace LaundryLibrary.Service
{
    public class ResidentService
    {
        IResidentRepository _IResident;
        public ResidentService(IResidentRepository repo)
        {
            _IResident = repo;
        }
        public Dictionary<int, Apartment> GetAllApartments()
        {
            return _IResident.GetAllApartments();
        }
        public void AddApartment(Apartment item)
        {
            //List<int> keys = new List<int>();
            //Dictionary<int, Apartment> compreApartments = _IResident.GetAllApartments();
            //foreach (KeyValuePair<int, Apartment> kp in compreApartments)
            //{
                
            //    keys.Add(kp.Key);
            //}
            //if (!keys.Contains(item.Id))
            //{
                _IResident.AddApartment(item);
            //}
            
        }
        public void DeleteApartment(int id)
        {
            _IResident.DeleteApartment(id);
        }
        public List<Resident> GetAllResidents()
        {
            return _IResident.GetAllResidents();
        }
        public void AddResident(Resident item)
        {
            List<string> mobiles = new List<string>();
            List<Resident> compreApartments = _IResident.GetAllResidents();
            foreach (Resident r in compreApartments)
            {

                mobiles.Add(r.Mobile);
            }
            if (!mobiles.Contains(item.Mobile))
            {
                _IResident.AddResident(item);
            }
        }
        public void DeleteResident(Resident id)
        {
            _IResident.DeleteResident(id);
        }
    }
}
