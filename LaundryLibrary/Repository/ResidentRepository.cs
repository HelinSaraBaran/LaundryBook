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
            apartments.Add(item);
        }
        public void DeleateBolig(Apartment id)
        {
            Apartment apartmentToRemove = null; // initialiserer "DocLogToRemove" som "null"

            foreach (Apartment d in apartments)  //løber igennem hver "DocJournal" objekt i "_docJournal" listen. det valgte objekt bliver forløbeligt navngivet "d"
            {
                if (d == id) //tjekker om det valgte id matcher med det i parametren
                {
                    apartmentToRemove = d; //hvis det gør 
                    break; //stopper den med at løbe igennem
                }
            }

            if (apartmentToRemove != null) //hvis en matching DocJournal blev fundet
            {
                apartments.Remove(apartmentToRemove); //bliver den slettet fra listen
            }

        }
        public List<Resident> GetAllBeboere()
        {
            return residents;
        }
        public void AddBeboere(Resident item)
        {
            residents.Add(item);
        }
        public void DeleateBeboere(Resident id)
        {
            Resident residentToRemove = null; // initialiserer "DocLogToRemove" som "null"

            foreach (Resident d in residents)  //løber igennem hver "DocJournal" objekt i "_docJournal" listen. det valgte objekt bliver forløbeligt navngivet "d"
            {
                if (d == id) //tjekker om det valgte id matcher med det i parametren
                {
                    residentToRemove = d; //hvis det gør 
                    break; //stopper den med at løbe igennem
                }
            }

            if (residentToRemove != null) //hvis en matching DocJournal blev fundet
            {
               residents.Remove(residentToRemove); //bliver den slettet fra listen
            }

        }
    }
}
