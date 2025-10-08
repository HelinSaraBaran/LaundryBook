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
        private string _connectionString;
        public ResidentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        List<Apartment> apartments;
        List<Resident> residents;
        public ResidentRepository()
        {
            apartments = new List<Apartment>();
            residents = new List<Resident>();
        }
        public List<Apartment> GetAllApartments()
        {
            var beboere = new List<Apartment>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("select Resident from beboere", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var apartment = new Apartment((string)reader["city"], (int)reader["floor"], (string)reader["streetAndNumber"], (string)reader["postalCode"], (string)reader["appartmentLetter"], (string)reader["addressLine"]);


                    }

                }


                return apartments;
            } }
        public void AddApartment(Apartment item)
        {
            apartments.Add(item);
        }
        public void DeleteApartment(Apartment id)
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
        public List<Resident> GetAllResidents()
        {
            return residents;
        }
        public void AddResident(Resident item)
        {
            residents.Add(item);
        }
        public void DeleteResident(Resident id)
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
